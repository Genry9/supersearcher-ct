using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperSearcher.DAL.Migrations
{
    public partial class add_user_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "allRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "allRequests");
        }
    }
}
