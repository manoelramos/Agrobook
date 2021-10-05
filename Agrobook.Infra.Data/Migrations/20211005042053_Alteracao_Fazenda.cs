using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alteracao_Fazenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fazendas_Patrimonios_PatrimonioId",
                table: "Fazendas");

            migrationBuilder.AddForeignKey(
                name: "FK_Fazendas_Patrimonios_PatrimonioId",
                table: "Fazendas",
                column: "PatrimonioId",
                principalTable: "Patrimonios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fazendas_Patrimonios_PatrimonioId",
                table: "Fazendas");

            migrationBuilder.AddForeignKey(
                name: "FK_Fazendas_Patrimonios_PatrimonioId",
                table: "Fazendas",
                column: "PatrimonioId",
                principalTable: "Patrimonios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
