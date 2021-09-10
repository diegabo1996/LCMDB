using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class DetalleAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                schema: "lcmdb",
                table: "Reg_RegistroEjecucion",
                type: "varchar(5)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detalle",
                schema: "lcmdb",
                table: "Reg_RegistroEjecucion");
        }
    }
}
