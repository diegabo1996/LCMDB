using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.WSExtractor.BD.Migrations
{
    public partial class AregadoRegistroEjecucion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistrosEjecucion",
                schema: "lcmdb",
                columns: table => new
                {
                    IdRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicioID = table.Column<string>(type: "varchar(5)", nullable: true),
                    Detalle = table.Column<string>(type: "varchar(500)", nullable: true),
                    IdSegmento = table.Column<int>(type: "int", nullable: false),
                    Finalizado = table.Column<bool>(type: "bit", nullable: false),
                    FechaHoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHoraFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosEjecucion", x => x.IdRegistro);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrosEjecucion",
                schema: "lcmdb");
        }
    }
}
