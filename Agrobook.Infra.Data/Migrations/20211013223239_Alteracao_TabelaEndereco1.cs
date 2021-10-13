using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alteracao_TabelaEndereco1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CidadeNome",
                table: "Enderecos",
                newName: "Cidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "Enderecos",
                newName: "CidadeNome");
        }
    }
}
