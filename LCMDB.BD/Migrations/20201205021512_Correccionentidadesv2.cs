using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class Correccionentidadesv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reg_RegistroCambiosServidores_Inv_Servidores_ServidorIdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Reg_RegistroEnLineaServidores_Inv_Servidores_ServidorIdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores");

            migrationBuilder.DropIndex(
                name: "IX_Reg_RegistroEnLineaServidores_ServidorIdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores");

            migrationBuilder.DropIndex(
                name: "IX_Reg_RegistroCambiosServidores_ServidorIdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores");

            migrationBuilder.DropColumn(
                name: "IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores");

            migrationBuilder.DropColumn(
                name: "ServidorIdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores");

            migrationBuilder.DropColumn(
                name: "IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores");

            migrationBuilder.DropColumn(
                name: "ServidorIdServidor",
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
                name: "ServidorIdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServidorIdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reg_RegistroEnLineaServidores_ServidorIdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                column: "ServidorIdServidor");

            migrationBuilder.CreateIndex(
                name: "IX_Reg_RegistroCambiosServidores_ServidorIdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores",
                column: "ServidorIdServidor");

            migrationBuilder.AddForeignKey(
                name: "FK_Reg_RegistroCambiosServidores_Inv_Servidores_ServidorIdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores",
                column: "ServidorIdServidor",
                principalSchema: "lcmdb",
                principalTable: "Inv_Servidores",
                principalColumn: "IdServidor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reg_RegistroEnLineaServidores_Inv_Servidores_ServidorIdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                column: "ServidorIdServidor",
                principalSchema: "lcmdb",
                principalTable: "Inv_Servidores",
                principalColumn: "IdServidor",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
