using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class Correccionentidadesv6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Reg_RegistroEnLineaServidores_IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                column: "IdServidor");

            migrationBuilder.CreateIndex(
                name: "IX_Reg_RegistroCambiosServidores_IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores",
                column: "IdServidor");

            migrationBuilder.AddForeignKey(
                name: "FK_Reg_RegistroCambiosServidores_Inv_Servidores_IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores",
                column: "IdServidor",
                principalSchema: "lcmdb",
                principalTable: "Inv_Servidores",
                principalColumn: "IdServidor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reg_RegistroEnLineaServidores_Inv_Servidores_IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                column: "IdServidor",
                principalSchema: "lcmdb",
                principalTable: "Inv_Servidores",
                principalColumn: "IdServidor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reg_RegistroCambiosServidores_Inv_Servidores_IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Reg_RegistroEnLineaServidores_Inv_Servidores_IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores");

            migrationBuilder.DropIndex(
                name: "IX_Reg_RegistroEnLineaServidores_IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores");

            migrationBuilder.DropIndex(
                name: "IX_Reg_RegistroCambiosServidores_IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores");

            migrationBuilder.DropColumn(
                name: "IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores");

            migrationBuilder.DropColumn(
                name: "IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores");
        }
    }
}
