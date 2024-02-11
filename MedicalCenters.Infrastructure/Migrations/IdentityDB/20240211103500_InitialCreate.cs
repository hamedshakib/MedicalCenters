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
                    { 1L, 1L, new DateTime(2024, 2, 11, 14, 5, 0, 249, DateTimeKind.Local).AddTicks(3805), "افزودن مرکز درمانی", "AddMedicalCenter" },
                    { 2L, 1L, new DateTime(2024, 2, 11, 14, 5, 0, 249, DateTimeKind.Local).AddTicks(3808), "ویرایش مرکز درمانی", "EditMedicalCenter" },
                    { 3L, 1L, new DateTime(2024, 2, 11, 14, 5, 0, 249, DateTimeKind.Local).AddTicks(3809), "حذف مرکز درمانی", "DeleteMedicalCenter" },
                    { 4L, 1L, new DateTime(2024, 2, 11, 14, 5, 0, 249, DateTimeKind.Local).AddTicks(3810), "مشاهده اطلاعات مرکز درمانی", "GetMedicalCenterInfo" },
                    { 5L, 1L, new DateTime(2024, 2, 11, 14, 5, 0, 249, DateTimeKind.Local).AddTicks(3812), "مشاهده اطلاعات تمامی مراکز درمانی", "GetAllMedicalCenterInfos" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "DateTimeCreated", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, 1L, new DateTime(2024, 2, 11, 14, 5, 0, 249, DateTimeKind.Local).AddTicks(3253), 0, new byte[] { 44, 234, 234, 241, 59, 61, 186, 227, 130, 111, 49, 245, 180, 18, 63, 102, 234, 198, 252, 62, 143, 24, 68, 53, 57, 242, 193, 176, 95, 139, 10, 202, 185, 223, 180, 211, 179, 86, 197, 196, 97, 247, 150, 79, 28, 39, 174, 50, 57, 174, 56, 61, 99, 132, 208, 60, 158, 241, 220, 211, 184, 101, 164, 158 }, "ادمین", 0, new byte[] { 134, 65, 77, 231, 151, 72, 189, 148, 185, 253, 46, 1, 114, 141, 249, 122, 84, 12, 227, 132, 229, 6, 151, 141, 68, 219, 210, 2, 73, 153, 216, 237, 111, 11, 132, 122, 62, 114, 164, 126, 245, 214, 97, 159, 28, 163, 136, 22, 53, 170, 180, 139, 216, 92, 233, 124, 174, 58, 53, 209, 149, 191, 214, 245 }, "Administrator" });

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
