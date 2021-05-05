using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTree.Infrastructure.Migrations
{
    public partial class applicationEnvironmentRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationEnvironment_Application_ApplicationId",
                table: "ApplicationEnvironment");

            migrationBuilder.RenameTable(
                name: "ApplicationEnvironment",
                newName: "ApplicationEnvironment",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationId",
                schema: "dbo",
                table: "ApplicationEnvironment",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEnvironment_Application_ApplicationId",
                schema: "dbo",
                table: "ApplicationEnvironment",
                column: "ApplicationId",
                principalSchema: "dbo",
                principalTable: "Application",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationEnvironment_Application_ApplicationId",
                schema: "dbo",
                table: "ApplicationEnvironment");

            migrationBuilder.RenameTable(
                name: "ApplicationEnvironment",
                schema: "dbo",
                newName: "ApplicationEnvironment");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationId",
                table: "ApplicationEnvironment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEnvironment_Application_ApplicationId",
                table: "ApplicationEnvironment",
                column: "ApplicationId",
                principalSchema: "dbo",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
