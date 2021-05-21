using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTree.Infrastructure.Migrations
{
    public partial class AddHostIdToAppEnvironment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HostId",
                schema: "dbo",
                table: "ApplicationEnvironment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEnvironment_HostId",
                schema: "dbo",
                table: "ApplicationEnvironment",
                column: "HostId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationEnvironment_Host_HostId",
                schema: "dbo",
                table: "ApplicationEnvironment");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationEnvironment_HostId",
                schema: "dbo",
                table: "ApplicationEnvironment");

            migrationBuilder.DropColumn(
                name: "HostId",
                schema: "dbo",
                table: "ApplicationEnvironment");
        }
    }
}
