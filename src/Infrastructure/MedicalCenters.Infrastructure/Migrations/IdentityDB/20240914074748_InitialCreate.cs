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
                    { 1, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4485), 1L, "افزودن مرکز درمانی", "p" },
                    { 2, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4534), 1L, "ویرایش مرکز درمانی", "p" },
                    { 3, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4554), 1L, "حذف مرکز درمانی", "p" },
                    { 4, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4572), 1L, "مشاهده اطلاعات مرکز درمانی", "p" },
                    { 5, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4589), 1L, "مشاهده اطلاعات تمامی مراکز درمانی", "p" },
                    { 6, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4617), 1L, "افزودن بخش درمانی", "p" },
                    { 7, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4634), 1L, "ویرایش بخش درمانی", "p" },
                    { 8, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4651), 1L, "حذف بخش درمانی", "p" },
                    { 9, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4667), 1L, "مشاهده اطلاعات بخش درمانی", "p" },
                    { 10, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4686), 1L, "مشاهده اطلاعات تمامی بخش های مرکز درمانی", "p" },
                    { 11, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4705), 1L, "افزودن دارو", "p" },
                    { 12, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4722), 1L, "ویرایش دارو", "p" },
                    { 13, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4740), 1L, "حذف دارو", "p" },
                    { 14, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4757), 1L, "مشاهده دارو ها", "p" },
                    { 15, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4774), 1L, "مشاهده دارو های یک نوع", "p" },
                    { 16, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4791), 1L, "افزودن پزشک", "p" },
                    { 17, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4808), 1L, "ویرایش پزشک", "p" },
                    { 18, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4825), 1L, "حذف پزشک", "p" },
                    { 19, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4841), 1L, "مشاهده اطلاعات پزشک", "p" },
                    { 20, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4912), 1L, "افزودن بیمار", "p" },
                    { 21, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4930), 1L, "ویرایش بیمار", "p" },
                    { 22, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4947), 1L, "حذف بیمار", "p" },
                    { 23, new DateTime(2024, 9, 14, 11, 17, 47, 670, DateTimeKind.Local).AddTicks(4966), 1L, "مشاهده اطلاعات بیمار", "p" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, new DateTime(2024, 9, 14, 11, 17, 47, 764, DateTimeKind.Local).AddTicks(9517), 1L, 0, new byte[] { 191, 234, 236, 186, 242, 172, 231, 201, 63, 161, 179, 187, 200, 2, 207, 255, 51, 11, 143, 70, 240, 65, 40, 38, 11, 81, 85, 28, 52, 40, 43, 196, 174, 46, 131, 152, 159, 166, 62, 190, 49, 44, 255, 160, 57, 18, 151, 250, 48, 253, 225, 143, 160, 167, 226, 142, 203, 34, 213, 62, 76, 24, 125, 86 }, "ادمین", 0, new byte[] { 136, 165, 137, 37, 51, 123, 7, 53, 91, 242, 153, 209, 203, 138, 132, 16, 144, 235, 229, 98, 251, 211, 130, 75, 54, 119, 184, 251, 210, 126, 21, 39, 30, 149, 201, 194, 102, 87, 199, 185, 151, 44, 5, 168, 45, 221, 40, 22, 135, 176, 251, 254, 70, 207, 106, 35, 129, 133, 193, 119, 116, 82, 47, 8 }, "Administrator" });

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
