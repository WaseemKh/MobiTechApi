using Microsoft.EntityFrameworkCore.Migrations;

namespace MobiTech.Migrations
{
    public partial class network2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterNetNetWorks_lokups_LkpCountryId",
                table: "InterNetNetWorks");

            migrationBuilder.AlterColumn<int>(
                name: "LkpCountryId",
                table: "InterNetNetWorks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Subtype",
                table: "InterNetNetWorks",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InterNetNetWorks_lokups_LkpCountryId",
                table: "InterNetNetWorks",
                column: "LkpCountryId",
                principalTable: "lokups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterNetNetWorks_lokups_LkpCountryId",
                table: "InterNetNetWorks");

            migrationBuilder.DropColumn(
                name: "Subtype",
                table: "InterNetNetWorks");

            migrationBuilder.AlterColumn<int>(
                name: "LkpCountryId",
                table: "InterNetNetWorks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InterNetNetWorks_lokups_LkpCountryId",
                table: "InterNetNetWorks",
                column: "LkpCountryId",
                principalTable: "lokups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
