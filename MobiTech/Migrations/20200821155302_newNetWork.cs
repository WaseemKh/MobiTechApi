using Microsoft.EntityFrameworkCore.Migrations;

namespace MobiTech.Migrations
{
    public partial class newNetWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterNetNetWorks_lokups_LokupsId",
                table: "InterNetNetWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_InterNetNetWorks_lokups_LokupsId1",
                table: "InterNetNetWorks");

            migrationBuilder.DropIndex(
                name: "IX_InterNetNetWorks_LokupsId",
                table: "InterNetNetWorks");

            migrationBuilder.DropIndex(
                name: "IX_InterNetNetWorks_LokupsId1",
                table: "InterNetNetWorks");

            migrationBuilder.DropColumn(
                name: "LkpSubtypeId",
                table: "InterNetNetWorks");

            migrationBuilder.DropColumn(
                name: "LokupsId",
                table: "InterNetNetWorks");

            migrationBuilder.DropColumn(
                name: "LokupsId1",
                table: "InterNetNetWorks");

            migrationBuilder.CreateIndex(
                name: "IX_InterNetNetWorks_LkpCountryId",
                table: "InterNetNetWorks",
                column: "LkpCountryId");

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

            migrationBuilder.DropIndex(
                name: "IX_InterNetNetWorks_LkpCountryId",
                table: "InterNetNetWorks");

            migrationBuilder.AddColumn<int>(
                name: "LkpSubtypeId",
                table: "InterNetNetWorks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LokupsId",
                table: "InterNetNetWorks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LokupsId1",
                table: "InterNetNetWorks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InterNetNetWorks_LokupsId",
                table: "InterNetNetWorks",
                column: "LokupsId");

            migrationBuilder.CreateIndex(
                name: "IX_InterNetNetWorks_LokupsId1",
                table: "InterNetNetWorks",
                column: "LokupsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InterNetNetWorks_lokups_LokupsId",
                table: "InterNetNetWorks",
                column: "LokupsId",
                principalTable: "lokups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InterNetNetWorks_lokups_LokupsId1",
                table: "InterNetNetWorks",
                column: "LokupsId1",
                principalTable: "lokups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
