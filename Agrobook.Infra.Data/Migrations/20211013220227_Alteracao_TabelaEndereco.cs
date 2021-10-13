using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alteracao_TabelaEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Cidades_CidadeId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Estados_EstadoId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_CidadeId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_EstadoId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Enderecos");

            migrationBuilder.AddColumn<string>(
                name: "CidadeNome",
                table: "Enderecos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Enderecos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CidadeNome",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Enderecos");

            migrationBuilder.AddColumn<int>(
                name: "CidadeId",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_CidadeId",
                table: "Enderecos",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EstadoId",
                table: "Enderecos",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Cidades_CidadeId",
                table: "Enderecos",
                column: "CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Estados_EstadoId",
                table: "Enderecos",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id");
        }
    }
}
