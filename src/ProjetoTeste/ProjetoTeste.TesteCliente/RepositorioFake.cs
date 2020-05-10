using ProjetoTeste.CrossCutting;
using ProjetoTeste.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoTeste.TesteCliente
{
    public class RepositorioFake : IRepositorio
    {
        List<Produto> produtos = new List<Produto>
            {
                { new Produto{
                    ProdutoCodigo = 1,
                    ProdutoDescricao = "Produto1",
                    ProdutoValor = 12,
                    ProdutoQuantidadeEstoque = 16}
},
                { new Produto{
                    ProdutoCodigo = 2,
                    ProdutoDescricao = "Produto2",
                    ProdutoValor = 23,
                    ProdutoQuantidadeEstoque = 17}
                },
                { new Produto{
                    ProdutoCodigo = 3,
                    ProdutoDescricao = "Produto3",
                    ProdutoValor = 34,
                    ProdutoQuantidadeEstoque = 18}
                },
                { new Produto{
                    ProdutoCodigo = 4,
                    ProdutoDescricao = "Produto4",
                    ProdutoValor = 45,
                    ProdutoQuantidadeEstoque = 19}
                }
            };
        List<ProdutoIntegracao> produtosIntegracao = new List<ProdutoIntegracao>
            {
                {new ProdutoIntegracao {
                    ProdutoCodigo = 1,
                    IntegracaoStatus = Enumeradores.StatusIntegracao.Integrado,
                    IntegracaoData = new DateTime(2020,05,08,10,00,00),
                    IntegracaoMensagem = "6cdad4ca-fc95-40e8-92ef-50376dc32ecf"}
                },
                {new ProdutoIntegracao {
                    ProdutoCodigo = 2,
                    IntegracaoStatus = Enumeradores.StatusIntegracao.NaoIntegrado,
                    IntegracaoData = new DateTime(2020,05,08,10,10,00),
                    IntegracaoMensagem = "Quantidade em estoque não pode ser negativa"}
                },
                {new ProdutoIntegracao {
                    ProdutoCodigo = 3,
                    IntegracaoStatus = Enumeradores.StatusIntegracao.NaoIntegrado,
                    IntegracaoData = new DateTime(2020,05,08,10,20,00),
                    IntegracaoMensagem = "Já existe produto com esta descrição"}
                },
                {new ProdutoIntegracao {
                    ProdutoCodigo = 3,
                    IntegracaoStatus = Enumeradores.StatusIntegracao.Integrado,
                    IntegracaoData = new DateTime(2020,05,08,10,30,00),
                    IntegracaoMensagem = "7cdad4ca-fc95-40e8-92ef-50376dc32ecf"}
                },
                {new ProdutoIntegracao {
                    ProdutoCodigo = 4,
                    IntegracaoStatus = Enumeradores.StatusIntegracao.Integrado,
                    IntegracaoData = new DateTime(2020,05,08,10,40,00),
                    IntegracaoMensagem = "1cdad4ca-fc95-40e8-92ef-50376dc32ecf"}
                },
                {new ProdutoIntegracao {
                    ProdutoCodigo = 4,
                    IntegracaoStatus = Enumeradores.StatusIntegracao.NaoIntegrado,
                    IntegracaoData = new DateTime(2020,05,08,10,50,00),
                    IntegracaoMensagem = "Já existe produto com esta descrição"}
                }
            };

        public bool AtualizarProduto(Produto produtoAlterado)
        {
            var produto = ConsultarProduto(produtoAlterado.ProdutoCodigo);
            if (produto != null)
            {
                produtos.Remove(produto);
                produtos.Add(produtoAlterado);
            }
            return true;
        }

        public bool CadastrarIntegracao(ProdutoIntegracao novaIntegracao)
        {
            produtosIntegracao.Add(novaIntegracao);
            return true;
        }

        public int CadastrarProduto(Produto novoProduto)
        {
            int max = produtos.Max(p => p.ProdutoCodigo) + 1;
            novoProduto.ProdutoCodigo = max;
            produtos.Add(novoProduto);
            return max;
        }

        public List<ProdutoIntegracao> ConsultarListaIntegracoes(int produtoCodigo)
        {
            return produtosIntegracao.Where(pi => pi.ProdutoCodigo.Equals(produtoCodigo)).ToList();
        }

        public List<Produto> ConsultarListaProdutos()
        {
            return produtos;
        }

        public Produto ConsultarProduto(int produtoId)
        {
            return produtos.FirstOrDefault(p => p.ProdutoCodigo.Equals(produtoId));
        }
    }
}
