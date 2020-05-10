using ProjetoTeste.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ProjetoTeste.TestesServidor
{
    public class AdicionarProdutoCommandIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public async Task QuandoAdicionarProdutoValidoEntaoOProdutoDeveSerSalvo()
        {
            //Arrange
            var commandTest = new AdicionarProdutoCommand("Produto4", 120, 12);
            var handler = new ProdutoCommandHandler(ProdutoRepositorioTest);

            //Act
            var result = await handler.Handle(commandTest, CancellationToken.None);

            //Assert
            var entity = ProdutoRepositorioTest.GetById(Guid.Parse(result));

            Assert.NotNull(entity);
            Assert.Equal("Produto4", entity.ProdutoDescricao);
            Assert.Equal(120, entity.ProdutoValor);
            Assert.Equal(12, entity.ProdutoQtdEstoque);
        }

        [Fact]
        public async Task QuandoAdicionarProdutoComValorInvalidoEntaoOProdutoNaoDeveSerSalvo()
        {
            //Arrange
            var commandTest = new AdicionarProdutoCommand("Produto5", -1, 1);
            var handler = new ProdutoCommandHandler(ProdutoRepositorioTest);

            //Act
            var result = await handler.Handle(commandTest, CancellationToken.None);

            //Assert
            var entity = ProdutoRepositorioTest.GetByDescricao(commandTest.ProdutoDescricao);

            Assert.Null(entity);
            Assert.Equal("Valor do produto não pode ser negativo", result);
        }

        [Fact]
        public async Task QuandoAdicionarProdutoComQtdEstoqueInvalidoEntaoOProdutoNaoDeveSerSalvo()
        {
            //Arrange
            var commandTest = new AdicionarProdutoCommand("Produto6", 10, -10);
            var handler = new ProdutoCommandHandler(ProdutoRepositorioTest);

            //Act
            var result = await handler.Handle(commandTest, CancellationToken.None);

            //Assert
            var entity = ProdutoRepositorioTest.GetByDescricao(commandTest.ProdutoDescricao);

            Assert.Null(entity);
            Assert.Equal("Quantidade em estoque não pode ser negativa", result);
        }

        [Fact]
        public async Task QuandoAdicionarProdutoComDescricaoJaExistenteEntaoOProdutoNaoDeveSerSalvo()
        {
            //Arrange
            var commandTest = new AdicionarProdutoCommand("Produto1", 10, 10);
            var handler = new ProdutoCommandHandler(ProdutoRepositorioTest);

            //Act
            var result = await handler.Handle(commandTest, CancellationToken.None);

            //Assert
            var entity = ProdutoRepositorioTest.GetByDescricao(commandTest.ProdutoDescricao);

            Assert.NotNull(entity);
            Assert.Equal("Já existe produto com esta descrição", result);
        }
    }
}
