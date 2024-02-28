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
                    { 1, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2524), "افزودن مرکز درمانی", "AddMedicalCenter" },
                    { 2, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2527), "ویرایش مرکز درمانی", "EditMedicalCenter" },
                    { 3, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2528), "حذف مرکز درمانی", "DeleteMedicalCenter" },
                    { 4, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2530), "مشاهده اطلاعات مرکز درمانی", "SeeMedicalCenterInfo" },
                    { 5, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2531), "مشاهده اطلاعات تمامی مراکز درمانی", "SeeAllMedicalCentersInfos" },
                    { 6, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2532), "افزودن بخش درمانی", "AddMedicalWard" },
                    { 7, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2533), "ویرایش بخش درمانی", "EditMedicalWard" },
                    { 8, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2534), "حذف بخش درمانی", "DeleteMedicalWard" },
                    { 9, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2535), "مشاهده اطلاعات بخش درمانی", "SeeMedicalWardInfo" },
                    { 10, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2536), "مشاهده اطلاعات تمامی بخش های مرکز درمانی", "SeeAllMedicalCenterWardsInfos" },
                    { 11, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2537), "افزودن دارو", "AddMedicine" },
                    { 12, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2538), "ویرایش دارو", "EditMedicine" },
                    { 13, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2539), "حذف دارو", "DeleteMedicine" },
                    { 14, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2540), "مشاهده دارو ها", "SeeMedicines" },
                    { 15, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2541), "مشاهده دارو های یک نوع", "SeeAllMedicineTypeMedicinesInfos" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "DateTimeCreated", "HashAlgorithmType", "HashedPassword", "Name", "PeaperType", "Salt", "UserName" },
                values: new object[] { 1L, 1L, new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2010), 0, new byte[] { 203, 60, 34, 59, 109, 221, 144, 116, 30, 159, 154, 232, 52, 188, 60, 93, 41, 97, 87, 177, 44, 208, 244, 0, 84, 227, 113, 7, 156, 216, 236, 66, 149, 108, 17, 125, 174, 112, 61, 14, 152, 162, 248, 183, 71, 65, 58, 231, 67, 126, 200, 25, 193, 81, 76, 90, 10, 65, 131, 222, 252, 44, 93, 141 }, "ادمین", 0, new byte[] { 237, 189, 17, 71, 1, 0, 177, 83, 203, 204, 61, 27, 218, 96, 55, 157, 185, 163, 40, 180, 113, 32, 138, 199, 212, 63, 191, 246, 87, 214, 103, 27, 241, 86, 73, 78, 38, 129, 197, 45, 168, 172, 209, 69, 164, 219, 233, 34, 49, 181, 158, 184, 87, 145, 171, 49, 0, 6, 209, 61, 56, 82, 179, 150 }, "Administrator" });

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
