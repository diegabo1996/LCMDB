using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class DaletedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reg_RegistroEnLineaServidores_Inv_Servidores_IP",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores");

            migrationBuilder.DropIndex(
                name: "IX_Reg_RegistroEnLineaServidores_IP",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores");

            migrationBuilder.AlterColumn<string>(
                name: "IP",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServidorIP",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                type: "varchar(15)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reg_RegistroEnLineaServidores_ServidorIP",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                column: "ServidorIP");

            migrationBuilder.AddForeignKey(
                name: "FK_Reg_RegistroEnLineaServidores_Inv_Servidores_ServidorIP",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                column: "ServidorIP",
                principalSchema: "lcmdb",
                principalTable: "Inv_Servidores",
                principalColumn: "IP",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reg_RegistroEnLineaServidores_Inv_Servidores_ServidorIP",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores");

            migrationBuilder.DropIndex(
                name: "IX_Reg_RegistroEnLineaServidores_ServidorIP",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores");

            migrationBuilder.DropColumn(
                name: "ServidorIP",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores");

            migrationBuilder.AlterColumn<string>(
                name: "IP",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reg_RegistroEnLineaServidores_IP",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                column: "IP");

            migrationBuilder.AddForeignKey(
                name: "FK_Reg_RegistroEnLineaServidores_Inv_Servidores_IP",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                column: "IP",
                principalSchema: "lcmdb",
                principalTable: "Inv_Servidores",
                principalColumn: "IP",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
