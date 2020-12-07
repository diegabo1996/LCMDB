using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class RegistroEnLinea_V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores");

            migrationBuilder.DropColumn(
                name: "IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
