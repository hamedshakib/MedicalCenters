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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1652), 1L, "افزودن مرکز درمانی", "p" },
                    { 2, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1701), 1L, "ویرایش مرکز درمانی", "p" },
                    { 3, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1720), 1L, "حذف مرکز درمانی", "p" },
                    { 4, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1738), 1L, "مشاهده اطلاعات مرکز درمانی", "p" },
                    { 5, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1755), 1L, "مشاهده اطلاعات تمامی مراکز درمانی", "p" },
                    { 6, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1777), 1L, "افزودن بخش درمانی", "p" },
                    { 7, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1795), 1L, "ویرایش بخش درمانی", "p" },
                    { 8, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1812), 1L, "حذف بخش درمانی", "p" },
                    { 9, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1828), 1L, "مشاهده اطلاعات بخش درمانی", "p" },
                    { 10, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1848), 1L, "مشاهده اطلاعات تمامی بخش های مرکز درمانی", "p" },
                    { 11, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1864), 1L, "افزودن دارو", "p" },
                    { 12, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1880), 1L, "ویرایش دارو", "p" },
                    { 13, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1897), 1L, "حذف دارو", "p" },
                    { 14, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1915), 1L, "مشاهده دارو ها", "p" },
                    { 15, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1970), 1L, "مشاهده دارو های یک نوع", "p" },
                    { 16, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(1987), 1L, "افزودن پزشک", "p" },
                    { 17, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(2003), 1L, "ویرایش پزشک", "p" },
                    { 18, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(2022), 1L, "حذف پزشک", "p" },
                    { 19, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(2038), 1L, "مشاهده اطلاعات پزشک", "p" },
                    { 20, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(2053), 1L, "افزودن بیمار", "p" },
                    { 21, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(2069), 1L, "ویرایش بیمار", "p" },
                    { 22, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(2086), 1L, "حذف بیمار", "p" },
                    { 23, new DateTime(2024, 9, 26, 21, 43, 13, 393, DateTimeKind.Local).AddTicks(2104), 1L, "مشاهده اطلاعات بیمار", "p" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, new DateTime(2024, 9, 26, 21, 43, 13, 463, DateTimeKind.Local).AddTicks(2451), 1L, 0, new byte[] { 143, 195, 149, 110, 131, 128, 130, 120, 9, 195, 189, 41, 249, 240, 199, 137, 183, 121, 141, 164, 195, 94, 118, 121, 104, 136, 43, 80, 129, 203, 98, 27, 171, 182, 52, 244, 14, 51, 42, 211, 97, 246, 47, 112, 59, 8, 171, 150, 255, 178, 239, 145, 46, 29, 215, 184, 219, 55, 161, 161, 237, 25, 209, 203 }, "ادمین", 0, new byte[] { 129, 176, 208, 10, 50, 128, 141, 129, 12, 63, 200, 87, 107, 157, 254, 81, 76, 142, 212, 245, 87, 186, 133, 82, 240, 135, 252, 140, 181, 60, 140, 212, 56, 34, 173, 76, 19, 168, 138, 3, 160, 100, 113, 200, 40, 171, 218, 30, 98, 18, 0, 218, 49, 96, 159, 69, 143, 150, 247, 218, 11, 184, 67, 176 }, "Administrator" });

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
