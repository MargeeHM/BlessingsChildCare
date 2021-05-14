using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blessings.Migrations
{
    public partial class addChildActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChildActivity",
                columns: table => new
                {
                    ChildActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activitytime = table.Column<DateTime>(nullable: false),
                    ActivityName = table.Column<string>(maxLength: 100, nullable: false),
                    ChildId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildActivity", x => x.ChildActivityId);
                    table.ForeignKey(
                        name: "FK_ChildActivity_Child_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Child",
                        principalColumn: "child_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildActivity_ChildId",
                table: "ChildActivity",
                column: "ChildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildActivity");
        }
    }
}
