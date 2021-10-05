using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alteracao_Contratacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Patrimonios_PatrimonioId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Juridicas");

            migrationBuilder.DropColumn(
                name: "Funcao",
                table: "Fisicas");

            migrationBuilder.DropColumn(
                name: "NomeMae",
                table: "Fisicas");

            migrationBuilder.DropColumn(
                name: "NomePai",
                table: "Fisicas");

            migrationBuilder.DropColumn(
                name: "Instituicao",
                table: "DadosBancarios");

            migrationBuilder.AddColumn<int>(
                name: "FazendaId",
                table: "Imoveis",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Banco",
                table: "DadosBancarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoRelacao",
                table: "Associados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_FazendaId",
                table: "Imoveis",
                column: "FazendaId",
                unique: true,
                filter: "[FazendaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Fazendas_FazendaId",
                table: "Imoveis",
                column: "FazendaId",
                principalTable: "Fazendas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Patrimonios_PatrimonioId",
                table: "Imoveis",
                column: "PatrimonioId",
                principalTable: "Patrimonios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Fazendas_FazendaId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Patrimonios_PatrimonioId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_FazendaId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "FazendaId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "TipoRelacao",
                table: "Associados");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Juridicas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Funcao",
                table: "Fisicas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeMae",
                table: "Fisicas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomePai",
                table: "Fisicas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Banco",
                table: "DadosBancarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instituicao",
                table: "DadosBancarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Patrimonios_PatrimonioId",
                table: "Imoveis",
                column: "PatrimonioId",
                principalTable: "Patrimonios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
