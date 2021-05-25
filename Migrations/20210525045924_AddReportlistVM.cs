using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blessings.Migrations
{
    public partial class AddReportlistVM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportsList",
                columns: table => new
                {
                    ReportListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportsList", x => x.ReportListId);
                });

            migrationBuilder.CreateTable(
                name: "Sign_InOutChildrenVM",
                columns: table => new
                {
                    ChildlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(nullable: false),
                    CheckIn = table.Column<TimeSpan>(nullable: false),
                    CheckOut = table.Column<TimeSpan>(nullable: false),
                    ChildId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sign_InOutChildrenVM", x => x.ChildlogId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportsList");

            migrationBuilder.DropTable(
                name: "Sign_InOutChildrenVM");
        }
    }
}
