using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class SegmentoAdd_modif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdSegmento",
                schema: "lcmdb",
                table: "Reg_RegistroEjecucion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdSegmento",
                schema: "lcmdb",
                table: "Reg_RegistroEjecucion");
        }
    }
}
