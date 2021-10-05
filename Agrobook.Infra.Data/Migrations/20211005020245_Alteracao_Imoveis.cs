using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alteracao_Imoveis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Imoveis_FazendaId",
                table: "Imoveis");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_FazendaId",
                table: "Imoveis",
                column: "FazendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Imoveis_FazendaId",
                table: "Imoveis");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_FazendaId",
                table: "Imoveis",
                column: "FazendaId",
                unique: true,
                filter: "[FazendaId] IS NOT NULL");
        }
    }
}
