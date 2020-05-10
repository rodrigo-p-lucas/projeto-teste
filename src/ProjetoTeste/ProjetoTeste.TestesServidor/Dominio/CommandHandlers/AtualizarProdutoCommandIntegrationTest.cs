using ProjetoTeste.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ProjetoTeste.TestesServidor
{
    public class AtualizarProdutoCommandIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public async Task QuandoAlterarProdutoComDadosValidosEntaoOProdutoDeveSerAlterado()
        {
            //Arrange
            var produto = ProdutoRepositorioTest.GetByDescricao("Produto1");
            var commandTest = new AlterarProdutoCommand(produto.Id, "Produto1Teste", 1, 1);
            var handler = new ProdutoCommandHandler(ProdutoRepositorioTest);

            //Act
            var result = await handler.Handle(commandTest, CancellationToken.None);

            //Assert
            var produtoAtualizado = ProdutoRepositorioTest.GetById(Guid.Parse(result));

            Assert.NotNull(produtoAtualizado);
            Assert.Equal("Produto1Teste", produtoAtualizado.ProdutoDescricao);
            Assert.Equal(1, produtoAtualizado.ProdutoValor);
            Assert.Equal(1, produtoAtualizado.ProdutoQtdEstoque);
        }

        [Fact]
        public async Task QuandoAlterarProdutoComValorInvalidoEntaoOProdutoNaoDeveSerAlterado()
        {
            //Arrange
            var produto = ProdutoRepositorioTest.GetByDescricao("Produto2");
            var commandTest = new AlterarProdutoCommand(produto.Id, "Produto2Teste", -1, 1);
            var handler = new ProdutoCommandHandler(ProdutoRepositorioTest);

            //Act
            var result = await handler.Handle(commandTest, CancellationToken.None);

            //Assert
            var produtoAtualizado = ProdutoRepositorioTest.GetByDescricao("Produto2");

            Assert.NotNull(produtoAtualizado);
            Assert.Equal("Valor do produto não pode ser negativo", result);
            Assert.Equal(produto.ProdutoDescricao, produtoAtualizado.ProdutoDescricao);
            Assert.Equal(produto.ProdutoValor, produtoAtualizado.ProdutoValor);
            Assert.Equal(produto.ProdutoQtdEstoque, produtoAtualizado.ProdutoQtdEstoque);
        }

        [Fact]
        public async Task QuandoAlterarProdutoComQtdEstoqueInvalidoEntaoOProdutoNaoDeveSerAlterado()
        {
            //Arrange
            var produto = ProdutoRepositorioTest.GetByDescricao("Produto3");
            var commandTest = new AlterarProdutoCommand(produto.Id, "Produto3Teste", 1, -1);
            var handler = new ProdutoCommandHandler(ProdutoRepositorioTest);

            //Act
            var result = await handler.Handle(commandTest, CancellationToken.None);

            //Assert
            var produtoAtualizado = ProdutoRepositorioTest.GetByDescricao("Produto3");

            Assert.NotNull(produtoAtualizado);
            Assert.Equal("Quantidade em estoque não pode ser negativa", result);
            Assert.Equal(produto.ProdutoDescricao, produtoAtualizado.ProdutoDescricao);
            Assert.Equal(produto.ProdutoValor, produtoAtualizado.ProdutoValor);
            Assert.Equal(produto.ProdutoQtdEstoque, produtoAtualizado.ProdutoQtdEstoque);
        }

        [Fact]
        public async Task QuandoAlterarDescricaoProdutoParaDescricaoJaExistenteEntaoOProdutoNaoDeveSerAlterado()
        {
            //Arrange
            var produto = ProdutoRepositorioTest.GetByDescricao("Produto3");
            var commandTest = new AlterarProdutoCommand(produto.Id, "Produto2", 1, 1);
            var handler = new ProdutoCommandHandler(ProdutoRepositorioTest);

            //Act
            var result = await handler.Handle(commandTest, CancellationToken.None);

            //Assert
            var produtoAtualizado = ProdutoRepositorioTest.GetByDescricao("Produto3");

            Assert.NotNull(produtoAtualizado);
            Assert.Equal("Já existe produto com esta descrição", result);
            Assert.Equal(produto.ProdutoDescricao, produtoAtualizado.ProdutoDescricao);
            Assert.Equal(produto.ProdutoValor, produtoAtualizado.ProdutoValor);
            Assert.Equal(produto.ProdutoQtdEstoque, produtoAtualizado.ProdutoQtdEstoque);
        }

        [Fact]
        public async Task QuandoAlterarProdutoNaoExistenteEntaoOProdutoNaoDeveSerAlterado()
        {
            //Arrange
            var produto = ProdutoRepositorioTest.GetByDescricao("Produto3");
            var commandTest = new AlterarProdutoCommand(Guid.NewGuid(), "Produto3", 1, 1);
            var handler = new ProdutoCommandHandler(ProdutoRepositorioTest);

            //Act
            var result = await handler.Handle(commandTest, CancellationToken.None);

            //Assert
            var produtoAtualizado = ProdutoRepositorioTest.GetByDescricao("Produto3");

            Assert.NotNull(produtoAtualizado);
            Assert.Equal("Produto não encotrando para o id informado", result);
            Assert.Equal(produto.ProdutoDescricao, produtoAtualizado.ProdutoDescricao);
            Assert.Equal(produto.ProdutoValor, produtoAtualizado.ProdutoValor);
            Assert.Equal(produto.ProdutoQtdEstoque, produtoAtualizado.ProdutoQtdEstoque);
        }
    }
}
