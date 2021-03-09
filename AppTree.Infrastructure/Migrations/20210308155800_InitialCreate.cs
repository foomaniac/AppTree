using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTree.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Application",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Repository = table.Column<string>(type: "nvarchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dependency",
                schema: "dbo",
                columns: table => new
                {
                    ParentApplicationId = table.Column<int>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependency", x => new { x.ParentApplicationId, x.ApplicationId });
                    table.ForeignKey(
                        name: "FK_Dependency_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dependency_Application_ParentApplicationId",
                        column: x => x.ParentApplicationId,
                        principalSchema: "dbo",
                        principalTable: "Application",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependency_ApplicationId",
                schema: "dbo",
                table: "Dependency",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependency",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Application",
                schema: "dbo");
        }
    }
}
