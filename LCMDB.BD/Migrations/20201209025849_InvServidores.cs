using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class InvServidores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inv_SO_Servidores",
                schema: "lcmdb",
                columns: table => new
                {
                    IdRegSO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdServidor = table.Column<int>(type: "int", nullable: false),
                    Certeza = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(250)", nullable: true),
                    Familia = table.Column<string>(type: "varchar(250)", nullable: true),
                    Generacion = table.Column<string>(type: "varchar(250)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_SO_Servidores", x => x.IdRegSO);
                    table.ForeignKey(
                        name: "FK_Inv_SO_Servidores_Inv_Servidores_IdServidor",
                        column: x => x.IdServidor,
                        principalSchema: "lcmdb",
                        principalTable: "Inv_Servidores",
                        principalColumn: "IdServidor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inv_SO_Servidores_IdServidor",
                schema: "lcmdb",
                table: "Inv_SO_Servidores",
                column: "IdServidor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inv_SO_Servidores",
                schema: "lcmdb");
        }
    }
}
