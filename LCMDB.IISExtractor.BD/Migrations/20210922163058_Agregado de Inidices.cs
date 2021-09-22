using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.IISExtractor.BD.Migrations
{
    public partial class AgregadodeInidices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SitiosWeb_IP_IdRegistro",
                schema: "lcmdb",
                table: "SitiosWeb",
                columns: new[] { "IP", "IdRegistro" });

            migrationBuilder.CreateIndex(
                name: "IX_GrupoAplicaciones_IP_IdRegistro",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                columns: new[] { "IP", "IdRegistro" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SitiosWeb_IP_IdRegistro",
                schema: "lcmdb",
                table: "SitiosWeb");

            migrationBuilder.DropIndex(
                name: "IX_GrupoAplicaciones_IP_IdRegistro",
                schema: "lcmdb",
                table: "GrupoAplicaciones");
        }
    }
}
