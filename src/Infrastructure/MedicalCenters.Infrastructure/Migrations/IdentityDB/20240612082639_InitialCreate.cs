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
                    { 1, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9139), "افزودن مرکز درمانی", "p" },
                    { 2, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9180), "ویرایش مرکز درمانی", "p" },
                    { 3, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9197), "حذف مرکز درمانی", "p" },
                    { 4, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9215), "مشاهده اطلاعات مرکز درمانی", "p" },
                    { 5, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9231), "مشاهده اطلاعات تمامی مراکز درمانی", "p" },
                    { 6, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9250), "افزودن بخش درمانی", "p" },
                    { 7, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9266), "ویرایش بخش درمانی", "p" },
                    { 8, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9332), "حذف بخش درمانی", "p" },
                    { 9, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9353), "مشاهده اطلاعات بخش درمانی", "p" },
                    { 10, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9372), "مشاهده اطلاعات تمامی بخش های مرکز درمانی", "p" },
                    { 11, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9387), "افزودن دارو", "p" },
                    { 12, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9403), "ویرایش دارو", "p" },
                    { 13, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9418), "حذف دارو", "p" },
                    { 14, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9437), "مشاهده دارو ها", "p" },
                    { 15, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9453), "مشاهده دارو های یک نوع", "p" },
                    { 16, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9468), "افزودن پزشک", "p" },
                    { 17, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9484), "ویرایش پزشک", "p" },
                    { 18, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9500), "حذف پزشک", "p" },
                    { 19, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9515), "مشاهده اطلاعات پزشک", "p" },
                    { 20, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9530), "افزودن بیمار", "p" },
                    { 21, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9545), "ویرایش بیمار", "p" },
                    { 22, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9560), "حذف بیمار", "p" },
                    { 23, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 508, DateTimeKind.Local).AddTicks(9576), "مشاهده اطلاعات بیمار", "p" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "DateTimeCreated", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, 1L, new DateTime(2024, 6, 12, 11, 56, 39, 575, DateTimeKind.Local).AddTicks(4548), 0, new byte[] { 245, 190, 172, 39, 191, 191, 56, 83, 157, 17, 77, 25, 213, 64, 125, 47, 134, 184, 179, 145, 30, 123, 101, 205, 97, 216, 65, 225, 188, 44, 68, 20, 73, 70, 23, 102, 200, 151, 245, 110, 107, 90, 65, 6, 202, 62, 253, 243, 65, 39, 174, 89, 9, 124, 20, 146, 127, 125, 82, 220, 1, 37, 82, 215 }, "ادمین", 0, new byte[] { 6, 244, 125, 25, 212, 149, 89, 24, 225, 129, 169, 27, 78, 33, 174, 233, 170, 124, 193, 216, 24, 157, 79, 56, 25, 220, 25, 105, 7, 225, 207, 147, 230, 201, 244, 155, 53, 56, 14, 172, 227, 187, 22, 129, 83, 24, 223, 30, 89, 186, 251, 192, 150, 140, 201, 180, 215, 36, 61, 145, 50, 249, 186, 37 }, "Administrator" });

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
