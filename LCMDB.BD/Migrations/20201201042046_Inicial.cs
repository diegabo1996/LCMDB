using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "inv");

            migrationBuilder.CreateTable(
                name: "Cnf_SegmentoRed",
                schema: "inv",
                columns: table => new
                {
                    IdSegmento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpRed = table.Column<string>(type: "varchar(50)", nullable: false),
                    MascaraSegmento = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cnf_SegmentoRed", x => x.IdSegmento);
                });

            migrationBuilder.CreateTable(
                name: "Inv_Servidores",
                schema: "inv",
                columns: table => new
                {
                    IdServidor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreServidor = table.Column<string>(type: "varchar(50)", nullable: false),
                    IP = table.Column<string>(type: "varchar(15)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_Servidores", x => x.IdServidor);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cnf_SegmentoRed",
                schema: "inv");

            migrationBuilder.DropTable(
                name: "Inv_Servidores",
                schema: "inv");
        }
    }
}
