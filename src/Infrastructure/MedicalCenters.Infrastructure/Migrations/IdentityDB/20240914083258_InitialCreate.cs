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
                    { 1, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7323), 1L, "افزودن مرکز درمانی", "p" },
                    { 2, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7386), 1L, "ویرایش مرکز درمانی", "p" },
                    { 3, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7420), 1L, "حذف مرکز درمانی", "p" },
                    { 4, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7455), 1L, "مشاهده اطلاعات مرکز درمانی", "p" },
                    { 5, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7492), 1L, "مشاهده اطلاعات تمامی مراکز درمانی", "p" },
                    { 6, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7531), 1L, "افزودن بخش درمانی", "p" },
                    { 7, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7565), 1L, "ویرایش بخش درمانی", "p" },
                    { 8, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7599), 1L, "حذف بخش درمانی", "p" },
                    { 9, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7634), 1L, "مشاهده اطلاعات بخش درمانی", "p" },
                    { 10, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7671), 1L, "مشاهده اطلاعات تمامی بخش های مرکز درمانی", "p" },
                    { 11, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7706), 1L, "افزودن دارو", "p" },
                    { 12, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7818), 1L, "ویرایش دارو", "p" },
                    { 13, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7855), 1L, "حذف دارو", "p" },
                    { 14, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7890), 1L, "مشاهده دارو ها", "p" },
                    { 15, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7925), 1L, "مشاهده دارو های یک نوع", "p" },
                    { 16, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7957), 1L, "افزودن پزشک", "p" },
                    { 17, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(7990), 1L, "ویرایش پزشک", "p" },
                    { 18, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(8026), 1L, "حذف پزشک", "p" },
                    { 19, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(8060), 1L, "مشاهده اطلاعات پزشک", "p" },
                    { 20, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(8093), 1L, "افزودن بیمار", "p" },
                    { 21, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(8124), 1L, "ویرایش بیمار", "p" },
                    { 22, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(8155), 1L, "حذف بیمار", "p" },
                    { 23, new DateTime(2024, 9, 14, 12, 2, 57, 351, DateTimeKind.Local).AddTicks(8191), 1L, "مشاهده اطلاعات بیمار", "p" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, new DateTime(2024, 9, 14, 12, 2, 57, 454, DateTimeKind.Local).AddTicks(9609), 1L, 0, new byte[] { 32, 37, 254, 161, 154, 80, 184, 154, 226, 167, 240, 229, 101, 98, 17, 197, 20, 21, 6, 229, 128, 79, 148, 9, 66, 188, 86, 247, 170, 166, 58, 76, 222, 44, 133, 59, 154, 148, 109, 250, 36, 179, 39, 100, 169, 203, 180, 119, 164, 68, 188, 151, 73, 83, 63, 40, 70, 15, 176, 88, 39, 56, 36, 22 }, "ادمین", 0, new byte[] { 128, 133, 197, 236, 13, 14, 178, 159, 96, 172, 175, 175, 160, 111, 208, 193, 210, 37, 173, 244, 193, 77, 44, 60, 184, 7, 132, 22, 178, 209, 199, 117, 251, 151, 206, 125, 120, 218, 65, 59, 74, 103, 10, 146, 121, 48, 3, 63, 206, 15, 198, 99, 92, 56, 205, 105, 94, 120, 73, 167, 98, 186, 4, 36 }, "Administrator" });

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
