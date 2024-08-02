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
                    { 1, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1074), "افزودن مرکز درمانی", "p" },
                    { 2, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1114), "ویرایش مرکز درمانی", "p" },
                    { 3, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1131), "حذف مرکز درمانی", "p" },
                    { 4, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1146), "مشاهده اطلاعات مرکز درمانی", "p" },
                    { 5, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1162), "مشاهده اطلاعات تمامی مراکز درمانی", "p" },
                    { 6, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1180), "افزودن بخش درمانی", "p" },
                    { 7, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1197), "ویرایش بخش درمانی", "p" },
                    { 8, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1212), "حذف بخش درمانی", "p" },
                    { 9, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1269), "مشاهده اطلاعات بخش درمانی", "p" },
                    { 10, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1289), "مشاهده اطلاعات تمامی بخش های مرکز درمانی", "p" },
                    { 11, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1304), "افزودن دارو", "p" },
                    { 12, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1319), "ویرایش دارو", "p" },
                    { 13, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1334), "حذف دارو", "p" },
                    { 14, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1350), "مشاهده دارو ها", "p" },
                    { 15, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1366), "مشاهده دارو های یک نوع", "p" },
                    { 16, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1381), "افزودن پزشک", "p" },
                    { 17, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1396), "ویرایش پزشک", "p" },
                    { 18, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1412), "حذف پزشک", "p" },
                    { 19, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1426), "مشاهده اطلاعات پزشک", "p" },
                    { 20, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1440), "افزودن بیمار", "p" },
                    { 21, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1453), "ویرایش بیمار", "p" },
                    { 22, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1467), "حذف بیمار", "p" },
                    { 23, 1L, new DateTime(2024, 8, 2, 14, 3, 12, 950, DateTimeKind.Local).AddTicks(1482), "مشاهده اطلاعات بیمار", "p" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "DateTimeCreated", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, 1L, new DateTime(2024, 8, 2, 14, 3, 13, 18, DateTimeKind.Local).AddTicks(5679), 0, new byte[] { 26, 41, 173, 218, 123, 99, 212, 12, 234, 38, 2, 41, 140, 17, 231, 95, 218, 179, 126, 159, 93, 195, 237, 184, 6, 201, 252, 94, 240, 116, 127, 203, 145, 79, 98, 156, 112, 105, 85, 180, 17, 196, 149, 219, 213, 193, 155, 204, 136, 148, 199, 127, 196, 120, 128, 255, 51, 105, 227, 70, 135, 119, 171, 143 }, "ادمین", 0, new byte[] { 153, 115, 209, 27, 125, 157, 19, 148, 45, 59, 204, 221, 141, 11, 13, 32, 25, 85, 222, 208, 236, 243, 185, 21, 26, 181, 189, 239, 77, 101, 240, 213, 54, 67, 10, 6, 223, 8, 183, 210, 18, 98, 60, 28, 185, 144, 171, 36, 202, 104, 94, 4, 20, 59, 187, 101, 142, 225, 55, 15, 34, 149, 108, 107 }, "Administrator" });

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
