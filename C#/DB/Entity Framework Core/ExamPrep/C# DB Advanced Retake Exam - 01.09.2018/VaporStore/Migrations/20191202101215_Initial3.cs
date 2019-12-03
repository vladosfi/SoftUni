using Microsoft.EntityFrameworkCore.Migrations;

namespace VaporStore.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardType",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Cards",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "CardType",
                table: "Cards",
                nullable: false,
                defaultValue: 0);
        }
    }
}
