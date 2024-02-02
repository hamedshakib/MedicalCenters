using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace MedicalCenters.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalCenterType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCenterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalWardType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalWardType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialtyGroup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialtyGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalCenter",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<Point>(type: "geography", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCenter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalCenter_MedicalCenterType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MedicalCenterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergy",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicineTypeId = table.Column<long>(type: "bigint", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: true),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergy_MedicineType_MedicineTypeId",
                        column: x => x.MedicineTypeId,
                        principalTable: "MedicineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allergy_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientHistory_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationDT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalWard",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalCenterId = table.Column<long>(type: "bigint", nullable: true),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalWard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalWard_MedicalCenter_MedicalCenterId",
                        column: x => x.MedicalCenterId,
                        principalTable: "MedicalCenter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalWard_MedicalWardType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MedicalWardType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationId = table.Column<long>(type: "bigint", nullable: true),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visit_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visit_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalUnit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalWardId = table.Column<long>(type: "bigint", nullable: true),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalUnit_MedicalWard_MedicalWardId",
                        column: x => x.MedicalWardId,
                        principalTable: "MedicalWard",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationDT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    MedicalUnitId = table.Column<long>(type: "bigint", nullable: true),
                    PatientHistoryId = table.Column<long>(type: "bigint", nullable: true),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operation_MedicalUnit_MedicalUnitId",
                        column: x => x.MedicalUnitId,
                        principalTable: "MedicalUnit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Operation_OperationType_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalTable: "OperationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_PatientHistory_PatientHistoryId",
                        column: x => x.PatientHistoryId,
                        principalTable: "PatientHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicineTypeId = table.Column<long>(type: "bigint", nullable: false),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    PatientHistoryId = table.Column<long>(type: "bigint", nullable: true),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicine_MedicineType_MedicineTypeId",
                        column: x => x.MedicineTypeId,
                        principalTable: "MedicineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medicine_PatientHistory_PatientHistoryId",
                        column: x => x.PatientHistoryId,
                        principalTable: "PatientHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonnelCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    PatientHistoryId = table.Column<long>(type: "bigint", nullable: true),
                    VisitId = table.Column<long>(type: "bigint", nullable: true),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personel_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personel_PatientHistory_PatientHistoryId",
                        column: x => x.PatientHistoryId,
                        principalTable: "PatientHistory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personel_Visit_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShiftPlan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<long>(type: "bigint", nullable: false),
                    MedicalUnitId = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftPlan_MedicalUnit_MedicalUnitId",
                        column: x => x.MedicalUnitId,
                        principalTable: "MedicalUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftPlan_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorId = table.Column<long>(type: "bigint", nullable: true),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialty_Personel_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Personel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specialty_SpecialtyGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "SpecialtyGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftPlanId = table.Column<long>(type: "bigint", nullable: true),
                    PersonelId = table.Column<long>(type: "bigint", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_MedicalUnit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MedicalUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shifts_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shifts_ShiftPlan_ShiftPlanId",
                        column: x => x.ShiftPlanId,
                        principalTable: "ShiftPlan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergy_MedicineTypeId",
                table: "Allergy",
                column: "MedicineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergy_PatientId",
                table: "Allergy",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCenter_TypeId",
                table: "MedicalCenter",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalUnit_MedicalWardId",
                table: "MedicalUnit",
                column: "MedicalWardId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalWard_MedicalCenterId",
                table: "MedicalWard",
                column: "MedicalCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalWard_TypeId",
                table: "MedicalWard",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_MedicineTypeId",
                table: "Medicine",
                column: "MedicineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_OperationId",
                table: "Medicine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_PatientHistoryId",
                table: "Medicine",
                column: "PatientHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_MedicalUnitId",
                table: "Operation",
                column: "MedicalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_OperationTypeId",
                table: "Operation",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_PatientHistoryId",
                table: "Operation",
                column: "PatientHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistory_PatientId",
                table: "PatientHistory",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_OperationId",
                table: "Personel",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_PatientHistoryId",
                table: "Personel",
                column: "PatientHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_VisitId",
                table: "Personel",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PatientId",
                table: "Reservations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftPlan_MedicalUnitId",
                table: "ShiftPlan",
                column: "MedicalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftPlan_PersonelId",
                table: "ShiftPlan",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_PersonelId",
                table: "Shifts",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_ShiftPlanId",
                table: "Shifts",
                column: "ShiftPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_UnitId",
                table: "Shifts",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialty_DoctorId",
                table: "Specialty",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialty_GroupId",
                table: "Specialty",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_PatientId",
                table: "Visit",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_ReservationId",
                table: "Visit",
                column: "ReservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergy");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropTable(
                name: "MedicineType");

            migrationBuilder.DropTable(
                name: "ShiftPlan");

            migrationBuilder.DropTable(
                name: "SpecialtyGroup");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "MedicalUnit");

            migrationBuilder.DropTable(
                name: "OperationType");

            migrationBuilder.DropTable(
                name: "PatientHistory");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "MedicalWard");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "MedicalCenter");

            migrationBuilder.DropTable(
                name: "MedicalWardType");

            migrationBuilder.DropTable(
                name: "MedicalCenterType");
        }
    }
}
