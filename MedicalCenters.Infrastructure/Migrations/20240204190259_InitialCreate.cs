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
                name: "Allergy",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalCenterType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
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
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialtyGroup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Location = table.Column<Point>(type: "geography", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                name: "AllergyMedicineType",
                columns: table => new
                {
                    AllergiesId = table.Column<long>(type: "bigint", nullable: false),
                    MedicineTypesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyMedicineType", x => new { x.AllergiesId, x.MedicineTypesId });
                    table.ForeignKey(
                        name: "FK_AllergyMedicineType_Allergy_AllergiesId",
                        column: x => x.AllergiesId,
                        principalTable: "Allergy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergyMedicineType_MedicineType_MedicineTypesId",
                        column: x => x.MedicineTypesId,
                        principalTable: "MedicineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicine_MedicineType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MedicineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllergyPatient",
                columns: table => new
                {
                    AllergiesId = table.Column<long>(type: "bigint", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyPatient", x => new { x.AllergiesId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_AllergyPatient_Allergy_AllergiesId",
                        column: x => x.AllergiesId,
                        principalTable: "Allergy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergyPatient_Patient_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
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
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Personel_Id",
                        column: x => x.Id,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nurse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurse_Personel_Id",
                        column: x => x.Id,
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialty_SpecialtyGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "SpecialtyGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalWard",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
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
                        name: "FK_Visit_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientHistory_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientHistory_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecialty",
                columns: table => new
                {
                    DoctorsId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialtiesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecialty", x => new { x.DoctorsId, x.SpecialtiesId });
                    table.ForeignKey(
                        name: "FK_DoctorSpecialty_Doctor_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpecialty_Specialty_SpecialtiesId",
                        column: x => x.SpecialtiesId,
                        principalTable: "Specialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalUnit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
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
                name: "DoctorVisit",
                columns: table => new
                {
                    DoctorsId = table.Column<long>(type: "bigint", nullable: false),
                    VisitsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorVisit", x => new { x.DoctorsId, x.VisitsId });
                    table.ForeignKey(
                        name: "FK_DoctorVisit_Doctor_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorVisit_Visit_VisitsId",
                        column: x => x.VisitsId,
                        principalTable: "Visit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicinePatientHistory",
                columns: table => new
                {
                    MedicinesId = table.Column<long>(type: "bigint", nullable: false),
                    PatientHistoriesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinePatientHistory", x => new { x.MedicinesId, x.PatientHistoriesId });
                    table.ForeignKey(
                        name: "FK_MedicinePatientHistory_Medicine_MedicinesId",
                        column: x => x.MedicinesId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicinePatientHistory_PatientHistory_PatientHistoriesId",
                        column: x => x.PatientHistoriesId,
                        principalTable: "PatientHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "DoctorOperation",
                columns: table => new
                {
                    DoctorsId = table.Column<long>(type: "bigint", nullable: false),
                    OperationsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorOperation", x => new { x.DoctorsId, x.OperationsId });
                    table.ForeignKey(
                        name: "FK_DoctorOperation_Doctor_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorOperation_Operation_OperationsId",
                        column: x => x.OperationsId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineOperation",
                columns: table => new
                {
                    MedicinesId = table.Column<long>(type: "bigint", nullable: false),
                    OperationsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineOperation", x => new { x.MedicinesId, x.OperationsId });
                    table.ForeignKey(
                        name: "FK_MedicineOperation_Medicine_MedicinesId",
                        column: x => x.MedicinesId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineOperation_Operation_OperationsId",
                        column: x => x.OperationsId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
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
                    table.PrimaryKey("PK_Shift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shift_MedicalUnit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MedicalUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shift_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shift_ShiftPlan_ShiftPlanId",
                        column: x => x.ShiftPlanId,
                        principalTable: "ShiftPlan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergyMedicineType_MedicineTypesId",
                table: "AllergyMedicineType",
                column: "MedicineTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_AllergyPatient_PatientsId",
                table: "AllergyPatient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorOperation_OperationsId",
                table: "DoctorOperation",
                column: "OperationsId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialty_SpecialtiesId",
                table: "DoctorSpecialty",
                column: "SpecialtiesId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorVisit_VisitsId",
                table: "DoctorVisit",
                column: "VisitsId");

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
                name: "IX_Medicine_TypeId",
                table: "Medicine",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineOperation_OperationsId",
                table: "MedicineOperation",
                column: "OperationsId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePatientHistory_PatientHistoriesId",
                table: "MedicinePatientHistory",
                column: "PatientHistoriesId");

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
                name: "IX_PatientHistory_DoctorId",
                table: "PatientHistory",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistory_PatientId",
                table: "PatientHistory",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PatientId",
                table: "Reservation",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_PersonelId",
                table: "Shift",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_ShiftPlanId",
                table: "Shift",
                column: "ShiftPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_UnitId",
                table: "Shift",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftPlan_MedicalUnitId",
                table: "ShiftPlan",
                column: "MedicalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftPlan_PersonelId",
                table: "ShiftPlan",
                column: "PersonelId");

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
                name: "AllergyMedicineType");

            migrationBuilder.DropTable(
                name: "AllergyPatient");

            migrationBuilder.DropTable(
                name: "DoctorOperation");

            migrationBuilder.DropTable(
                name: "DoctorSpecialty");

            migrationBuilder.DropTable(
                name: "DoctorVisit");

            migrationBuilder.DropTable(
                name: "MedicineOperation");

            migrationBuilder.DropTable(
                name: "MedicinePatientHistory");

            migrationBuilder.DropTable(
                name: "Nurse");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Allergy");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "ShiftPlan");

            migrationBuilder.DropTable(
                name: "SpecialtyGroup");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "OperationType");

            migrationBuilder.DropTable(
                name: "PatientHistory");

            migrationBuilder.DropTable(
                name: "MedicineType");

            migrationBuilder.DropTable(
                name: "MedicalUnit");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "MedicalWard");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "MedicalCenter");

            migrationBuilder.DropTable(
                name: "MedicalWardType");

            migrationBuilder.DropTable(
                name: "MedicalCenterType");
        }
    }
}
