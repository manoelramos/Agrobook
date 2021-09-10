using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrobook.Infra.Data.Migrations
{
    public partial class Update_Localidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hectare",
                table: "Talhoes",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "Sigla",
                table: "Estados",
                newName: "Uf");

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Talhoes",
                type: "varchar(400)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Paises",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Paises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Iso",
                table: "Paises",
                type: "varchar(2)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Iso3",
                table: "Paises",
                type: "varchar(3)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CodigoUf",
                table: "Estados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Regiao",
                table: "Estados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UnidadesMedida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesMedidaAgro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    UnidadesMedidaId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedidaAgro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnidadesMedidaAgro_UnidadesMedida_UnidadesMedidaId",
                        column: x => x.UnidadesMedidaId,
                        principalTable: "UnidadesMedida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesMedidaAgro_UnidadesMedidaId",
                table: "UnidadesMedidaAgro",
                column: "UnidadesMedidaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnidadesMedidaAgro");

            migrationBuilder.DropTable(
                name: "UnidadesMedida");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Talhoes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "Iso",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "Iso3",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "CodigoUf",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "Regiao",
                table: "Estados");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Talhoes",
                newName: "Hectare");

            migrationBuilder.RenameColumn(
                name: "Uf",
                table: "Estados",
                newName: "Sigla");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Paises",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");
        }
    }
}
