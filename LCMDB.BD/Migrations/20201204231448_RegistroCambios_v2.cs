using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class RegistroCambios_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reg_RegistroCambios",
                schema: "inv");

            migrationBuilder.CreateTable(
                name: "Reg_RegistroCambiosServidores",
                schema: "inv",
                columns: table => new
                {
                    IdCambio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServidorIdServidor = table.Column<int>(type: "int", nullable: true),
                    TipoCambio = table.Column<int>(type: "int", nullable: false),
                    AntiguoValor = table.Column<string>(type: "varchar(50)", nullable: true),
                    NuevoValor = table.Column<string>(type: "varchar(50)", nullable: true),
                    Detalles = table.Column<string>(type: "text", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reg_RegistroCambiosServidores", x => x.IdCambio);
                    table.ForeignKey(
                        name: "FK_Reg_RegistroCambiosServidores_Inv_Servidores_ServidorIdServidor",
                        column: x => x.ServidorIdServidor,
                        principalSchema: "inv",
                        principalTable: "Inv_Servidores",
                        principalColumn: "IdServidor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reg_RegistroCambiosServidores_ServidorIdServidor",
                schema: "inv",
                table: "Reg_RegistroCambiosServidores",
                column: "ServidorIdServidor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reg_RegistroCambiosServidores",
                schema: "inv");

            migrationBuilder.CreateTable(
                name: "Reg_RegistroCambios",
                schema: "inv",
                columns: table => new
                {
                    IdCambio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AntiguoValor = table.Column<string>(type: "varchar(50)", nullable: true),
                    Detalles = table.Column<string>(type: "text", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NuevoValor = table.Column<string>(type: "varchar(50)", nullable: true),
                    ServidorIdServidor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reg_RegistroCambios", x => x.IdCambio);
                    table.ForeignKey(
                        name: "FK_Reg_RegistroCambios_Inv_Servidores_ServidorIdServidor",
                        column: x => x.ServidorIdServidor,
                        principalSchema: "inv",
                        principalTable: "Inv_Servidores",
                        principalColumn: "IdServidor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reg_RegistroCambios_ServidorIdServidor",
                schema: "inv",
                table: "Reg_RegistroCambios",
                column: "ServidorIdServidor");
        }
    }
}
