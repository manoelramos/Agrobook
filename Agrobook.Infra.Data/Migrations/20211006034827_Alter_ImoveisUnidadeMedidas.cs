using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alter_ImoveisUnidadeMedidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Enderecos_EnderecoId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "UnidadeMedidaArea",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "UnidadeMedidaCapacidade",
                table: "Imoveis");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Imoveis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Area",
                table: "Imoveis",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AddColumn<int>(
                name: "UnidadeMedidaAreaId",
                table: "Imoveis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnidadeMedidaCapacidadeId",
                table: "Imoveis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_UnidadeMedidaAreaId",
                table: "Imoveis",
                column: "UnidadeMedidaAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_UnidadeMedidaCapacidadeId",
                table: "Imoveis",
                column: "UnidadeMedidaCapacidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Enderecos_EnderecoId",
                table: "Imoveis",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_UnidadesMedidas_UnidadeMedidaAreaId",
                table: "Imoveis",
                column: "UnidadeMedidaAreaId",
                principalTable: "UnidadesMedidas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_UnidadesMedidas_UnidadeMedidaCapacidadeId",
                table: "Imoveis",
                column: "UnidadeMedidaCapacidadeId",
                principalTable: "UnidadesMedidas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Enderecos_EnderecoId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_UnidadesMedidas_UnidadeMedidaAreaId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_UnidadesMedidas_UnidadeMedidaCapacidadeId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_UnidadeMedidaAreaId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_UnidadeMedidaCapacidadeId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "UnidadeMedidaAreaId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "UnidadeMedidaCapacidadeId",
                table: "Imoveis");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Imoveis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Area",
                table: "Imoveis",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnidadeMedidaArea",
                table: "Imoveis",
                type: "varchar(4)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnidadeMedidaCapacidade",
                table: "Imoveis",
                type: "varchar(4)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Enderecos_EnderecoId",
                table: "Imoveis",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
