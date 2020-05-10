using ProjetoTeste.CrossCutting;
using System.Collections.Generic;

namespace ProjetoTeste.Dados
{
    public interface IRepositorio
    {
        bool AtualizarProduto(Produto produtoAlterado);
        bool CadastrarIntegracao(ProdutoIntegracao novaIntegracao);
        int CadastrarProduto(Produto novoProduto);
        List<ProdutoIntegracao> ConsultarListaIntegracoes(int produtoCodigo);
        List<Produto> ConsultarListaProdutos();
        Produto ConsultarProduto(int produtoId);
    }
}