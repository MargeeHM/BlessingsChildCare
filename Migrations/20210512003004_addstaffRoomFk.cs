using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blessings.Migrations
{
    public partial class addstaffRoomFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "EnrollmentViewModel",
                columns: table => new
                {
                    EnrollmentListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollmentId = table.Column<int>(nullable: false),
                    ChildFirstName = table.Column<string>(maxLength: 50, nullable: false),
                    ChildBirthdate = table.Column<DateTime>(nullable: false),
                    Course = table.Column<string>(maxLength: 50, nullable: false),
                    RoomNo = table.Column<string>(maxLength: 10, nullable: false),
                    EnrollmentDate = table.Column<DateTime>(nullable: false),
                    ChildId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentViewModel", x => x.EnrollmentListId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNo = table.Column<string>(maxLength: 10, nullable: false),
                    Course = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                });

            
        

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            

            migrationBuilder.DropTable(
                name: "EnrollmentViewModel");

         

            migrationBuilder.DropTable(
                name: "Room");

        }
    }
}
