using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MobiTech.Migrations
{
    public partial class MobiTech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lkpTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertUser = table.Column<int>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lkpTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lokups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertUser = table.Column<int>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lokups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lokups_lkpTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "lkpTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertUser = table.Column<int>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IMEI = table.Column<long>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    Customer = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    DateSale = table.Column<DateTime>(nullable: true),
                    LkpMethodId = table.Column<int>(nullable: false),
                    MethodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_lokups_LkpMethodId",
                        column: x => x.LkpMethodId,
                        principalTable: "lokups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_lokups_MethodId",
                        column: x => x.MethodId,
                        principalTable: "lokups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertUser = table.Column<int>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IMEI = table.Column<long>(nullable: false),
                    LkpTypeId = table.Column<int>(nullable: true),
                    LkpColorId = table.Column<int>(nullable: true),
                    LkpStorageId = table.Column<int>(nullable: true),
                    LkpRamId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: true),
                    LkpStatusId = table.Column<int>(nullable: true),
                    LkpActiveId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stors_lokups_LkpActiveId",
                        column: x => x.LkpActiveId,
                        principalTable: "lokups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stors_lokups_LkpColorId",
                        column: x => x.LkpColorId,
                        principalTable: "lokups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stors_lokups_LkpRamId",
                        column: x => x.LkpRamId,
                        principalTable: "lokups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stors_lokups_LkpStatusId",
                        column: x => x.LkpStatusId,
                        principalTable: "lokups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stors_lokups_LkpStorageId",
                        column: x => x.LkpStorageId,
                        principalTable: "lokups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stors_lokups_LkpTypeId",
                        column: x => x.LkpTypeId,
                        principalTable: "lokups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cheques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertUser = table.Column<int>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    Owner = table.Column<string>(nullable: true),
                    ChequeNo = table.Column<int>(nullable: false),
                    Bank = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ChStatusId = table.Column<int>(nullable: false),
                    ChequeStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cheques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cheques_lokups_ChStatusId",
                        column: x => x.ChStatusId,
                        principalTable: "lokups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cheques_lokups_ChequeStatusId",
                        column: x => x.ChequeStatusId,
                        principalTable: "lokups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                   
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_cheques_ChStatusId",
                table: "cheques",
                column: "ChStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_cheques_ChequeStatusId",
                table: "cheques",
                column: "ChequeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_cheques_CustomerId",
                table: "cheques",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_lokups_TypeId",
                table: "lokups",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_LkpMethodId",
                table: "Sales",
                column: "LkpMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_MethodId",
                table: "Sales",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Stors_LkpActiveId",
                table: "Stors",
                column: "LkpActiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Stors_LkpColorId",
                table: "Stors",
                column: "LkpColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stors_LkpRamId",
                table: "Stors",
                column: "LkpRamId");

            migrationBuilder.CreateIndex(
                name: "IX_Stors_LkpStatusId",
                table: "Stors",
                column: "LkpStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Stors_LkpStorageId",
                table: "Stors",
                column: "LkpStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Stors_LkpTypeId",
                table: "Stors",
                column: "LkpTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "cheques");

            migrationBuilder.DropTable(
                name: "Stors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "lokups");

            migrationBuilder.DropTable(
                name: "lkpTypes");
        }
    }
}
