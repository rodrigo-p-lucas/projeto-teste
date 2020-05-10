using ProjetoTeste.Dominio;
using System;
using Xunit;

namespace ProjetoTeste.TestesServidor
{
    public class ProdutoUnitTest
    {
        [Fact]
        public void QuandoCriarUmProdutoEntaoRetornaUmProdutoComIdPreenchido()
        {
            //Arrange    
            var descricao = "ProdutoTeste";
            var valor = 12;
            var estoque = 15;

            //Act 
            var produtoTeste = new Produto(descricao, valor, estoque);

            //Assert
            Assert.NotNull(produtoTeste);
            Assert.NotEqual(produtoTeste.Id, Guid.Empty);
        }

        [Fact]
        public void QuandoEnviadoNovaDescricaoEntaoProdutoDeveAlterarSuaDescricao()
        {
            //Arrange    
            var descricao = "ProdutoTeste";
            var valor = 12;
            var estoque = 15;
            var produtoTeste = new Produto(descricao, valor, estoque);

            //Act 
            produtoTeste.AlterarDescricao("OutroProdutoTeste");

            //Assert
            Assert.Equal("OutroProdutoTeste", produtoTeste.ProdutoDescricao);
        }

        [Fact]
        public void QuandoEnviadoNovoValorEntaoProdutoDeveAlterarSeuValor()
        {
            //Arrange    
            var descricao = "ProdutoTeste";
            var valor = 12;
            var estoque = 15;
            var produtoTeste = new Produto(descricao, valor, estoque);

            //Act
            produtoTeste.AlterarValor(20);

            //Assert
            Assert.Equal(20, produtoTeste.ProdutoValor);
        }

        [Fact]
        public void QuandoEnviadoNovaQtdEstoqueEntaoProdutoDeveAlterarSuaQtdEstoque()
        {
            //Arrange    
            var descricao = "ProdutoTeste";
            var valor = 12;
            var estoque = 15;
            var produtoTeste = new Produto(descricao, valor, estoque);

            //Act
            produtoTeste.AlterarQtdEstoque(5);

            //Assert
            Assert.Equal(5, produtoTeste.ProdutoQtdEstoque);
        }
    }
}
