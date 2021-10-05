using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alteracao_VeiculoFazenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classificacao",
                table: "Patrimonios");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Patrimonios");

            migrationBuilder.DropColumn(
                name: "Fabricacao",
                table: "Patrimonios");

            migrationBuilder.DropColumn(
                name: "Identificacao",
                table: "Patrimonios");

            migrationBuilder.DropColumn(
                name: "TaxaDepreciacaoAnual",
                table: "Patrimonios");

            migrationBuilder.RenameColumn(
                name: "Kilometragem",
                table: "Veiculos",
                newName: "KilometragemVenda");

            migrationBuilder.RenameColumn(
                name: "ValorNovo",
                table: "Patrimonios",
                newName: "ValorReferencia");

            migrationBuilder.AddColumn<string>(
                name: "EstadoConservacao",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "KilometragemCompra",
                table: "Veiculos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxaDepreciacaoAnual",
                table: "Veiculos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxaValorizacaoAnual",
                table: "Fazendas",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoConservacao",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "KilometragemCompra",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "TaxaDepreciacaoAnual",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "TaxaValorizacaoAnual",
                table: "Fazendas");

            migrationBuilder.RenameColumn(
                name: "KilometragemVenda",
                table: "Veiculos",
                newName: "Kilometragem");

            migrationBuilder.RenameColumn(
                name: "ValorReferencia",
                table: "Patrimonios",
                newName: "ValorNovo");

            migrationBuilder.AddColumn<string>(
                name: "Classificacao",
                table: "Patrimonios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Patrimonios",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fabricacao",
                table: "Patrimonios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Identificacao",
                table: "Patrimonios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxaDepreciacaoAnual",
                table: "Patrimonios",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
