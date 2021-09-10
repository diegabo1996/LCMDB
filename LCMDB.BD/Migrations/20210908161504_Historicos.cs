using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.BD.Migrations
{
    public partial class Historicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                schema: "lcmdb",
                table: "Inv_Servidores");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                schema: "lcmdb",
                table: "Inv_PuertosServidores");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "lcmdb",
                table: "Inv_SO_Servidores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistroVolcado",
                schema: "lcmdb",
                table: "Inv_SO_Servidores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdRegistro",
                schema: "lcmdb",
                table: "Inv_SO_Servidores",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<int>(
                name: "IdRegistro",
                schema: "lcmdb",
                table: "Inv_PuertosServidores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "lcmdb",
                table: "Inv_SO_Servidores");

            migrationBuilder.DropColumn(
                name: "FechaRegistroVolcado",
                schema: "lcmdb",
                table: "Inv_SO_Servidores");

            migrationBuilder.DropColumn(
                name: "IdRegistro",
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

            migrationBuilder.DropColumn(
                name: "IdRegistro",
                schema: "lcmdb",
                table: "Inv_PuertosServidores");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                schema: "lcmdb",
                table: "Inv_Servidores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                schema: "lcmdb",
                table: "Inv_PuertosServidores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
