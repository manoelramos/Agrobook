using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Alter_UnidadesMedidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnidadesMedidasAgro");

            migrationBuilder.DropColumn(
                name: "ValorReferencia",
                table: "Patrimonios");

            migrationBuilder.RenameColumn(
                name: "Venda",
                table: "Patrimonios",
                newName: "DataVenda");

            migrationBuilder.RenameColumn(
                name: "Compra",
                table: "Patrimonios",
                newName: "DataCompra");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Imoveis",
                newName: "Nome");

            migrationBuilder.AddColumn<int>(
                name: "UnidadeBaseId",
                table: "UnidadesMedidas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorUnidade",
                table: "UnidadesMedidas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClasseId",
                table: "Imoveis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Classses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CascadeMode = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesMedidas_UnidadeBaseId",
                table: "UnidadesMedidas",
                column: "UnidadeBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_ClasseId",
                table: "Imoveis",
                column: "ClasseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Classses_ClasseId",
                table: "Imoveis",
                column: "ClasseId",
                principalTable: "Classses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadesMedidas_UnidadesMedidas_UnidadeBaseId",
                table: "UnidadesMedidas",
                column: "UnidadeBaseId",
                principalTable: "UnidadesMedidas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Classses_ClasseId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_UnidadesMedidas_UnidadesMedidas_UnidadeBaseId",
                table: "UnidadesMedidas");

            migrationBuilder.DropTable(
                name: "Classses");

            migrationBuilder.DropIndex(
                name: "IX_UnidadesMedidas_UnidadeBaseId",
                table: "UnidadesMedidas");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_ClasseId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "UnidadeBaseId",
                table: "UnidadesMedidas");

            migrationBuilder.DropColumn(
                name: "ValorUnidade",
                table: "UnidadesMedidas");

            migrationBuilder.DropColumn(
                name: "ClasseId",
                table: "Imoveis");

            migrationBuilder.RenameColumn(
                name: "DataVenda",
                table: "Patrimonios",
                newName: "Venda");

            migrationBuilder.RenameColumn(
                name: "DataCompra",
                table: "Patrimonios",
                newName: "Compra");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Imoveis",
                newName: "Tipo");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorReferencia",
                table: "Patrimonios",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UnidadesMedidasAgro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Quantidade = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Simbolo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadesMedidasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedidasAgro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnidadesMedidasAgro_UnidadesMedidas_UnidadesMedidasId",
                        column: x => x.UnidadesMedidasId,
                        principalTable: "UnidadesMedidas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesMedidasAgro_UnidadesMedidasId",
                table: "UnidadesMedidasAgro",
                column: "UnidadesMedidasId");
        }
    }
}
