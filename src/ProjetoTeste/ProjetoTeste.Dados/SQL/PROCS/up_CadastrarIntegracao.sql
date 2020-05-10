IF OBJECT_ID('up_CadastrarIntegracao') IS NULL
    EXEC('CREATE PROCEDURE up_CadastrarIntegracao AS SET NOCOUNT ON;')
GO

ALTER PROCEDURE up_CadastrarIntegracao(
	@ProdutoCodigo int,
	@IntegracaoData datetime,
	@IntegracaoStatus varchar(30),
	@IntegracaoMensagem varchar(500)
)

as

insert into ProdutoIntegracao(ProdutoCodigo, IntegracaoData, IntegracaoStatus, IntegracaoMensagem)
values(@ProdutoCodigo, @IntegracaoData, @IntegracaoStatus, @IntegracaoMensagem)

go