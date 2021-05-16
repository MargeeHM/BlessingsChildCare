using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Blessings.Migrations
{
    public partial class addpaymaneVmAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentVM",
                columns: table => new
                {
                    PaymentListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymenttId = table.Column<int>(nullable: false),
                    ChildFirstName = table.Column<string>(maxLength: 50, nullable: false),
                    ChildBirthdate = table.Column<DateTime>(nullable: false),
                    Course = table.Column<string>(maxLength: 50, nullable: false),
                    RoomNo = table.Column<string>(maxLength: 10, nullable: false),
                    EnrollmentDate = table.Column<DateTime>(nullable: false),
                    PaymentType = table.Column<string>(maxLength: 50, nullable: false),
                    PaymentAmount = table.Column<float>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: false),
                    EnrollmentId = table.Column<int>(nullable: false),
                    ChildId = table.Column<int>(nullable: true)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentVM", x => x.PaymentListId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentVM");
        }
    }
}
