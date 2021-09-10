using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class HistoricosX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "lcmdb",
                table: "Inv_SO_Servidores");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                schema: "lcmdb",
                table: "Inv_SO_Servidores");

            migrationBuilder.DropColumn(
                name: "FechaRegistroVolcado",
                schema: "lcmdb",
                table: "Inv_SO_Servidores");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "lcmdb",
                table: "Inv_Servidores");

            migrationBuilder.DropColumn(
                name: "FechaRegistroVolcado",
                schema: "lcmdb",
                table: "Inv_Servidores");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "lcmdb",
                table: "Inv_PuertosServidores");

            migrationBuilder.DropColumn(
                name: "FechaRegistroVolcado",
                schema: "lcmdb",
                table: "Inv_PuertosServidores");

            migrationBuilder.CreateTable(
                name: "Hist_Inv_PuertosServidores",
                schema: "lcmdb",
                columns: table => new
                {
                    IdRegistroPuerto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPuerto = table.Column<int>(type: "int", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdRegistro = table.Column<int>(type: "int", nullable: false),
                    Puerto = table.Column<int>(type: "int", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    TipoProtocolo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(250)", nullable: true),
                    SistemOperativo = table.Column<string>(type: "varchar(250)", nullable: true),
                    Producto = table.Column<string>(type: "varchar(250)", nullable: true),
                    Version = table.Column<string>(type: "varchar(250)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRegistroVolcado = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hist_Inv_PuertosServidores", x => x.IdRegistroPuerto);
                });

            migrationBuilder.CreateTable(
                name: "Hist_Inv_Servidores",
                schema: "lcmdb",
                columns: table => new
                {
                    IdRegistroServidores = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP = table.Column<string>(type: "varchar(15)", nullable: true),
                    NombreServidor = table.Column<string>(type: "varchar(50)", nullable: false),
                    IdRegistro = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRegistroVolcado = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hist_Inv_Servidores", x => x.IdRegistroServidores);
                });

            migrationBuilder.CreateTable(
                name: "Hist_Inv_SO_Servidores",
                schema: "lcmdb",
                columns: table => new
                {
                    IdRegistroSO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSORegistro = table.Column<int>(type: "int", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdRegistro = table.Column<int>(type: "int", nullable: false),
                    Certeza = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(250)", nullable: true),
                    Familia = table.Column<string>(type: "varchar(250)", nullable: true),
                    Generacion = table.Column<string>(type: "varchar(250)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRegistroVolcado = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hist_Inv_SO_Servidores", x => x.IdRegistroSO);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hist_Inv_PuertosServidores",
                schema: "lcmdb");

            migrationBuilder.DropTable(
                name: "Hist_Inv_Servidores",
                schema: "lcmdb");

            migrationBuilder.DropTable(
                name: "Hist_Inv_SO_Servidores",
                schema: "lcmdb");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "lcmdb",
                table: "Inv_SO_Servidores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                schema: "lcmdb",
                table: "Inv_SO_Servidores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistroVolcado",
                schema: "lcmdb",
                table: "Inv_SO_Servidores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "lcmdb",
                table: "Inv_Servidores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistroVolcado",
                schema: "lcmdb",
                table: "Inv_Servidores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "lcmdb",
                table: "Inv_PuertosServidores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistroVolcado",
                schema: "lcmdb",
                table: "Inv_PuertosServidores",
                type: "datetime2",
                nullable: true);
        }
    }
}
