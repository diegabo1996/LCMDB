using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class InicialN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "lcmdb");

            migrationBuilder.CreateTable(
                name: "Cnf_SegmentoRed",
                schema: "lcmdb",
                columns: table => new
                {
                    IdSegmento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpRed = table.Column<string>(type: "varchar(50)", nullable: false),
                    MascaraSegmento = table.Column<string>(type: "varchar(2)", nullable: false),
                    Habilitada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cnf_SegmentoRed", x => x.IdSegmento);
                });

            migrationBuilder.CreateTable(
                name: "Cnf_UsuariosEjecucion",
                schema: "lcmdb",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dominio = table.Column<string>(type: "varchar(50)", nullable: true),
                    NombreUsuario = table.Column<string>(type: "varchar(50)", nullable: true),
                    ContraseniaUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cnf_UsuariosEjecucion", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Inv_Servidores",
                schema: "lcmdb",
                columns: table => new
                {
                    IP = table.Column<string>(type: "varchar(15)", nullable: false),
                    NombreServidor = table.Column<string>(type: "varchar(50)", nullable: false),
                    IdRegistro = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_Servidores", x => x.IP);
                });

            migrationBuilder.CreateTable(
                name: "Reg_RegistroEjecucion",
                schema: "lcmdb",
                columns: table => new
                {
                    IdRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicioID = table.Column<string>(type: "varchar(5)", nullable: true),
                    Finalizado = table.Column<bool>(type: "bit", nullable: false),
                    FechaHoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHoraFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reg_RegistroEjecucion", x => x.IdRegistro);
                });

            migrationBuilder.CreateTable(
                name: "Inv_PuertosServidores",
                schema: "lcmdb",
                columns: table => new
                {
                    IdPuerto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP = table.Column<string>(type: "varchar(15)", nullable: true),
                    Puerto = table.Column<int>(type: "int", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    TipoProtocolo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(250)", nullable: true),
                    SistemOperativo = table.Column<string>(type: "varchar(250)", nullable: true),
                    Producto = table.Column<string>(type: "varchar(250)", nullable: true),
                    Version = table.Column<string>(type: "varchar(250)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_PuertosServidores", x => x.IdPuerto);
                    table.ForeignKey(
                        name: "FK_Inv_PuertosServidores_Inv_Servidores_IP",
                        column: x => x.IP,
                        principalSchema: "lcmdb",
                        principalTable: "Inv_Servidores",
                        principalColumn: "IP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inv_SO_Servidores",
                schema: "lcmdb",
                columns: table => new
                {
                    IdSORegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP = table.Column<string>(type: "varchar(15)", nullable: true),
                    Certeza = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(250)", nullable: true),
                    Familia = table.Column<string>(type: "varchar(250)", nullable: true),
                    Generacion = table.Column<string>(type: "varchar(250)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_SO_Servidores", x => x.IdSORegistro);
                    table.ForeignKey(
                        name: "FK_Inv_SO_Servidores_Inv_Servidores_IP",
                        column: x => x.IP,
                        principalSchema: "lcmdb",
                        principalTable: "Inv_Servidores",
                        principalColumn: "IP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reg_RegistroCambiosServidores",
                schema: "lcmdb",
                columns: table => new
                {
                    IdCambio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCambio = table.Column<int>(type: "int", nullable: false),
                    AntiguoValor = table.Column<string>(type: "varchar(50)", nullable: true),
                    NuevoValor = table.Column<string>(type: "varchar(50)", nullable: true),
                    Detalles = table.Column<string>(type: "text", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServidorIP = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reg_RegistroCambiosServidores", x => x.IdCambio);
                    table.ForeignKey(
                        name: "FK_Reg_RegistroCambiosServidores_Inv_Servidores_ServidorIP",
                        column: x => x.ServidorIP,
                        principalSchema: "lcmdb",
                        principalTable: "Inv_Servidores",
                        principalColumn: "IP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reg_RegistroEnLineaServidores",
                schema: "lcmdb",
                columns: table => new
                {
                    IdRegistroEnLinea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnLinea = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IP = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reg_RegistroEnLineaServidores", x => x.IdRegistroEnLinea);
                    table.ForeignKey(
                        name: "FK_Reg_RegistroEnLineaServidores_Inv_Servidores_IP",
                        column: x => x.IP,
                        principalSchema: "lcmdb",
                        principalTable: "Inv_Servidores",
                        principalColumn: "IP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inv_PuertosServidores_IP",
                schema: "lcmdb",
                table: "Inv_PuertosServidores",
                column: "IP");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_SO_Servidores_IP",
                schema: "lcmdb",
                table: "Inv_SO_Servidores",
                column: "IP");

            migrationBuilder.CreateIndex(
                name: "IX_Reg_RegistroCambiosServidores_ServidorIP",
                schema: "lcmdb",
                table: "Reg_RegistroCambiosServidores",
                column: "ServidorIP");

            migrationBuilder.CreateIndex(
                name: "IX_Reg_RegistroEnLineaServidores_IP",
                schema: "lcmdb",
                table: "Reg_RegistroEnLineaServidores",
                column: "IP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cnf_SegmentoRed",
                schema: "lcmdb");

            migrationBuilder.DropTable(
                name: "Cnf_UsuariosEjecucion",
                schema: "lcmdb");

            migrationBuilder.DropTable(
                name: "Inv_PuertosServidores",
                schema: "lcmdb");

            migrationBuilder.DropTable(
                name: "Inv_SO_Servidores",
                schema: "lcmdb");

            migrationBuilder.DropTable(
                name: "Reg_RegistroCambiosServidores",
                schema: "lcmdb");

            migrationBuilder.DropTable(
                name: "Reg_RegistroEjecucion",
                schema: "lcmdb");

            migrationBuilder.DropTable(
                name: "Reg_RegistroEnLineaServidores",
                schema: "lcmdb");

            migrationBuilder.DropTable(
                name: "Inv_Servidores",
                schema: "lcmdb");
        }
    }
}
