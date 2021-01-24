using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperSearcher.DAL.Migrations
{
    public partial class search_history : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "allRequests",
                columns: table => new
                {
                    Term = table.Column<string>(nullable: true),
                    At = table.Column<DateTime>(nullable: false),
                    fromFolder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "allRequests");
        }
    }
}
