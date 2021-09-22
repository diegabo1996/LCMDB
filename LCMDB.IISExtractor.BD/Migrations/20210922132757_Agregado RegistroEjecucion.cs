using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.IISExtractor.BD.Migrations
{
    public partial class AgregadoRegistroEjecucion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                schema: "lcmdb",
                table: "SitiosWeb");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                schema: "lcmdb",
                table: "GrupoAplicaciones");

            migrationBuilder.AddColumn<int>(
                name: "IdRegistro",
                schema: "lcmdb",
                table: "SitiosWeb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdRegistro",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RegistrosEjecucion",
                schema: "lcmdb",
                columns: table => new
                {
                    IdRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicioID = table.Column<string>(type: "varchar(5)", nullable: true),
                    Detalle = table.Column<string>(type: "varchar(500)", nullable: true),
                    IP = table.Column<int>(type: "int", nullable: false),
                    Finalizado = table.Column<bool>(type: "bit", nullable: false),
                    FechaHoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHoraFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosEjecucion", x => x.IdRegistro);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SitiosWeb_IdRegistro",
                schema: "lcmdb",
                table: "SitiosWeb",
                column: "IdRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoAplicaciones_IdRegistro",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                column: "IdRegistro");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoAplicaciones_RegistrosEjecucion_IdRegistro",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                column: "IdRegistro",
                principalSchema: "lcmdb",
                principalTable: "RegistrosEjecucion",
                principalColumn: "IdRegistro",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SitiosWeb_RegistrosEjecucion_IdRegistro",
                schema: "lcmdb",
                table: "SitiosWeb",
                column: "IdRegistro",
                principalSchema: "lcmdb",
                principalTable: "RegistrosEjecucion",
                principalColumn: "IdRegistro",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoAplicaciones_RegistrosEjecucion_IdRegistro",
                schema: "lcmdb",
                table: "GrupoAplicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_SitiosWeb_RegistrosEjecucion_IdRegistro",
                schema: "lcmdb",
                table: "SitiosWeb");

            migrationBuilder.DropTable(
                name: "RegistrosEjecucion",
                schema: "lcmdb");

            migrationBuilder.DropIndex(
                name: "IX_SitiosWeb_IdRegistro",
                schema: "lcmdb",
                table: "SitiosWeb");

            migrationBuilder.DropIndex(
                name: "IX_GrupoAplicaciones_IdRegistro",
                schema: "lcmdb",
                table: "GrupoAplicaciones");

            migrationBuilder.DropColumn(
                name: "IdRegistro",
                schema: "lcmdb",
                table: "SitiosWeb");

            migrationBuilder.DropColumn(
                name: "IdRegistro",
                schema: "lcmdb",
                table: "GrupoAplicaciones");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                schema: "lcmdb",
                table: "SitiosWeb",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
