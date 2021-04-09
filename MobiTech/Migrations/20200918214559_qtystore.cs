using Microsoft.EntityFrameworkCore.Migrations;

namespace MobiTech.Migrations
{
    public partial class qtystore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayPrice",
                table: "Stors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "Stors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayPrice",
                table: "Stors");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "Stors");
        }
    }
}
