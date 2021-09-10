using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class DetalleAdd_modif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Detalle",
                schema: "lcmdb",
                table: "Reg_RegistroEjecucion",
                type: "varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Detalle",
                schema: "lcmdb",
                table: "Reg_RegistroEjecucion",
                type: "varchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldNullable: true);
        }
    }
}
