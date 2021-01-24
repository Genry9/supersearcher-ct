using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperSearcher.DAL.Migrations
{
    public partial class remigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "allRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Term = table.Column<string>(nullable: true),
                    At = table.Column<DateTime>(nullable: false),
                    fromFolder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_allRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "allRequests");
        }
    }
}
