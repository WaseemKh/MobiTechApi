using Microsoft.EntityFrameworkCore.Migrations;

namespace MobiTech.Migrations
{
    public partial class updatenetwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PhoneNo",
                table: "InterNetNetWorks",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "IdNo",
                table: "InterNetNetWorks",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNo",
                table: "InterNetNetWorks",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "IdNo",
                table: "InterNetNetWorks",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
