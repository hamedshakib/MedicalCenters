﻿// <auto-generated />
using System;
using MedicalCenters.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

#nullable disable

namespace MedicalCenters.Persistence.Migrations
{
    [DbContext(typeof(MedicalCentersDBContext))]
    partial class MedicalCentersDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Allergy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MedicineTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PatientId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MedicineTypeId");

                    b.HasIndex("PatientId");

                    b.ToTable("Allergy");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Base.Personel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonnelCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personel");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Personel");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.MedicalCenter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MedicalCenter");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.MedicalUnit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("MedicalWardId")
                        .HasColumnType("bigint");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MedicalWardId");

                    b.ToTable("MedicalUnit");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.MedicalWard", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("MedicalCenterId")
                        .HasColumnType("bigint");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MedicalCenterId");

                    b.ToTable("MedicalWard");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Medicines.Medicine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<long>("MedicineTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PatientHistoryId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MedicineTypeId");

                    b.HasIndex("PatientHistoryId");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Medicines.MedicineType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("TypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MedicineType");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Oprerations.Operation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<long?>("MedicalUnitId")
                        .HasColumnType("bigint");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<long?>("PatientHistoryId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MedicalUnitId");

                    b.HasIndex("PatientHistoryId");

                    b.ToTable("Operation");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Oprerations.OperationType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OperationType");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Patients.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Patients.PatientHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("PatientId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientHistory");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Reservation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("PatientId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ReservationDT")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Shift", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("PersonelId")
                        .HasColumnType("bigint");

                    b.Property<long>("ShiftPlanId")
                        .HasColumnType("bigint");

                    b.Property<long>("UnitId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.HasIndex("ShiftPlanId");

                    b.HasIndex("UnitId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.ShiftPlan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<long>("MedicalUnitId")
                        .HasColumnType("bigint");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("PersonelId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MedicalUnitId");

                    b.HasIndex("PersonelId");

                    b.ToTable("ShiftPlan");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Visit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("PatientId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ReservationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Visit");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Staffs.Doctor", b =>
                {
                    b.HasBaseType("MedicalCenters.Domain.Classes.Base.Personel");

                    b.Property<long?>("PatientHistoryId")
                        .HasColumnType("bigint");

                    b.Property<long?>("VisitId")
                        .HasColumnType("bigint");

                    b.HasIndex("PatientHistoryId");

                    b.HasIndex("VisitId");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Staffs.Nurse", b =>
                {
                    b.HasBaseType("MedicalCenters.Domain.Classes.Base.Personel");

                    b.HasDiscriminator().HasValue("Nurse");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Allergy", b =>
                {
                    b.HasOne("MedicalCenters.Domain.Classes.Medicines.MedicineType", "MedicineType")
                        .WithMany()
                        .HasForeignKey("MedicineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCenters.Domain.Classes.Patients.Patient", null)
                        .WithMany("Allergies")
                        .HasForeignKey("PatientId");

                    b.Navigation("MedicineType");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.MedicalUnit", b =>
                {
                    b.HasOne("MedicalCenters.Domain.Classes.MedicalWard", null)
                        .WithMany("Units")
                        .HasForeignKey("MedicalWardId");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.MedicalWard", b =>
                {
                    b.HasOne("MedicalCenters.Domain.Classes.MedicalCenter", null)
                        .WithMany("Wards")
                        .HasForeignKey("MedicalCenterId");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Medicines.Medicine", b =>
                {
                    b.HasOne("MedicalCenters.Domain.Classes.Medicines.MedicineType", "MedicineType")
                        .WithMany()
                        .HasForeignKey("MedicineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCenters.Domain.Classes.Patients.PatientHistory", null)
                        .WithMany("Medicines")
                        .HasForeignKey("PatientHistoryId");

                    b.Navigation("MedicineType");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Oprerations.Operation", b =>
                {
                    b.HasOne("MedicalCenters.Domain.Classes.MedicalUnit", null)
                        .WithMany("PossibleOperations")
                        .HasForeignKey("MedicalUnitId");

                    b.HasOne("MedicalCenters.Domain.Classes.Patients.PatientHistory", null)
                        .WithMany("Operations")
                        .HasForeignKey("PatientHistoryId");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Patients.PatientHistory", b =>
                {
                    b.HasOne("MedicalCenters.Domain.Classes.Patients.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Reservation", b =>
                {
                    b.HasOne("MedicalCenters.Domain.Classes.Patients.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Shift", b =>
                {
                    b.HasOne("MedicalCenters.Domain.Classes.Base.Personel", "Personel")
                        .WithMany()
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCenters.Domain.Classes.ShiftPlan", "ShiftPlan")
                        .WithMany()
                        .HasForeignKey("ShiftPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCenters.Domain.Classes.MedicalUnit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");

                    b.Navigation("ShiftPlan");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.ShiftPlan", b =>
                {
                    b.HasOne("MedicalCenters.Domain.Classes.MedicalUnit", "MedicalUnit")
                        .WithMany()
                        .HasForeignKey("MedicalUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCenters.Domain.Classes.Base.Personel", "Personel")
                        .WithMany()
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalUnit");

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Visit", b =>
                {
                    b.HasOne("MedicalCenters.Domain.Classes.Patients.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCenters.Domain.Classes.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId");

                    b.Navigation("Patient");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Staffs.Doctor", b =>
                {
                    b.HasOne("MedicalCenters.Domain.Classes.Patients.PatientHistory", null)
                        .WithMany("Doctors")
                        .HasForeignKey("PatientHistoryId");

                    b.HasOne("MedicalCenters.Domain.Classes.Visit", null)
                        .WithMany("Doctors")
                        .HasForeignKey("VisitId");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.MedicalCenter", b =>
                {
                    b.Navigation("Wards");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.MedicalUnit", b =>
                {
                    b.Navigation("PossibleOperations");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.MedicalWard", b =>
                {
                    b.Navigation("Units");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Patients.Patient", b =>
                {
                    b.Navigation("Allergies");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Patients.PatientHistory", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("Medicines");

                    b.Navigation("Operations");
                });

            modelBuilder.Entity("MedicalCenters.Domain.Classes.Visit", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
