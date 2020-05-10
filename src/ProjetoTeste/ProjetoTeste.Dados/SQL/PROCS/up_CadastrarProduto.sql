IF OBJECT_ID('up_CadastrarProduto') IS NULL
    EXEC('CREATE PROCEDURE up_CadastrarProduto AS SET NOCOUNT ON;')
GO

ALTER PROCEDURE up_CadastrarProduto(
	@ProdutoDescricao varchar(255),
    @ProdutoValor decimal(12,2),
	@ProdutoQuantidadeEstoque int,
	@ProdutoCodigo int output
)
as

insert into Produto(ProdutoDescricao, ProdutoValor, ProdutoQuantidadeEstoque)
values(@ProdutoDescricao, @ProdutoValor, @ProdutoQuantidadeEstoque)

select @ProdutoCodigo = @@IDENTITY

go