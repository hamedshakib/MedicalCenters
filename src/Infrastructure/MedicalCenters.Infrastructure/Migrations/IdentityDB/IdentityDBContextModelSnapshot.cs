﻿// <auto-generated />
using System;
using MedicalCenters.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicalCenters.Persistence.Migrations.IdentityDB
{
    [DbContext(typeof(IdentityDBContext))]
    partial class IdentityDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MedicalCenters.Identity.Models.Domains.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2524),
                            Description = "افزودن مرکز درمانی",
                            Name = "AddMedicalCenter"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2527),
                            Description = "ویرایش مرکز درمانی",
                            Name = "EditMedicalCenter"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2528),
                            Description = "حذف مرکز درمانی",
                            Name = "DeleteMedicalCenter"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2530),
                            Description = "مشاهده اطلاعات مرکز درمانی",
                            Name = "SeeMedicalCenterInfo"
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2531),
                            Description = "مشاهده اطلاعات تمامی مراکز درمانی",
                            Name = "SeeAllMedicalCentersInfos"
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2532),
                            Description = "افزودن بخش درمانی",
                            Name = "AddMedicalWard"
                        },
                        new
                        {
                            Id = 7,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2533),
                            Description = "ویرایش بخش درمانی",
                            Name = "EditMedicalWard"
                        },
                        new
                        {
                            Id = 8,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2534),
                            Description = "حذف بخش درمانی",
                            Name = "DeleteMedicalWard"
                        },
                        new
                        {
                            Id = 9,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2535),
                            Description = "مشاهده اطلاعات بخش درمانی",
                            Name = "SeeMedicalWardInfo"
                        },
                        new
                        {
                            Id = 10,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2536),
                            Description = "مشاهده اطلاعات تمامی بخش های مرکز درمانی",
                            Name = "SeeAllMedicalCenterWardsInfos"
                        },
                        new
                        {
                            Id = 11,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2537),
                            Description = "افزودن دارو",
                            Name = "AddMedicine"
                        },
                        new
                        {
                            Id = 12,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2538),
                            Description = "ویرایش دارو",
                            Name = "EditMedicine"
                        },
                        new
                        {
                            Id = 13,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2539),
                            Description = "حذف دارو",
                            Name = "DeleteMedicine"
                        },
                        new
                        {
                            Id = 14,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2540),
                            Description = "مشاهده دارو ها",
                            Name = "SeeMedicines"
                        },
                        new
                        {
                            Id = 15,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2541),
                            Description = "مشاهده دارو های یک نوع",
                            Name = "SeeAllMedicineTypeMedicinesInfos"
                        });
                });

            modelBuilder.Entity("MedicalCenters.Identity.Models.Domains.PermissionGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("PermissionGroup");
                });

            modelBuilder.Entity("MedicalCenters.Identity.Models.Domains.PermissionGroup_User", b =>
                {
                    b.Property<int>("PermissionGroupId")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("PermissionGroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PermissionGroup_User");
                });

            modelBuilder.Entity("MedicalCenters.Identity.Models.Domains.Permission_PermissionGroup", b =>
                {
                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionGroupId")
                        .HasColumnType("int");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("PermissionId", "PermissionGroupId");

                    b.HasIndex("PermissionGroupId");

                    b.ToTable("Permission_PermissionGroup");
                });

            modelBuilder.Entity("MedicalCenters.Identity.Models.Domains.Permission_User", b =>
                {
                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("PermissionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Permission_User");
                });

            modelBuilder.Entity("MedicalCenters.Identity.Models.Domains.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("HashAlgorithmType")
                        .HasColumnType("int");

                    b.Property<byte[]>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PeaperType")
                        .HasColumnType("int");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 16, 19, 10, 29, 730, DateTimeKind.Local).AddTicks(2010),
                            HashAlgorithmType = 0,
                            HashedPassword = new byte[] { 203, 60, 34, 59, 109, 221, 144, 116, 30, 159, 154, 232, 52, 188, 60, 93, 41, 97, 87, 177, 44, 208, 244, 0, 84, 227, 113, 7, 156, 216, 236, 66, 149, 108, 17, 125, 174, 112, 61, 14, 152, 162, 248, 183, 71, 65, 58, 231, 67, 126, 200, 25, 193, 81, 76, 90, 10, 65, 131, 222, 252, 44, 93, 141 },
                            Name = "ادمین",
                            PeaperType = 0,
                            Salt = new byte[] { 237, 189, 17, 71, 1, 0, 177, 83, 203, 204, 61, 27, 218, 96, 55, 157, 185, 163, 40, 180, 113, 32, 138, 199, 212, 63, 191, 246, 87, 214, 103, 27, 241, 86, 73, 78, 38, 129, 197, 45, 168, 172, 209, 69, 164, 219, 233, 34, 49, 181, 158, 184, 87, 145, 171, 49, 0, 6, 209, 61, 56, 82, 179, 150 },
                            UserName = "Administrator"
                        });
                });

            modelBuilder.Entity("MedicalCenters.Identity.Models.Domains.PermissionGroup_User", b =>
                {
                    b.HasOne("MedicalCenters.Identity.Models.Domains.PermissionGroup", "PermissionGroup")
                        .WithMany()
                        .HasForeignKey("PermissionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCenters.Identity.Models.Domains.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicalCenters.Identity.Models.Domains.Permission_PermissionGroup", b =>
                {
                    b.HasOne("MedicalCenters.Identity.Models.Domains.PermissionGroup", "PermissionGroup")
                        .WithMany()
                        .HasForeignKey("PermissionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCenters.Identity.Models.Domains.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("PermissionGroup");
                });

            modelBuilder.Entity("MedicalCenters.Identity.Models.Domains.Permission_User", b =>
                {
                    b.HasOne("MedicalCenters.Identity.Models.Domains.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCenters.Identity.Models.Domains.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}