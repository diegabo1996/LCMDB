using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.WSExtractor.BD.Migrations
{
    public partial class CorreccionIP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                schema: "lcmdb",
                table: "ServiciosWindows");

            migrationBuilder.AlterColumn<string>(
                name: "IP",
                schema: "lcmdb",
                table: "RegistrosEjecucion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                schema: "lcmdb",
                table: "ServiciosWindows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "IP",
                schema: "lcmdb",
                table: "RegistrosEjecucion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
