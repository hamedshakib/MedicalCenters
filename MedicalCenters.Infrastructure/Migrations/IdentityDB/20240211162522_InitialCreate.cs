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
                name: "Permission_PermissionGroup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionGroupId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission_PermissionGroup", x => x.Id);
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission_User", x => x.Id);
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionGroupId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroup_User", x => x.Id);
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
                    { 1L, 1L, new DateTime(2024, 2, 11, 19, 55, 21, 773, DateTimeKind.Local).AddTicks(928), "افزودن مرکز درمانی", "AddMedicalCenter" },
                    { 2L, 1L, new DateTime(2024, 2, 11, 19, 55, 21, 773, DateTimeKind.Local).AddTicks(932), "ویرایش مرکز درمانی", "EditMedicalCenter" },
                    { 3L, 1L, new DateTime(2024, 2, 11, 19, 55, 21, 773, DateTimeKind.Local).AddTicks(933), "حذف مرکز درمانی", "DeleteMedicalCenter" },
                    { 4L, 1L, new DateTime(2024, 2, 11, 19, 55, 21, 773, DateTimeKind.Local).AddTicks(935), "مشاهده اطلاعات مرکز درمانی", "GetMedicalCenterInfo" },
                    { 5L, 1L, new DateTime(2024, 2, 11, 19, 55, 21, 773, DateTimeKind.Local).AddTicks(936), "مشاهده اطلاعات تمامی مراکز درمانی", "GetAllMedicalCenterInfos" },
                    { 6L, 1L, new DateTime(2024, 2, 11, 19, 55, 21, 773, DateTimeKind.Local).AddTicks(937), "افزودن بخش درمانی", "AddMedicalWard" },
                    { 7L, 1L, new DateTime(2024, 2, 11, 19, 55, 21, 773, DateTimeKind.Local).AddTicks(938), "ویرایش بخش درمانی", "EditMedicalWard" },
                    { 8L, 1L, new DateTime(2024, 2, 11, 19, 55, 21, 773, DateTimeKind.Local).AddTicks(940), "حذف بخش درمانی", "DeleteMedicalWard" },
                    { 9L, 1L, new DateTime(2024, 2, 11, 19, 55, 21, 773, DateTimeKind.Local).AddTicks(941), "مشاهده اطلاعات بخش درمانی", "GetMedicalWardInfo" },
                    { 10L, 1L, new DateTime(2024, 2, 11, 19, 55, 21, 773, DateTimeKind.Local).AddTicks(942), "مشاهده اطلاعات تمامی بخش های مرکز درمانی", "GetAllMedicalCenterWardsInfos" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "DateTimeCreated", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, 1L, new DateTime(2024, 2, 11, 19, 55, 21, 773, DateTimeKind.Local).AddTicks(305), 0, new byte[] { 213, 134, 157, 117, 158, 33, 199, 25, 230, 151, 160, 100, 64, 233, 215, 55, 158, 87, 201, 219, 76, 10, 84, 10, 44, 70, 38, 203, 34, 18, 125, 57, 50, 104, 127, 229, 106, 92, 212, 179, 210, 128, 127, 226, 93, 1, 55, 105, 62, 193, 231, 205, 233, 150, 50, 147, 170, 52, 162, 19, 44, 178, 119, 73 }, "ادمین", 0, new byte[] { 192, 218, 41, 195, 69, 27, 169, 124, 222, 79, 209, 189, 228, 128, 216, 252, 251, 130, 194, 131, 7, 129, 47, 70, 65, 70, 97, 49, 107, 18, 156, 148, 254, 142, 89, 150, 157, 25, 65, 41, 102, 34, 214, 60, 14, 189, 14, 65, 247, 47, 254, 211, 214, 15, 116, 160, 46, 140, 42, 111, 53, 157, 197, 34 }, "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionGroup_PermissionGroupId",
                table: "Permission_PermissionGroup",
                column: "PermissionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionGroup_PermissionId",
                table: "Permission_PermissionGroup",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_User_PermissionId",
                table: "Permission_User",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_User_UserId",
                table: "Permission_User",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroup_User_PermissionGroupId",
                table: "PermissionGroup_User",
                column: "PermissionGroupId");

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
