using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blessings.Migrations
{
    public partial class foreignkeyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "CourseFees",
                columns: table => new
                {
                    coursefees_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(maxLength: 50, nullable: false),
                    Fees = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFees", x => x.coursefees_id);
                });

         }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
          

            migrationBuilder.DropTable(
                name: "CourseFees");
        }
    }
}
