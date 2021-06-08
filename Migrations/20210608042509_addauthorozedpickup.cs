using Microsoft.EntityFrameworkCore.Migrations;

namespace Blessings.Migrations
{
    public partial class addauthorozedpickup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorizedPickup",
                columns: table => new
                {
                    AuthorizedPickupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(maxLength: 50, nullable: false),
                    Relation = table.Column<string>(maxLength: 25, nullable: true),
                    phone = table.Column<string>(maxLength: 10, nullable: true),
                    ChildId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizedPickup", x => x.AuthorizedPickupId);
                    table.ForeignKey(
                        name: "FK_AuthorizedPickup_Child_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Child",
                        principalColumn: "child_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizedPickup_ChildId",
                table: "AuthorizedPickup",
                column: "ChildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorizedPickup");
        }
    }
}
