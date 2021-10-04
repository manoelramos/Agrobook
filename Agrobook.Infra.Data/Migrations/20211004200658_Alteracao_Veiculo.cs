using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alteracao_Veiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fazendas_Enderecos_EnderecoId",
                table: "Fazendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrimonios_Fazendas_FazendaId",
                table: "Patrimonios");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrimonios_Imoveis_ImovelId",
                table: "Patrimonios");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrimonios_Veiculos_VeivuloId",
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

            migrationBuilder.DropIndex(
                name: "IX_Fazendas_EnderecoId",
                table: "Fazendas");

            migrationBuilder.DropColumn(
                name: "FazendaId",
                table: "Patrimonios");

            migrationBuilder.DropColumn(
                name: "ImovelId",
                table: "Patrimonios");

            migrationBuilder.DropColumn(
                name: "VeivuloId",
                table: "Patrimonios");

            migrationBuilder.RenameColumn(
                name: "CascadeMode",
                table: "Veiculos",
                newName: "PatrimonioId");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Veiculos",
                type: "varchar(8)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Kilometragem",
                table: "Veiculos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AnoFabricao",
                table: "Veiculos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "PatrimonioId",
                table: "Imoveis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "Telefone",
                table: "Fazendas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hectare",
                table: "Fazendas",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Fazendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PatrimonioId",
                table: "Fazendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_PatrimonioId",
                table: "Veiculos",
                column: "PatrimonioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_PatrimonioId",
                table: "Imoveis",
                column: "PatrimonioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fazendas_EnderecoId",
                table: "Fazendas",
                column: "EnderecoId",
                unique: true,
                filter: "[EnderecoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fazendas_PatrimonioId",
                table: "Fazendas",
                column: "PatrimonioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fazendas_Enderecos_EnderecoId",
                table: "Fazendas",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fazendas_Patrimonios_PatrimonioId",
                table: "Fazendas",
                column: "PatrimonioId",
                principalTable: "Patrimonios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Patrimonios_PatrimonioId",
                table: "Imoveis",
                column: "PatrimonioId",
                principalTable: "Patrimonios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Patrimonios_PatrimonioId",
                table: "Veiculos",
                column: "PatrimonioId",
                principalTable: "Patrimonios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fazendas_Enderecos_EnderecoId",
                table: "Fazendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Fazendas_Patrimonios_PatrimonioId",
                table: "Fazendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Patrimonios_PatrimonioId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Patrimonios_PatrimonioId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_PatrimonioId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_PatrimonioId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_Fazendas_EnderecoId",
                table: "Fazendas");

            migrationBuilder.DropIndex(
                name: "IX_Fazendas_PatrimonioId",
                table: "Fazendas");

            migrationBuilder.DropColumn(
                name: "PatrimonioId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "PatrimonioId",
                table: "Fazendas");

            migrationBuilder.RenameColumn(
                name: "PatrimonioId",
                table: "Veiculos",
                newName: "CascadeMode");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)");

            migrationBuilder.AlterColumn<long>(
                name: "Kilometragem",
                table: "Veiculos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AnoFabricao",
                table: "Veiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FazendaId",
                table: "Patrimonios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImovelId",
                table: "Patrimonios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VeivuloId",
                table: "Patrimonios",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Telefone",
                table: "Fazendas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Hectare",
                table: "Fazendas",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Fazendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Fazendas_EnderecoId",
                table: "Fazendas",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fazendas_Enderecos_EnderecoId",
                table: "Fazendas",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrimonios_Fazendas_FazendaId",
                table: "Patrimonios",
                column: "FazendaId",
                principalTable: "Fazendas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patrimonios_Imoveis_ImovelId",
                table: "Patrimonios",
                column: "ImovelId",
                principalTable: "Imoveis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patrimonios_Veiculos_VeivuloId",
                table: "Patrimonios",
                column: "VeivuloId",
                principalTable: "Veiculos",
                principalColumn: "Id");
        }
    }
}
