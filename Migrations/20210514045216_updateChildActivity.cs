using Microsoft.EntityFrameworkCore.Migrations;

namespace Blessings.Migrations
{
    public partial class updateChildActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "ChildActivity",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "ChildActivity");
        }
    }
}
