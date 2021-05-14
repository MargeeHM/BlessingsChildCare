using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blessings.Migrations
{
    public partial class addStaffChildLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "amount",
                table: "Payment",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "ChildLog",
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
                    table.PrimaryKey("PK_ChildLog", x => x.ChildlogId);
                    table.ForeignKey(
                        name: "FK_ChildLog_Child_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Child",
                        principalColumn: "child_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffLog",
                columns: table => new
                {
                    StafflogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(nullable: false),
                    StaffCheckIn = table.Column<TimeSpan>(nullable: false),
                    StaffCheckOut = table.Column<TimeSpan>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLog", x => x.StafflogId);
                    table.ForeignKey(
                        name: "FK_StaffLog_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildLog_ChildId",
                table: "ChildLog",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLog_StaffId",
                table: "StaffLog",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildLog");

            migrationBuilder.DropTable(
                name: "StaffLog");

            migrationBuilder.AlterColumn<double>(
                name: "amount",
                table: "Payment",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
