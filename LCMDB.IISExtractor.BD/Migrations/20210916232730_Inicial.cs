using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.IISExtractor.BD.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "lcmdb");

            migrationBuilder.CreateTable(
                name: "GrupoAplicaciones",
                schema: "lcmdb",
                columns: table => new
                {
                    IdAppPool = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP = table.Column<string>(type: "varchar(15)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(250)", nullable: false),
                    CLR = table.Column<string>(type: "varchar(50)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    THTWOBits = table.Column<bool>(type: "bit", nullable: false),
                    ManagedPipeline = table.Column<string>(type: "varchar(50)", nullable: false),
                    Usuario = table.Column<string>(type: "varchar(250)", nullable: false),
                    Contrasenia = table.Column<string>(type: "varchar(500)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaHoraRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoAplicaciones", x => x.IdAppPool);
                });

            migrationBuilder.CreateTable(
                name: "SitiosWeb",
                schema: "lcmdb",
                columns: table => new
                {
                    IdSitioWeb = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAppPool = table.Column<int>(type: "int", nullable: false),
                    IP = table.Column<string>(type: "varchar(15)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(250)", nullable: false),
                    IdOnIIS = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    RutaFisica = table.Column<string>(type: "varchar(500)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaHoraRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitiosWeb", x => x.IdSitioWeb);
                    table.ForeignKey(
                        name: "FK_SitiosWeb_GrupoAplicaciones_IdAppPool",
                        column: x => x.IdAppPool,
                        principalSchema: "lcmdb",
                        principalTable: "GrupoAplicaciones",
                        principalColumn: "IdAppPool",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aplicaciones",
                schema: "lcmdb",
                columns: table => new
                {
                    IdAplicacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSitioWeb = table.Column<int>(type: "int", nullable: false),
                    IdAppPool = table.Column<int>(type: "int", nullable: false),
                    IP = table.Column<string>(type: "varchar(15)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(250)", nullable: false),
                    RutaFisica = table.Column<string>(type: "varchar(500)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaHoraRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicaciones", x => x.IdAplicacion);
                    table.ForeignKey(
                        name: "FK_Aplicaciones_GrupoAplicaciones_IdAppPool",
                        column: x => x.IdAppPool,
                        principalSchema: "lcmdb",
                        principalTable: "GrupoAplicaciones",
                        principalColumn: "IdAppPool",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Aplicaciones_SitiosWeb_IdSitioWeb",
                        column: x => x.IdSitioWeb,
                        principalSchema: "lcmdb",
                        principalTable: "SitiosWeb",
                        principalColumn: "IdSitioWeb",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Vinculantes",
                schema: "lcmdb",
                columns: table => new
                {
                    IdVinculante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSitioWeb = table.Column<int>(type: "int", nullable: false),
                    TipoEsquema = table.Column<string>(type: "varchar(10)", nullable: false),
                    IpVinculante = table.Column<string>(type: "varchar(15)", nullable: false),
                    Puerto = table.Column<string>(type: "varchar(10)", nullable: false),
                    Host = table.Column<string>(type: "varchar(250)", nullable: true),
                    FirmaCertificado = table.Column<string>(type: "varchar(100)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaHoraRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinculantes", x => x.IdVinculante);
                    table.ForeignKey(
                        name: "FK_Vinculantes_SitiosWeb_IdSitioWeb",
                        column: x => x.IdSitioWeb,
                        principalSchema: "lcmdb",
                        principalTable: "SitiosWeb",
                        principalColumn: "IdSitioWeb",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aplicaciones_IdAppPool",
                schema: "lcmdb",
                table: "Aplicaciones",
                column: "IdAppPool");

            migrationBuilder.CreateIndex(
                name: "IX_Aplicaciones_IdSitioWeb",
                schema: "lcmdb",
                table: "Aplicaciones",
                column: "IdSitioWeb");

            migrationBuilder.CreateIndex(
                name: "IX_SitiosWeb_IdAppPool",
                schema: "lcmdb",
                table: "SitiosWeb",
                column: "IdAppPool");

            migrationBuilder.CreateIndex(
                name: "IX_Vinculantes_IdSitioWeb",
                schema: "lcmdb",
                table: "Vinculantes",
                column: "IdSitioWeb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicaciones",
                schema: "lcmdb");

            migrationBuilder.DropTable(
                name: "Vinculantes",
                schema: "lcmdb");

            migrationBuilder.DropTable(
                name: "SitiosWeb",
                schema: "lcmdb");

            migrationBuilder.DropTable(
                name: "GrupoAplicaciones",
                schema: "lcmdb");
        }
    }
}
