using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Add_TabelaMoeda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaDespesaId",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MoedaId",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Despesas",
                type: "varchar(400)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoPessoa",
                table: "Despesas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Despesas",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CategoriasDespesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CascadeMode = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasDespesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moeda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CascadeMode = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moeda", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_CategoriaDespesaId",
                table: "Despesas",
                column: "CategoriaDespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_MoedaId",
                table: "Despesas",
                column: "MoedaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_CategoriasDespesas_CategoriaDespesaId",
                table: "Despesas",
                column: "CategoriaDespesaId",
                principalTable: "CategoriasDespesas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Moeda_MoedaId",
                table: "Despesas",
                column: "MoedaId",
                principalTable: "Moeda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_CategoriasDespesas_CategoriaDespesaId",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Moeda_MoedaId",
                table: "Despesas");

            migrationBuilder.DropTable(
                name: "CategoriasDespesas");

            migrationBuilder.DropTable(
                name: "Moeda");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_CategoriaDespesaId",
                table: "Despesas");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_MoedaId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "CategoriaDespesaId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "MoedaId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "TipoPessoa",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Despesas");
        }
    }
}
