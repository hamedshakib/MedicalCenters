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
                    { 1, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(463), "افزودن مرکز درمانی", "p" },
                    { 2, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(616), "ویرایش مرکز درمانی", "p" },
                    { 3, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(642), "حذف مرکز درمانی", "p" },
                    { 4, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(660), "مشاهده اطلاعات مرکز درمانی", "p" },
                    { 5, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(679), "مشاهده اطلاعات تمامی مراکز درمانی", "p" },
                    { 6, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(701), "افزودن بخش درمانی", "p" },
                    { 7, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(718), "ویرایش بخش درمانی", "p" },
                    { 8, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(735), "حذف بخش درمانی", "p" },
                    { 9, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(753), "مشاهده اطلاعات بخش درمانی", "p" },
                    { 10, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(773), "مشاهده اطلاعات تمامی بخش های مرکز درمانی", "p" },
                    { 11, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(791), "افزودن دارو", "p" },
                    { 12, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(808), "ویرایش دارو", "p" },
                    { 13, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(825), "حذف دارو", "p" },
                    { 14, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(844), "مشاهده دارو ها", "p" },
                    { 15, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(861), "مشاهده دارو های یک نوع", "p" },
                    { 16, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(878), "افزودن پزشک", "p" },
                    { 17, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(896), "ویرایش پزشک", "p" },
                    { 18, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(913), "حذف پزشک", "p" },
                    { 19, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(929), "مشاهده اطلاعات پزشک", "p" },
                    { 20, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(946), "افزودن بیمار", "p" },
                    { 21, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(963), "ویرایش بیمار", "p" },
                    { 22, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(979), "حذف بیمار", "p" },
                    { 23, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 488, DateTimeKind.Local).AddTicks(998), "مشاهده اطلاعات بیمار", "p" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "DateTimeCreated", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, 1L, new DateTime(2024, 9, 14, 10, 25, 13, 591, DateTimeKind.Local).AddTicks(9718), 0, new byte[] { 93, 36, 233, 39, 143, 247, 25, 183, 23, 210, 101, 142, 189, 112, 142, 112, 64, 13, 60, 164, 235, 40, 194, 82, 226, 145, 117, 38, 86, 149, 102, 116, 181, 13, 174, 179, 105, 24, 162, 247, 78, 24, 234, 154, 220, 193, 56, 14, 64, 92, 101, 217, 37, 120, 34, 113, 192, 21, 186, 116, 0, 104, 64, 146 }, "ادمین", 0, new byte[] { 115, 127, 84, 72, 221, 75, 141, 31, 179, 200, 98, 78, 58, 250, 64, 116, 29, 126, 45, 249, 78, 57, 62, 119, 57, 21, 13, 191, 75, 1, 229, 133, 234, 157, 240, 168, 175, 52, 208, 14, 152, 73, 82, 199, 91, 192, 21, 81, 25, 215, 230, 136, 142, 80, 84, 207, 228, 27, 88, 138, 64, 29, 101, 215 }, "Administrator" });

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
