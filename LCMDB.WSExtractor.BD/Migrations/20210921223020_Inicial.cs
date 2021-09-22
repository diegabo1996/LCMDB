using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.WSExtractor.BD.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "lcmdb");

            migrationBuilder.CreateTable(
                name: "ServiciosWindows",
                schema: "lcmdb",
                columns: table => new
                {
                    IdServicioWindows = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP = table.Column<string>(type: "varchar(15)", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(150)", nullable: true),
                    NombreCompleto = table.Column<string>(type: "varchar(500)", nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    RutaFisica = table.Column<string>(type: "varchar(500)", nullable: true),
                    ModoInicio = table.Column<string>(type: "varchar(10)", nullable: true),
                    Usuario = table.Column<string>(type: "varchar(250)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(25)", nullable: true),
                    IdProceso = table.Column<int>(type: "int", nullable: false),
                    TipoProceso = table.Column<string>(type: "varchar(50)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHoraRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosWindows", x => x.IdServicioWindows);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiciosWindows",
                schema: "lcmdb");
        }
    }
}
