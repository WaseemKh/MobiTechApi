using Microsoft.EntityFrameworkCore.Migrations;

namespace MobiTech.Migrations
{
    public partial class addfornetwork1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterNetNetWorks_lokups_LkpCountryId",
                table: "InterNetNetWorks");

            migrationBuilder.AlterColumn<int>(
                name: "LkpCountryId",
                table: "InterNetNetWorks",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "InterNetNetWorks",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InterNetNetWorks_lokups_LkpCountryId",
                table: "InterNetNetWorks",
                column: "LkpCountryId",
                principalTable: "lokups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterNetNetWorks_lokups_LkpCountryId",
                table: "InterNetNetWorks");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "InterNetNetWorks");

            migrationBuilder.AlterColumn<int>(
                name: "LkpCountryId",
                table: "InterNetNetWorks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_InterNetNetWorks_lokups_LkpCountryId",
                table: "InterNetNetWorks",
                column: "LkpCountryId",
                principalTable: "lokups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
