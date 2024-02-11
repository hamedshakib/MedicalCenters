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
                    Id = table.Column<long>(type: "bigint", nullable: false)
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
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
                name: "PermissionPermissionGroup",
                columns: table => new
                {
                    PermissionGroupsId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPermissionGroup", x => new { x.PermissionGroupsId, x.PermissionsId });
                    table.ForeignKey(
                        name: "FK_PermissionPermissionGroup_PermissionGroup_PermissionGroupsId",
                        column: x => x.PermissionGroupsId,
                        principalTable: "PermissionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionPermissionGroup_Permission_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroupUser",
                columns: table => new
                {
                    PermissionGroupsId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroupUser", x => new { x.PermissionGroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_PermissionGroupUser_PermissionGroup_PermissionGroupsId",
                        column: x => x.PermissionGroupsId,
                        principalTable: "PermissionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionGroupUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionUser",
                columns: table => new
                {
                    PermissionsId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionUser", x => new { x.PermissionsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_PermissionUser_Permission_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedBy", "DateTimeCreated", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1826), "افزودن مرکز درمانی", "AddMedicalCenter" },
                    { 2L, 1L, new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1828), "ویرایش مرکز درمانی", "EditMedicalCenter" },
                    { 3L, 1L, new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1829), "حذف مرکز درمانی", "DeleteMedicalCenter" },
                    { 4L, 1L, new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1830), "مشاهده اطلاعات مرکز درمانی", "GetMedicalCenterInfo" },
                    { 5L, 1L, new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1831), "مشاهده اطلاعات تمامی مراکز درمانی", "GetAllMedicalCenterInfos" },
                    { 6L, 1L, new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1832), "افزودن بخش درمانی", "AddMedicalWard" },
                    { 7L, 1L, new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1833), "ویرایش بخش درمانی", "EditMedicalWard" },
                    { 8L, 1L, new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1835), "حذف بخش درمانی", "DeleteMedicalWard" },
                    { 9L, 1L, new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1836), "مشاهده اطلاعات بخش درمانی", "GetMedicalWardInfo" },
                    { 10L, 1L, new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1837), "مشاهده اطلاعات تمامی بخش های مرکز درمانی", "GetAllMedicalCenterWardsInfos" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "DateTimeCreated", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, 1L, new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1273), 0, new byte[] { 88, 225, 228, 132, 157, 27, 204, 235, 67, 173, 200, 247, 187, 191, 11, 249, 239, 148, 161, 38, 252, 155, 248, 16, 147, 142, 121, 12, 252, 72, 254, 78, 211, 19, 23, 154, 62, 135, 71, 139, 133, 117, 225, 219, 41, 190, 66, 244, 142, 164, 127, 1, 72, 92, 244, 171, 115, 52, 9, 209, 17, 80, 242, 140 }, "ادمین", 0, new byte[] { 255, 95, 114, 75, 182, 241, 163, 200, 132, 158, 150, 162, 65, 87, 140, 95, 179, 228, 69, 163, 165, 14, 134, 187, 163, 112, 202, 173, 123, 52, 202, 34, 3, 166, 238, 152, 50, 154, 26, 200, 182, 58, 23, 140, 21, 39, 252, 143, 83, 139, 214, 232, 234, 130, 118, 188, 118, 94, 77, 140, 110, 45, 39, 135 }, "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroupUser_UsersId",
                table: "PermissionGroupUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPermissionGroup_PermissionsId",
                table: "PermissionPermissionGroup",
                column: "PermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUser_UsersId",
                table: "PermissionUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionGroupUser");

            migrationBuilder.DropTable(
                name: "PermissionPermissionGroup");

            migrationBuilder.DropTable(
                name: "PermissionUser");

            migrationBuilder.DropTable(
                name: "PermissionGroup");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
