using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalCenters.Persistence.Migrations.IdentityDB
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HashedPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HashAlgorithmType = table.Column<int>(type: "int", nullable: false),
                    PeaperType = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission_PermissionGroup",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    PermissionGroupId = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission_PermissionGroup", x => new { x.PermissionId, x.PermissionGroupId });
                    table.ForeignKey(
                        name: "FK_Permission_PermissionGroup_PermissionGroup_PermissionGroupId",
                        column: x => x.PermissionGroupId,
                        principalTable: "PermissionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permission_PermissionGroup_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission_User",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission_User", x => new { x.PermissionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Permission_User_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permission_User_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroup_User",
                columns: table => new
                {
                    PermissionGroupId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroup_User", x => new { x.PermissionGroupId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PermissionGroup_User_PermissionGroup_PermissionGroupId",
                        column: x => x.PermissionGroupId,
                        principalTable: "PermissionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionGroup_User_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedBy", "DateTimeCreated", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(1808), "افزودن مرکز درمانی", "p" },
                    { 2, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(1852), "ویرایش مرکز درمانی", "p" },
                    { 3, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(1870), "حذف مرکز درمانی", "p" },
                    { 4, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(1888), "مشاهده اطلاعات مرکز درمانی", "p" },
                    { 5, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(1905), "مشاهده اطلاعات تمامی مراکز درمانی", "p" },
                    { 6, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(1925), "افزودن بخش درمانی", "p" },
                    { 7, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(1941), "ویرایش بخش درمانی", "p" },
                    { 8, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(1957), "حذف بخش درمانی", "p" },
                    { 9, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(1973), "مشاهده اطلاعات بخش درمانی", "p" },
                    { 10, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(1992), "مشاهده اطلاعات تمامی بخش های مرکز درمانی", "p" },
                    { 11, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(2008), "افزودن دارو", "p" },
                    { 12, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(2023), "ویرایش دارو", "p" },
                    { 13, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(2039), "حذف دارو", "p" },
                    { 14, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(2056), "مشاهده دارو ها", "p" },
                    { 15, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 741, DateTimeKind.Local).AddTicks(2072), "مشاهده دارو های یک نوع", "p" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "DateTimeCreated", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, 1L, new DateTime(2024, 6, 11, 13, 45, 20, 812, DateTimeKind.Local).AddTicks(9615), 0, new byte[] { 140, 195, 102, 2, 231, 216, 10, 134, 58, 32, 11, 196, 99, 234, 84, 238, 79, 34, 230, 5, 60, 179, 48, 20, 10, 170, 122, 105, 21, 38, 230, 25, 153, 28, 168, 178, 12, 160, 83, 144, 39, 193, 214, 80, 176, 24, 21, 218, 225, 202, 127, 171, 227, 5, 232, 248, 45, 149, 49, 5, 5, 22, 188, 7 }, "ادمین", 0, new byte[] { 20, 117, 101, 69, 237, 30, 56, 123, 207, 82, 150, 220, 250, 19, 93, 106, 6, 218, 63, 148, 26, 49, 72, 247, 48, 167, 63, 135, 138, 248, 130, 10, 104, 184, 227, 73, 149, 22, 251, 71, 125, 2, 42, 90, 154, 124, 179, 35, 48, 137, 22, 112, 141, 146, 17, 184, 35, 22, 5, 156, 179, 142, 57, 219 }, "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionGroup_PermissionGroupId",
                table: "Permission_PermissionGroup",
                column: "PermissionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_User_UserId",
                table: "Permission_User",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroup_User_UserId",
                table: "PermissionGroup_User",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permission_PermissionGroup");

            migrationBuilder.DropTable(
                name: "Permission_User");

            migrationBuilder.DropTable(
                name: "PermissionGroup_User");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "PermissionGroup");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
