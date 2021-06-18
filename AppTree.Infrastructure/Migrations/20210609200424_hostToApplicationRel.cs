using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTree.Infrastructure.Migrations
{
    public partial class hostToApplicationRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependency_Application_ApplicationId",
                schema: "dbo",
                table: "Dependency");

            migrationBuilder.DropIndex(
                name: "IX_Dependency_ApplicationId",
                schema: "dbo",
                table: "Dependency");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Dependency_ApplicationId",
                schema: "dbo",
                table: "Dependency",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependency_Application_ApplicationId",
                schema: "dbo",
                table: "Dependency",
                column: "ApplicationId",
                principalSchema: "dbo",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
