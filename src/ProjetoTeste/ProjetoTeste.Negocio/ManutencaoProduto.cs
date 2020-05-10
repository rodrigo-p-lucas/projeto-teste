using ProjetoTeste.CrossCutting;
using ProjetoTeste.Dados;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoTeste.Negocio
{
    public class ManutencaoProduto
    {
        private IRepositorio _repo;
        private IFachadaAPI _webService;
        private Produto _produto;

        public ManutencaoProduto(IRepositorio repo = null, IFachadaAPI fachadaAPI = null, Produto produto = null)
        {
            _repo = repo ?? Repositorio.CriarRepositorio();
            _webService = fachadaAPI ?? new FachadaAPI();
            _produto = produto;
        }

        public void RealizarManutencaoProduto()
        {
            ValidarProduto();

            string codigoIntegracao = BuscarCodigoIntegracaoAtual();

            if (_produto.ProdutoCodigo == 0)
            {
                CadastrarProduto();
            }
            else
            {
                AtualizarProduto();
            }

            RetornoWS retorno;
            try
            {
                if (codigoIntegracao == null)
                {
                    retorno = _webService.CadastrarProdutoAPI(_produto);
                }
                else
                {
                    retorno = _webService.AtualizarProdutoAPI(_produto, codigoIntegracao);
                }
            }
            catch (Exception ex)
            {
                retorno = new RetornoWS(-1, ex.Message);
            }

            AtualizarIntegracao(retorno);
        }

        public List<Produto> ConsultarListaProdutos()
        {
            return _repo.ConsultarListaProdutos();
        }
        public List<ProdutoIntegracao> ConsultarListaIntegracoes(int produtoId)
        {
            return _repo.ConsultarListaIntegracoes(produtoId);
        }

        private void CadastrarProduto()
        {
            try
            {
                //Grava em banco local
                var produtoCodigo = _repo.CadastrarProduto(_produto);
                _produto.ProdutoCodigo = produtoCodigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void AtualizarProduto()
        {
            try
            {
                _repo.AtualizarProduto(_produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void AtualizarIntegracao(RetornoWS retorno)
        {
            ProdutoIntegracao integracao = new ProdutoIntegracao(
                    _produto.ProdutoCodigo,
                    DateTime.Now,
                    Enumeradores.StatusIntegracao.NaoIntegrado,
                    string.Empty
                );

            if (retorno.Status == 1)
            {
                integracao.IntegracaoStatus = Enumeradores.StatusIntegracao.Integrado;
            }

            integracao.IntegracaoMensagem = retorno.CodigoIntegracao.Replace("\"","") ?? string.Empty;
            _repo.CadastrarIntegracao(integracao);
        }

        private void ValidarProduto()
        {
            if (_produto == null)
            {
                throw new Exception("Produto não informado.");
            }

            if (!_produto.ValidarProduto())
            {
                throw new Exception("Produto não está válido. Favor checar dados inseridos.");
            }
        }
        private string BuscarCodigoIntegracaoAtual()
        {
            var integracoes = ConsultarListaIntegracoes(_produto.ProdutoCodigo);

            return integracoes
                .OrderByDescending(i => i.IntegracaoData)
                .FirstOrDefault(i => i.IntegracaoStatus == Enumeradores.StatusIntegracao.Integrado)
                ?.IntegracaoMensagem;
        }
    }
}
