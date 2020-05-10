IF OBJECT_ID('up_AtualizarProduto') IS NULL
    EXEC('CREATE PROCEDURE up_AtualizarProduto AS SET NOCOUNT ON;')
GO

ALTER PROCEDURE up_AtualizarProduto(
	@ProdutoCodigo int,
	@ProdutoDescricao varchar(255),
    @ProdutoValor decimal(12,2),
	@ProdutoQuantidadeEstoque int
)
as

update Produto
set 
	ProdutoDescricao = @ProdutoDescricao,
    ProdutoValor = @ProdutoValor,
	ProdutoQuantidadeEstoque = @ProdutoQuantidadeEstoque
where ProdutoCodigo = @ProdutoCodigo

go