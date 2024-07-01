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
                    { 1, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7106), "افزودن مرکز درمانی", "p" },
                    { 2, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7147), "ویرایش مرکز درمانی", "p" },
                    { 3, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7162), "حذف مرکز درمانی", "p" },
                    { 4, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7178), "مشاهده اطلاعات مرکز درمانی", "p" },
                    { 5, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7195), "مشاهده اطلاعات تمامی مراکز درمانی", "p" },
                    { 6, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7214), "افزودن بخش درمانی", "p" },
                    { 7, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7229), "ویرایش بخش درمانی", "p" },
                    { 8, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7244), "حذف بخش درمانی", "p" },
                    { 9, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7259), "مشاهده اطلاعات بخش درمانی", "p" },
                    { 10, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7278), "مشاهده اطلاعات تمامی بخش های مرکز درمانی", "p" },
                    { 11, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7293), "افزودن دارو", "p" },
                    { 12, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7308), "ویرایش دارو", "p" },
                    { 13, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7324), "حذف دارو", "p" },
                    { 14, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7339), "مشاهده دارو ها", "p" },
                    { 15, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7356), "مشاهده دارو های یک نوع", "p" },
                    { 16, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7370), "افزودن پزشک", "p" },
                    { 17, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7471), "ویرایش پزشک", "p" },
                    { 18, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7493), "حذف پزشک", "p" },
                    { 19, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7509), "مشاهده اطلاعات پزشک", "p" },
                    { 20, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7525), "افزودن بیمار", "p" },
                    { 21, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7540), "ویرایش بیمار", "p" },
                    { 22, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7555), "حذف بیمار", "p" },
                    { 23, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 358, DateTimeKind.Local).AddTicks(7574), "مشاهده اطلاعات بیمار", "p" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "DateTimeCreated", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, 1L, new DateTime(2024, 7, 1, 10, 22, 47, 436, DateTimeKind.Local).AddTicks(4414), 0, new byte[] { 92, 4, 114, 205, 64, 22, 40, 163, 169, 249, 215, 180, 159, 182, 199, 148, 133, 250, 131, 208, 222, 237, 151, 117, 41, 246, 216, 125, 169, 198, 36, 146, 188, 129, 14, 235, 177, 87, 21, 72, 27, 56, 4, 132, 50, 67, 213, 206, 234, 65, 163, 55, 190, 241, 132, 140, 157, 91, 255, 253, 146, 252, 29, 169 }, "ادمین", 0, new byte[] { 74, 135, 79, 81, 116, 190, 219, 254, 28, 88, 28, 222, 43, 223, 165, 158, 151, 119, 229, 208, 11, 232, 188, 36, 55, 157, 204, 244, 9, 30, 148, 209, 4, 253, 101, 127, 196, 127, 214, 231, 17, 89, 115, 239, 145, 43, 142, 202, 72, 86, 36, 170, 78, 209, 63, 84, 161, 45, 63, 13, 73, 194, 21, 119 }, "Administrator" });

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
