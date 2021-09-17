using Microsoft.EntityFrameworkCore.Migrations;

namespace LCMDB.IISExtractor.BD.Migrations
{
    public partial class AgregadoNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoEsquema",
                schema: "lcmdb",
                table: "Vinculantes",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Puerto",
                schema: "lcmdb",
                table: "Vinculantes",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "IpVinculante",
                schema: "lcmdb",
                table: "Vinculantes",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "RutaFisica",
                schema: "lcmdb",
                table: "SitiosWeb",
                type: "varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "lcmdb",
                table: "SitiosWeb",
                type: "varchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<long>(
                name: "IdOnIIS",
                schema: "lcmdb",
                table: "SitiosWeb",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IP",
                schema: "lcmdb",
                table: "SitiosWeb",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AddColumn<string>(
                name: "NombrePool",
                schema: "lcmdb",
                table: "SitiosWeb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Usuario",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                type: "varchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                type: "varchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "ManagedPipeline",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "IP",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "Contrasenia",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                type: "varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)");

            migrationBuilder.AlterColumn<string>(
                name: "CLR",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "RutaFisica",
                schema: "lcmdb",
                table: "Aplicaciones",
                type: "varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "lcmdb",
                table: "Aplicaciones",
                type: "varchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "IP",
                schema: "lcmdb",
                table: "Aplicaciones",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AddColumn<string>(
                name: "NombrePool",
                schema: "lcmdb",
                table: "Aplicaciones",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombrePool",
                schema: "lcmdb",
                table: "SitiosWeb");

            migrationBuilder.DropColumn(
                name: "NombrePool",
                schema: "lcmdb",
                table: "Aplicaciones");

            migrationBuilder.AlterColumn<string>(
                name: "TipoEsquema",
                schema: "lcmdb",
                table: "Vinculantes",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Puerto",
                schema: "lcmdb",
                table: "Vinculantes",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IpVinculante",
                schema: "lcmdb",
                table: "Vinculantes",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RutaFisica",
                schema: "lcmdb",
                table: "SitiosWeb",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "lcmdb",
                table: "SitiosWeb",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdOnIIS",
                schema: "lcmdb",
                table: "SitiosWeb",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "IP",
                schema: "lcmdb",
                table: "SitiosWeb",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Usuario",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ManagedPipeline",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IP",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contrasenia",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CLR",
                schema: "lcmdb",
                table: "GrupoAplicaciones",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RutaFisica",
                schema: "lcmdb",
                table: "Aplicaciones",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "lcmdb",
                table: "Aplicaciones",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IP",
                schema: "lcmdb",
                table: "Aplicaciones",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);
        }
    }
}
