using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTree.Infrastructure.Migrations
{
    public partial class MakeHostIdRequiredOnAppEnv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationEnvironment_Host_HostId",
                schema: "dbo",
                table: "ApplicationEnvironment");

            migrationBuilder.DropColumn(
                name: "HostName",
                schema: "dbo",
                table: "ApplicationEnvironment");

            migrationBuilder.AlterColumn<int>(
                name: "HostId",
                schema: "dbo",
                table: "ApplicationEnvironment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEnvironment_Host_HostId",
                schema: "dbo",
                table: "ApplicationEnvironment",
                column: "HostId",
                principalSchema: "dbo",
                principalTable: "Host",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationEnvironment_Host_HostId",
                schema: "dbo",
                table: "ApplicationEnvironment");

            migrationBuilder.AlterColumn<int>(
                name: "HostId",
                schema: "dbo",
                table: "ApplicationEnvironment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "HostName",
                schema: "dbo",
                table: "ApplicationEnvironment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEnvironment_Host_HostId",
                schema: "dbo",
                table: "ApplicationEnvironment",
                column: "HostId",
                principalSchema: "dbo",
                principalTable: "Host",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
