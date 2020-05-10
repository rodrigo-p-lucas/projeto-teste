using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoTeste.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProdutoDescricao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    ProdutoValor = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    ProdutoQtdEstoque = table.Column<decimal>(type: "decimal(10,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
