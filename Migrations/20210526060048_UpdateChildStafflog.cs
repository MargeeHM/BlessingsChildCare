using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blessings.Migrations
{
    public partial class UpdateChildStafflog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAbsent",
                table: "StaffLog");

            migrationBuilder.DropColumn(
                name: "IsAbsent",
                table: "ChildLog");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckOut",
                table: "Sign_InOutChildrenVM",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckIn",
                table: "Sign_InOutChildrenVM",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAbsent",
                table: "StaffLog",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "CheckOut",
                table: "Sign_InOutChildrenVM",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "CheckIn",
                table: "Sign_InOutChildrenVM",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<bool>(
                name: "IsAbsent",
                table: "ChildLog",
                type: "bit",
                nullable: true);
        }
    }
}
