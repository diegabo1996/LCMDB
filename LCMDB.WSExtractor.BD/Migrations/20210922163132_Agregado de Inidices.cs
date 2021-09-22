using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.WSExtractor.BD.Migrations
{
    public partial class AgregadodeInidices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ServiciosWindows_IP_IdRegistro",
                schema: "lcmdb",
                table: "ServiciosWindows",
                columns: new[] { "IP", "IdRegistro" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiciosWindows_IP_IdRegistro",
                schema: "lcmdb",
                table: "ServiciosWindows");
        }
    }
}
