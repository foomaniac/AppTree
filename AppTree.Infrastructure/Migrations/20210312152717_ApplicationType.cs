using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTree.Infrastructure.Migrations
{
    public partial class ApplicationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationTypeId",
                schema: "dbo",
                table: "Application",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationType", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ApplicationType",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Web Page" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ApplicationType",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "API" });

            migrationBuilder.CreateIndex(
                name: "IX_Application_ApplicationTypeId",
                schema: "dbo",
                table: "Application",
                column: "ApplicationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_ApplicationType_ApplicationTypeId",
                schema: "dbo",
                table: "Application",
                column: "ApplicationTypeId",
                principalSchema: "dbo",
                principalTable: "ApplicationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_ApplicationType_ApplicationTypeId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropTable(
                name: "ApplicationType",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Application_ApplicationTypeId",
                schema: "dbo",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "ApplicationTypeId",
                schema: "dbo",
                table: "Application");
        }
    }
}
