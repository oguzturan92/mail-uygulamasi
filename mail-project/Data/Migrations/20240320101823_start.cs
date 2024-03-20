using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mails",
                columns: table => new
                {
                    MailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MailKimdenMailId = table.Column<int>(type: "int", nullable: false),
                    MailKimeMailName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MailRead = table.Column<bool>(type: "bit", nullable: false),
                    MailImportant = table.Column<bool>(type: "bit", nullable: false),
                    MailDraft = table.Column<bool>(type: "bit", nullable: false),
                    MailTrash = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mails", x => x.MailId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.InsertData(
                table: "Mails",
                columns: new[] { "MailId", "MailContent", "MailDate", "MailDraft", "MailImportant", "MailKimdenMailId", "MailKimeMailName", "MailRead", "MailSubject", "MailTrash" },
                values: new object[,]
                {
                    { 1, "Gelen Mail içeriği 1", new DateTime(2024, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, 2, "a@gmail.com", true, "Gelen Konu başlığı 1", false },
                    { 2, "Gelen Mail içeriği 2", new DateTime(2024, 1, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), false, true, 2, "a@gmail.com", false, "Gelen Konu başlığı 2", false },
                    { 3, "Gelen Mail içeriği 3", new DateTime(2024, 1, 3, 13, 30, 0, 0, DateTimeKind.Unspecified), false, true, 3, "a@gmail.com", false, "Gelen Konu başlığı 3", false },
                    { 4, "Gelen Mail içeriği 4", new DateTime(2024, 1, 4, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, 3, "a@gmail.com", true, "Gelen Konu başlığı 4", false },
                    { 5, "Gelen Mail içeriği 5", new DateTime(2024, 1, 5, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, 3, "a@gmail.com", true, "Gelen Konu başlığı 5", false },
                    { 6, "Gelen Mail içeriği 6", new DateTime(2024, 1, 6, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, 2, "a@gmail.com", true, "Gelen Konu başlığı 6", false },
                    { 7, "Gelen Mail içeriği 7", new DateTime(2024, 1, 7, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, 2, "a@gmail.com", true, "Gelen Konu başlığı 7", false },
                    { 8, "Gelen Mail içeriği 8", new DateTime(2024, 1, 8, 13, 30, 0, 0, DateTimeKind.Unspecified), false, true, 2, "a@gmail.com", false, "Gelen Konu başlığı 8", false },
                    { 9, "Gelen Mail içeriği 9", new DateTime(2024, 1, 9, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, 3, "a@gmail.com", true, "Gelen Konu başlığı 9", false },
                    { 10, "Gelen Mail içeriği 10", new DateTime(2024, 1, 10, 13, 30, 0, 0, DateTimeKind.Unspecified), false, true, 2, "a@gmail.com", true, "Gelen Konu başlığı 10", false },
                    { 11, "Gelen Mail içeriği 11", new DateTime(2024, 1, 11, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, 3, "a@gmail.com", true, "Gelen Konu başlığı 11", false },
                    { 12, "Gelen Mail içeriği 12", new DateTime(2024, 1, 12, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, 2, "a@gmail.com", true, "Gelen Konu başlığı 12", false },
                    { 13, "Gelen Mail içeriği 13", new DateTime(2024, 1, 13, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, 3, "a@gmail.com", true, "Gelen Konu başlığı 13", false },
                    { 14, "Gelen Mail içeriği 14", new DateTime(2024, 1, 14, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, 2, "a@gmail.com", true, "Gelen Konu başlığı 14", true },
                    { 15, "Gelen Mail içeriği 15", new DateTime(2024, 1, 15, 13, 30, 0, 0, DateTimeKind.Unspecified), false, true, 2, "a@gmail.com", true, "Gelen Konu başlığı 15", true },
                    { 16, "Giden Mail içeriği 1", new DateTime(2024, 1, 8, 19, 30, 0, 0, DateTimeKind.Unspecified), false, false, 1, "b@gmail.com", true, "Giden Konu başlığı 1", false },
                    { 17, "Giden Mail içeriği 2", new DateTime(2024, 1, 7, 14, 30, 0, 0, DateTimeKind.Unspecified), false, false, 1, "b@gmail.com", true, "Giden Konu başlığı 2", false },
                    { 18, "Giden Mail içeriği 3", new DateTime(2024, 1, 1, 17, 30, 0, 0, DateTimeKind.Unspecified), false, false, 1, "b@gmail.com", true, "Giden Konu başlığı 3", false },
                    { 19, "Giden Mail içeriği 4", new DateTime(2024, 1, 3, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, 1, "b@gmail.com", true, "Giden Konu başlığı 4", false },
                    { 20, "Giden Mail içeriği 5", new DateTime(2024, 1, 6, 13, 38, 0, 0, DateTimeKind.Unspecified), false, false, 1, "b@gmail.com", true, "Giden Konu başlığı 5", false },
                    { 21, "Giden Mail içeriği 6", new DateTime(2024, 1, 17, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, 1, "b@gmail.com", true, "Giden Konu başlığı 6", true },
                    { 22, "Giden Mail içeriği 7", new DateTime(2024, 1, 14, 13, 30, 0, 0, DateTimeKind.Unspecified), false, true, 1, "b@gmail.com", true, "Giden Konu başlığı 7", false },
                    { 23, "Taslak içeriği 1", new DateTime(2024, 1, 15, 13, 30, 0, 0, DateTimeKind.Unspecified), false, false, 1, "b@gmail.com", true, "", false }
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
                name: "Mails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
