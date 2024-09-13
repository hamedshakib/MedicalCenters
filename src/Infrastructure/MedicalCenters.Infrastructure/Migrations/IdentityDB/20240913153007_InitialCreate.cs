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
                    { 1, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(5992), "افزودن مرکز درمانی", "p" },
                    { 2, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6042), "ویرایش مرکز درمانی", "p" },
                    { 3, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6060), "حذف مرکز درمانی", "p" },
                    { 4, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6076), "مشاهده اطلاعات مرکز درمانی", "p" },
                    { 5, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6094), "مشاهده اطلاعات تمامی مراکز درمانی", "p" },
                    { 6, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6113), "افزودن بخش درمانی", "p" },
                    { 7, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6130), "ویرایش بخش درمانی", "p" },
                    { 8, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6146), "حذف بخش درمانی", "p" },
                    { 9, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6162), "مشاهده اطلاعات بخش درمانی", "p" },
                    { 10, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6182), "مشاهده اطلاعات تمامی بخش های مرکز درمانی", "p" },
                    { 11, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6197), "افزودن دارو", "p" },
                    { 12, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6212), "ویرایش دارو", "p" },
                    { 13, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6229), "حذف دارو", "p" },
                    { 14, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6244), "مشاهده دارو ها", "p" },
                    { 15, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6260), "مشاهده دارو های یک نوع", "p" },
                    { 16, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6277), "افزودن پزشک", "p" },
                    { 17, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6292), "ویرایش پزشک", "p" },
                    { 18, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6309), "حذف پزشک", "p" },
                    { 19, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6324), "مشاهده اطلاعات پزشک", "p" },
                    { 20, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6372), "افزودن بیمار", "p" },
                    { 21, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6388), "ویرایش بیمار", "p" },
                    { 22, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6404), "حذف بیمار", "p" },
                    { 23, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 474, DateTimeKind.Local).AddTicks(6421), "مشاهده اطلاعات بیمار", "p" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "DateTimeCreated", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, 1L, new DateTime(2024, 9, 13, 19, 0, 7, 541, DateTimeKind.Local).AddTicks(4554), 0, new byte[] { 17, 40, 226, 168, 192, 236, 135, 33, 40, 88, 181, 46, 128, 143, 90, 202, 168, 121, 61, 186, 222, 197, 193, 124, 137, 169, 63, 87, 170, 100, 140, 134, 0, 138, 144, 8, 179, 29, 250, 222, 229, 104, 19, 31, 14, 216, 143, 45, 135, 146, 6, 223, 93, 88, 238, 129, 5, 35, 88, 97, 145, 57, 217, 21 }, "ادمین", 0, new byte[] { 152, 29, 108, 178, 97, 233, 47, 63, 147, 218, 6, 119, 1, 167, 194, 173, 64, 70, 123, 130, 49, 1, 189, 199, 73, 236, 118, 57, 46, 17, 59, 151, 112, 29, 179, 16, 229, 63, 127, 244, 245, 205, 231, 19, 10, 113, 168, 183, 227, 163, 25, 165, 15, 146, 221, 205, 220, 138, 150, 90, 227, 160, 254, 86 }, "Administrator" });

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
