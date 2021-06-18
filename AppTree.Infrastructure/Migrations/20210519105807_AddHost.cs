using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTree.Infrastructure.Migrations
{
    public partial class AddHost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Host",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostName = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Host", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Host",
                columns: new[] { "Id", "Domain", "HostName", "Location", "Summary" },
                values: new object[,]
                {
                    { 1, "agepartnership.com", "PRAPI02", "OnPrem", null },
                    { 2, "agepartnership.com", "PRAPI11", "OnPrem", null },
                    { 3, "agepartnership.com", "PRAPI21", "OnPrem", null },
                    { 4, "agepartnership.com", "PRAPI04", "Azure", null },
                    { 5, "agepartnership.com", "PRAPI05", "Azure", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Host",
                schema: "dbo");
        }
    }
}
