using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MobiTech.Migrations
{
    public partial class Network : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cheques_lokups_ChequeStatusId",
                table: "cheques");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_lokups_MethodId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_MethodId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_cheques_ChequeStatusId",
                table: "cheques");

            migrationBuilder.DropColumn(
                name: "MethodId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ChequeStatusId",
                table: "cheques");

            migrationBuilder.CreateTable(
                name: "InterNetNetWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertUser = table.Column<int>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    LkpCountryId = table.Column<int>(nullable: false),
                    Region = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<int>(nullable: false),
                    IdNo = table.Column<int>(nullable: false),
                    LkpSubtypeId = table.Column<int>(nullable: false),
                    SubScribePrice = table.Column<int>(nullable: false),
                    RouterPrice = table.Column<int>(nullable: false),
                    Debts = table.Column<int>(nullable: false),
                    LokupsId = table.Column<int>(nullable: true),
                    LokupsId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterNetNetWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterNetNetWorks_lokups_LokupsId",
                        column: x => x.LokupsId,
                        principalTable: "lokups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InterNetNetWorks_lokups_LokupsId1",
                        column: x => x.LokupsId1,
                        principalTable: "lokups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterNetNetWorks_LokupsId",
                table: "InterNetNetWorks",
                column: "LokupsId");

            migrationBuilder.CreateIndex(
                name: "IX_InterNetNetWorks_LokupsId1",
                table: "InterNetNetWorks",
                column: "LokupsId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterNetNetWorks");

            migrationBuilder.AddColumn<int>(
                name: "MethodId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChequeStatusId",
                table: "cheques",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_MethodId",
                table: "Sales",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_cheques_ChequeStatusId",
                table: "cheques",
                column: "ChequeStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_cheques_lokups_ChequeStatusId",
                table: "cheques",
                column: "ChequeStatusId",
                principalTable: "lokups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_lokups_MethodId",
                table: "Sales",
                column: "MethodId",
                principalTable: "lokups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
