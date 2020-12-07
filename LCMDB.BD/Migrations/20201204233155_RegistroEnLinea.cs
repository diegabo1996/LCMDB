using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class RegistroEnLinea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "lcmdb");

            migrationBuilder.RenameTable(
                name: "Reg_RegistroEjecucion",
                schema: "inv",
                newName: "Reg_RegistroEjecucion",
                newSchema: "lcmdb");

            migrationBuilder.RenameTable(
                name: "Reg_RegistroCambiosServidores",
                schema: "inv",
                newName: "Reg_RegistroCambiosServidores",
                newSchema: "lcmdb");

            migrationBuilder.RenameTable(
                name: "Inv_Servidores",
                schema: "inv",
                newName: "Inv_Servidores",
                newSchema: "lcmdb");

            migrationBuilder.RenameTable(
                name: "Cnf_UsuariosEjecucion",
                schema: "inv",
                newName: "Cnf_UsuariosEjecucion",
                newSchema: "lcmdb");

            migrationBuilder.RenameTable(
                name: "Cnf_SegmentoRed",
                schema: "inv",
                newName: "Cnf_SegmentoRed",
                newSchema: "lcmdb");

            migrationBuilder.CreateTable(
                name: "Reg_RegistroEnLineaServidores",
                schema: "lcmdb",
                columns: table => new
                {
                    IdRegistroEnLinea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServidorIdServidor = table.Column<int>(type: "int", nullable: true),
                    EnLinea = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reg_RegistroEnLineaServidores", x => x.IdRegistroEnLinea);
                    table.ForeignKey(
                        name: "FK_Reg_RegistroEnLineaServidores_Inv_Servidores_ServidorIdServidor",
                        column: x => x.ServidorIdServidor,
                        principalSchema: "lcmdb",
                        principalTable: "Inv_Servidores",
                        principalColumn: "IdServidor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reg_RegistroEnLineaServidores_ServidorIdServidor",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                column: "ServidorIdServidor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reg_RegistroEnLineaServidores",
                schema: "lcmdb");

            migrationBuilder.EnsureSchema(
                name: "inv");

            migrationBuilder.RenameTable(
                name: "Reg_RegistroEjecucion",
                schema: "lcmdb",
                newName: "Reg_RegistroEjecucion",
                newSchema: "inv");

            migrationBuilder.RenameTable(
                name: "Reg_RegistroCambiosServidores",
                schema: "lcmdb",
                newName: "Reg_RegistroCambiosServidores",
                newSchema: "inv");

            migrationBuilder.RenameTable(
                name: "Inv_Servidores",
                schema: "lcmdb",
                newName: "Inv_Servidores",
                newSchema: "inv");

            migrationBuilder.RenameTable(
                name: "Cnf_UsuariosEjecucion",
                schema: "lcmdb",
                newName: "Cnf_UsuariosEjecucion",
                newSchema: "inv");

            migrationBuilder.RenameTable(
                name: "Cnf_SegmentoRed",
                schema: "lcmdb",
                newName: "Cnf_SegmentoRed",
                newSchema: "inv");
        }
    }
}
