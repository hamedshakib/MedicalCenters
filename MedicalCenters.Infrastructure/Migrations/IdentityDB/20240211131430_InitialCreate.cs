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
                    { 1L, 1L, new DateTime(2024, 2, 11, 16, 44, 30, 602, DateTimeKind.Local).AddTicks(7283), "افزودن مرکز درمانی", "AddMedicalCenter" },
                    { 2L, 1L, new DateTime(2024, 2, 11, 16, 44, 30, 602, DateTimeKind.Local).AddTicks(7286), "ویرایش مرکز درمانی", "EditMedicalCenter" },
                    { 3L, 1L, new DateTime(2024, 2, 11, 16, 44, 30, 602, DateTimeKind.Local).AddTicks(7287), "حذف مرکز درمانی", "DeleteMedicalCenter" },
                    { 4L, 1L, new DateTime(2024, 2, 11, 16, 44, 30, 602, DateTimeKind.Local).AddTicks(7288), "مشاهده اطلاعات مرکز درمانی", "GetMedicalCenterInfo" },
                    { 5L, 1L, new DateTime(2024, 2, 11, 16, 44, 30, 602, DateTimeKind.Local).AddTicks(7290), "مشاهده اطلاعات تمامی مراکز درمانی", "GetAllMedicalCenterInfos" },
                    { 6L, 1L, new DateTime(2024, 2, 11, 16, 44, 30, 602, DateTimeKind.Local).AddTicks(7291), "افزودن بخش درمانی", "AddMedicalWard" },
                    { 7L, 1L, new DateTime(2024, 2, 11, 16, 44, 30, 602, DateTimeKind.Local).AddTicks(7292), "ویرایش بخش درمانی", "EditMedicalWard" },
                    { 8L, 1L, new DateTime(2024, 2, 11, 16, 44, 30, 602, DateTimeKind.Local).AddTicks(7293), "حذف بخش درمانی", "DeleteMedicalWard" },
                    { 9L, 1L, new DateTime(2024, 2, 11, 16, 44, 30, 602, DateTimeKind.Local).AddTicks(7294), "مشاهده اطلاعات بخش درمانی", "GetMedicalWardInfo" },
                    { 10L, 1L, new DateTime(2024, 2, 11, 16, 44, 30, 602, DateTimeKind.Local).AddTicks(7295), "مشاهده اطلاعات تمامی بخش های مرکز درمانی", "GetAllMedicalCenterWardsInfos" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "DateTimeCreated", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, 1L, new DateTime(2024, 2, 11, 16, 44, 30, 602, DateTimeKind.Local).AddTicks(6277), 0, new byte[] { 131, 179, 4, 54, 97, 39, 87, 160, 148, 132, 103, 48, 182, 237, 155, 147, 199, 141, 3, 66, 149, 188, 226, 76, 168, 181, 111, 36, 254, 192, 104, 146, 71, 220, 95, 67, 47, 209, 215, 130, 230, 233, 136, 76, 83, 50, 3, 203, 212, 137, 69, 193, 169, 184, 213, 210, 95, 72, 134, 135, 192, 1, 23, 182 }, "ادمین", 0, new byte[] { 61, 109, 128, 159, 36, 230, 204, 88, 16, 222, 37, 3, 229, 9, 245, 38, 114, 222, 54, 105, 78, 33, 42, 245, 132, 45, 185, 126, 251, 31, 90, 196, 53, 242, 45, 96, 48, 169, 7, 10, 220, 137, 208, 175, 63, 193, 110, 191, 195, 13, 145, 56, 209, 242, 254, 74, 164, 227, 245, 239, 25, 106, 32, 30 }, "Administrator" });

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
