using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class PuertosServidores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inv_PuertosServidores",
                schema: "lcmdb",
                columns: table => new
                {
                    IdPuerto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdServidor = table.Column<int>(type: "int", nullable: false),
                    Puerto = table.Column<short>(type: "smallint", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    TipoProtocolo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(25)", nullable: true),
                    SistemOperativo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Producto = table.Column<string>(type: "varchar(75)", nullable: true),
                    Version = table.Column<string>(type: "varchar(20)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_PuertosServidores", x => x.IdPuerto);
                    table.ForeignKey(
                        name: "FK_Inv_PuertosServidores_Inv_Servidores_IdServidor",
                        column: x => x.IdServidor,
                        principalSchema: "lcmdb",
                        principalTable: "Inv_Servidores",
                        principalColumn: "IdServidor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inv_PuertosServidores_IdServidor",
                schema: "lcmdb",
                table: "Inv_PuertosServidores",
                column: "IdServidor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inv_PuertosServidores",
                schema: "lcmdb");
        }
    }
}
