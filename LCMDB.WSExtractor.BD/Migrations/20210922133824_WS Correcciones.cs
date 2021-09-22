using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.WSExtractor.BD.Migrations
{
    public partial class WSCorrecciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdSegmento",
                schema: "lcmdb",
                table: "RegistrosEjecucion",
                newName: "IP");

            migrationBuilder.AddColumn<int>(
                name: "IdRegistro",
                schema: "lcmdb",
                table: "ServiciosWindows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosWindows_IdRegistro",
                schema: "lcmdb",
                table: "ServiciosWindows",
                column: "IdRegistro");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiciosWindows_RegistrosEjecucion_IdRegistro",
                schema: "lcmdb",
                table: "ServiciosWindows",
                column: "IdRegistro",
                principalSchema: "lcmdb",
                principalTable: "RegistrosEjecucion",
                principalColumn: "IdRegistro",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiciosWindows_RegistrosEjecucion_IdRegistro",
                schema: "lcmdb",
                table: "ServiciosWindows");

            migrationBuilder.DropIndex(
                name: "IX_ServiciosWindows_IdRegistro",
                schema: "lcmdb",
                table: "ServiciosWindows");

            migrationBuilder.DropColumn(
                name: "IdRegistro",
                schema: "lcmdb",
                table: "ServiciosWindows");

            migrationBuilder.RenameColumn(
                name: "IP",
                schema: "lcmdb",
                table: "RegistrosEjecucion",
                newName: "IdSegmento");
        }
    }
}
