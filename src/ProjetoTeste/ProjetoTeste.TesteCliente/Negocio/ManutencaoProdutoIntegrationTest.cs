using Moq;
using ProjetoTeste.CrossCutting;
using ProjetoTeste.Dados;
using ProjetoTeste.Negocio;
using System;
using System.Linq;
using Xunit;

namespace ProjetoTeste.TesteCliente
{
    public class ManutencaoProdutoIntegrationTest
    {
        IRepositorio _repo = new RepositorioFake();

        [Fact]
        public void QuandoCadastrarProdutoDeveIntegrarComAPI()
        {
            //Arrange
            var produtoEsperado = new Produto {
                ProdutoDescricao = "Produto10", 
                ProdutoValor = 1, 
                ProdutoQuantidadeEstoque = 1 
            };

            var fakeApi = new Mock<IFachadaAPI>();
            fakeApi
                .Setup(a => a.CadastrarProdutoAPI(produtoEsperado))
                .Returns(new RetornoWS(1, "6bdad4ca-fc95-40e7-92ef-50376dc32ecf"));

            var manutencaoProduto = new ManutencaoProduto(_repo, fakeApi.Object, produtoEsperado);

            //Act
            manutencaoProduto.RealizarManutencaoProduto();

            //Assert
            var produtoBanco = _repo
                .ConsultarListaProdutos()
                .FirstOrDefault(p => p.ProdutoDescricao == "Produto10");

            Assert.NotNull(produtoBanco);

            var produtoIntegracao = _repo
                .ConsultarListaIntegracoes(produtoBanco.ProdutoCodigo)
                .OrderByDescending(i => i.IntegracaoData)
                .FirstOrDefault(i => i.IntegracaoStatus == Enumeradores.StatusIntegracao.Integrado);

            Assert.NotNull(produtoIntegracao);
        }
    }
}
