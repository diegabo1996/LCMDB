using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.IISExtractor.BD.Migrations
{
    public partial class CorreccionEsquema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoEsquema",
                schema: "lcmdb",
                table: "Vinculantes",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoEsquema",
                schema: "lcmdb",
                table: "Vinculantes",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);
        }
    }
}
