using Microsoft.EntityFrameworkCore.Migrations;

namespace Blessings.Migrations
{
    public partial class addcourseFeeAndFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnrollmentId",
                table: "Payment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseFeeId",
                table: "Enrollment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseFees",
                columns: table => new
                {
                    CourseFeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course = table.Column<string>(maxLength: 50, nullable: false),
                    Fee = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFees", x => x.CourseFeeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_EnrollmentId",
                table: "Payment",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseFeeId",
                table: "Enrollment",
                column: "CourseFeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_CourseFees_CourseFeeId",
                table: "Enrollment",
                column: "CourseFeeId",
                principalTable: "CourseFees",
                principalColumn: "CourseFeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Enrollment_EnrollmentId",
                table: "Payment",
                column: "EnrollmentId",
                principalTable: "Enrollment",
                principalColumn: "enrollment_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_CourseFees_CourseFeeId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Enrollment_EnrollmentId",
                table: "Payment");

            migrationBuilder.DropTable(
                name: "CourseFees");

            migrationBuilder.DropIndex(
                name: "IX_Payment_EnrollmentId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_CourseFeeId",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "EnrollmentId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CourseFeeId",
                table: "Enrollment");
        }
    }
}
