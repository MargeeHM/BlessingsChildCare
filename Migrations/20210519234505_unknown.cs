using Microsoft.EntityFrameworkCore.Migrations;

namespace Blessings.Migrations
{
    public partial class unknown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DashBoradViewModeldashboardvmId",
                table: "Child",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DashBoradViewModel",
                columns: table => new
                {
                    dashboardvmId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Childrens = table.Column<int>(nullable: false),
                    Staffs = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<float>(nullable: false),
                    DueAmount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashBoradViewModel", x => x.dashboardvmId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Child_DashBoradViewModeldashboardvmId",
                table: "Child",
                column: "DashBoradViewModeldashboardvmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Child_DashBoradViewModel_DashBoradViewModeldashboardvmId",
                table: "Child",
                column: "DashBoradViewModeldashboardvmId",
                principalTable: "DashBoradViewModel",
                principalColumn: "dashboardvmId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Child_DashBoradViewModel_DashBoradViewModeldashboardvmId",
                table: "Child");

            migrationBuilder.DropTable(
                name: "DashBoradViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Child_DashBoradViewModeldashboardvmId",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "DashBoradViewModeldashboardvmId",
                table: "Child");
        }
    }
}
