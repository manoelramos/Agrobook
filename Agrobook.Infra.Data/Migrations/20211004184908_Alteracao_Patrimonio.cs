using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alteracao_Patrimonio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patrimonios_Organizacoes_OrganizacaoId",
                table: "Patrimonios");

            migrationBuilder.DropIndex(
                name: "IX_Patrimonios_FazendaId",
                table: "Patrimonios");

            migrationBuilder.DropIndex(
                name: "IX_Patrimonios_ImovelId",
                table: "Patrimonios");

            migrationBuilder.DropIndex(
                name: "IX_Patrimonios_VeivuloId",
                table: "Patrimonios");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Venda",
                table: "Patrimonios",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "VeivuloId",
                table: "Patrimonios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorVenda",
                table: "Patrimonios",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorNovo",
                table: "Patrimonios",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorCompra",
                table: "Patrimonios",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxaDepreciacaoAnual",
                table: "Patrimonios",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizacaoId",
                table: "Patrimonios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "NumeroNotaFical",
                table: "Patrimonios",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ImovelId",
                table: "Patrimonios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FazendaId",
                table: "Patrimonios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fabricacao",
                table: "Patrimonios",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ExpectativaUso",
                table: "Patrimonios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Compra",
                table: "Patrimonios",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_FazendaId",
                table: "Patrimonios",
                column: "FazendaId",
                unique: true,
                filter: "[FazendaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_ImovelId",
                table: "Patrimonios",
                column: "ImovelId",
                unique: true,
                filter: "[ImovelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_VeivuloId",
                table: "Patrimonios",
                column: "VeivuloId",
                unique: true,
                filter: "[VeivuloId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Patrimonios_Organizacoes_OrganizacaoId",
                table: "Patrimonios",
                column: "OrganizacaoId",
                principalTable: "Organizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patrimonios_Organizacoes_OrganizacaoId",
                table: "Patrimonios");

            migrationBuilder.DropIndex(
                name: "IX_Patrimonios_FazendaId",
                table: "Patrimonios");

            migrationBuilder.DropIndex(
                name: "IX_Patrimonios_ImovelId",
                table: "Patrimonios");

            migrationBuilder.DropIndex(
                name: "IX_Patrimonios_VeivuloId",
                table: "Patrimonios");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Venda",
                table: "Patrimonios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VeivuloId",
                table: "Patrimonios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorVenda",
                table: "Patrimonios",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorNovo",
                table: "Patrimonios",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorCompra",
                table: "Patrimonios",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxaDepreciacaoAnual",
                table: "Patrimonios",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizacaoId",
                table: "Patrimonios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NumeroNotaFical",
                table: "Patrimonios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImovelId",
                table: "Patrimonios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FazendaId",
                table: "Patrimonios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fabricacao",
                table: "Patrimonios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExpectativaUso",
                table: "Patrimonios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Compra",
                table: "Patrimonios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_FazendaId",
                table: "Patrimonios",
                column: "FazendaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_ImovelId",
                table: "Patrimonios",
                column: "ImovelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_VeivuloId",
                table: "Patrimonios",
                column: "VeivuloId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrimonios_Organizacoes_OrganizacaoId",
                table: "Patrimonios",
                column: "OrganizacaoId",
                principalTable: "Organizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
