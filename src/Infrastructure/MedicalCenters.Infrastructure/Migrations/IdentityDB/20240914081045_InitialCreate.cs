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
                    { 1, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2209), 1L, "افزودن مرکز درمانی", "p" },
                    { 2, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2279), 1L, "ویرایش مرکز درمانی", "p" },
                    { 3, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2311), 1L, "حذف مرکز درمانی", "p" },
                    { 4, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2341), 1L, "مشاهده اطلاعات مرکز درمانی", "p" },
                    { 5, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2369), 1L, "مشاهده اطلاعات تمامی مراکز درمانی", "p" },
                    { 6, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2405), 1L, "افزودن بخش درمانی", "p" },
                    { 7, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2435), 1L, "ویرایش بخش درمانی", "p" },
                    { 8, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2462), 1L, "حذف بخش درمانی", "p" },
                    { 9, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2492), 1L, "مشاهده اطلاعات بخش درمانی", "p" },
                    { 10, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2526), 1L, "مشاهده اطلاعات تمامی بخش های مرکز درمانی", "p" },
                    { 11, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2556), 1L, "افزودن دارو", "p" },
                    { 12, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2584), 1L, "ویرایش دارو", "p" },
                    { 13, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2729), 1L, "حذف دارو", "p" },
                    { 14, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2764), 1L, "مشاهده دارو ها", "p" },
                    { 15, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2794), 1L, "مشاهده دارو های یک نوع", "p" },
                    { 16, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2821), 1L, "افزودن پزشک", "p" },
                    { 17, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2847), 1L, "ویرایش پزشک", "p" },
                    { 18, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2877), 1L, "حذف پزشک", "p" },
                    { 19, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2903), 1L, "مشاهده اطلاعات پزشک", "p" },
                    { 20, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2929), 1L, "افزودن بیمار", "p" },
                    { 21, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2957), 1L, "ویرایش بیمار", "p" },
                    { 22, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(2986), 1L, "حذف بیمار", "p" },
                    { 23, new DateTime(2024, 9, 14, 11, 40, 45, 482, DateTimeKind.Local).AddTicks(3018), 1L, "مشاهده اطلاعات بیمار", "p" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, new DateTime(2024, 9, 14, 11, 40, 45, 561, DateTimeKind.Local).AddTicks(9962), 1L, 0, new byte[] { 208, 124, 85, 149, 208, 25, 86, 42, 226, 238, 48, 253, 149, 44, 74, 108, 195, 9, 38, 111, 74, 20, 94, 48, 238, 2, 205, 149, 155, 254, 114, 199, 139, 112, 177, 112, 13, 138, 26, 169, 223, 187, 25, 43, 173, 4, 115, 94, 75, 206, 117, 71, 58, 42, 143, 237, 147, 98, 116, 218, 153, 32, 204, 72 }, "ادمین", 0, new byte[] { 169, 141, 210, 207, 115, 64, 48, 47, 74, 233, 163, 21, 37, 113, 249, 50, 15, 209, 174, 16, 53, 101, 44, 108, 3, 193, 181, 205, 91, 182, 108, 161, 4, 196, 179, 192, 233, 112, 177, 57, 149, 31, 120, 81, 162, 251, 123, 102, 207, 241, 174, 138, 50, 248, 210, 217, 203, 132, 157, 103, 242, 198, 138, 160 }, "Administrator" });

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
