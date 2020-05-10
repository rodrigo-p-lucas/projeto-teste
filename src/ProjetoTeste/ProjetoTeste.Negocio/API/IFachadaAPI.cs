using ProjetoTeste.CrossCutting;

namespace ProjetoTeste.Negocio
{
    public interface IFachadaAPI
    {
        RetornoWS AtualizarProdutoAPI(Produto produto, string codigoIntegracao);
        RetornoWS CadastrarProdutoAPI(Produto novoProduto);
    }
}