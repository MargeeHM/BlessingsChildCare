using Microsoft.EntityFrameworkCore.Migrations;

namespace Blessings.Migrations
{
    public partial class AddIsAbsentChildlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAbsent",
                table: "StaffLog",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAbsent",
                table: "ChildLog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAbsent",
                table: "StaffLog");

            migrationBuilder.DropColumn(
                name: "IsAbsent",
                table: "ChildLog");
        }
    }
}
