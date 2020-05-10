use master;
go

if db_id(N'ProjetoTesteConsole') IS NULL
	create database 'ProjetoTesteConsole'

use ProjetoTesteConsole
go

if not exists(select 1 from sys.objects where name = 'Produto' and type = 'U')
	CREATE TABLE Produto(
		ProdutoCodigo int identity(1,1) not null PRIMARY KEY,
		ProdutoDescricao varchar(255) not null,
		ProdutoValor decimal(12,2) DEFAULT 0,
		ProdutoQuantidadeEstoque int DEFAULT 0
	)
go

if not exists(select 1 from sys.objects where name = 'ProdutoIntegracao' and type = 'U')
	CREATE TABLE ProdutoIntegracao(
		ProdutoCodigo int not null,
		IntegracaoData datetime not null,
		IntegracaoStatus varchar(50) DEFAULT 'NaoIntegrado',
		IntegracaoMensagem varchar(255) null,

		CONSTRAINT PK_ProdutoIntegracao PRIMARY KEY (ProdutoCodigo,IntegracaoData),
		CONSTRAINT FK_ProdutoCodigo FOREIGN KEY (ProdutoCodigo) REFERENCES Produto(ProdutoCodigo)
	)
go