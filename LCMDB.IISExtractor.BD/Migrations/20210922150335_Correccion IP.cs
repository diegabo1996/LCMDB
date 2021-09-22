using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.IISExtractor.BD.Migrations
{
    public partial class CorreccionIP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IP",
                schema: "lcmdb",
                table: "RegistrosEjecucion",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IP",
                schema: "lcmdb",
                table: "RegistrosEjecucion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);
        }
    }
}
