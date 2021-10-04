using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alteracao_UnidadesMedidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnidadesMedidasAgro_UnidadesMedidas_UnidadesMedidaId",
                table: "UnidadesMedidasAgro");

            migrationBuilder.RenameColumn(
                name: "UnidadesMedidaId",
                table: "UnidadesMedidasAgro",
                newName: "UnidadesMedidasId");

            migrationBuilder.RenameIndex(
                name: "IX_UnidadesMedidasAgro_UnidadesMedidaId",
                table: "UnidadesMedidasAgro",
                newName: "IX_UnidadesMedidasAgro_UnidadesMedidasId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadesMedidasAgro_UnidadesMedidas_UnidadesMedidasId",
                table: "UnidadesMedidasAgro",
                column: "UnidadesMedidasId",
                principalTable: "UnidadesMedidas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnidadesMedidasAgro_UnidadesMedidas_UnidadesMedidasId",
                table: "UnidadesMedidasAgro");

            migrationBuilder.RenameColumn(
                name: "UnidadesMedidasId",
                table: "UnidadesMedidasAgro",
                newName: "UnidadesMedidaId");

            migrationBuilder.RenameIndex(
                name: "IX_UnidadesMedidasAgro_UnidadesMedidasId",
                table: "UnidadesMedidasAgro",
                newName: "IX_UnidadesMedidasAgro_UnidadesMedidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadesMedidasAgro_UnidadesMedidas_UnidadesMedidaId",
                table: "UnidadesMedidasAgro",
                column: "UnidadesMedidaId",
                principalTable: "UnidadesMedidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
