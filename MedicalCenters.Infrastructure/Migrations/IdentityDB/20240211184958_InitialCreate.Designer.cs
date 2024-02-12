﻿// <auto-generated />
using System;
using MedicalCenters.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicalCenters.Persistence.Migrations.IdentityDB
{
    [DbContext(typeof(IdentityDBContext))]
    [Migration("20240211184958_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            DateTimeCreated = new DateTime(2024, 2, 11, 22, 19, 58, 25, DateTimeKind.Local).AddTicks(5510),
                            Description = "افزودن مرکز درمانی",
                            Name = "AddMedicalCenter"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 22, 19, 58, 25, DateTimeKind.Local).AddTicks(5513),
                            Description = "ویرایش مرکز درمانی",
                            Name = "EditMedicalCenter"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 22, 19, 58, 25, DateTimeKind.Local).AddTicks(5514),
                            Description = "حذف مرکز درمانی",
                            Name = "DeleteMedicalCenter"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 22, 19, 58, 25, DateTimeKind.Local).AddTicks(5515),
                            Description = "مشاهده اطلاعات مرکز درمانی",
                            Name = "GetMedicalCenterInfo"
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 22, 19, 58, 25, DateTimeKind.Local).AddTicks(5516),
                            Description = "مشاهده اطلاعات تمامی مراکز درمانی",
                            Name = "GetAllMedicalCenterInfos"
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 22, 19, 58, 25, DateTimeKind.Local).AddTicks(5519),
                            Description = "افزودن بخش درمانی",
                            Name = "AddMedicalWard"
                        },
                        new
                        {
                            Id = 7,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 22, 19, 58, 25, DateTimeKind.Local).AddTicks(5520),
                            Description = "ویرایش بخش درمانی",
                            Name = "EditMedicalWard"
                        },
                        new
                        {
                            Id = 8,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 22, 19, 58, 25, DateTimeKind.Local).AddTicks(5521),
                            Description = "حذف بخش درمانی",
                            Name = "DeleteMedicalWard"
                        },
                        new
                        {
                            Id = 9,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 22, 19, 58, 25, DateTimeKind.Local).AddTicks(5523),
                            Description = "مشاهده اطلاعات بخش درمانی",
                            Name = "GetMedicalWardInfo"
                        },
                        new
                        {
                            Id = 10,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 22, 19, 58, 25, DateTimeKind.Local).AddTicks(5524),
                            Description = "مشاهده اطلاعات تمامی بخش های مرکز درمانی",
                            Name = "GetAllMedicalCenterWardsInfos"
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
                            DateTimeCreated = new DateTime(2024, 2, 11, 22, 19, 58, 25, DateTimeKind.Local).AddTicks(4598),
                            HashAlgorithmType = 0,
                            HashedPassword = new byte[] { 177, 61, 55, 15, 206, 166, 179, 63, 22, 5, 248, 161, 254, 136, 238, 32, 18, 48, 127, 203, 156, 188, 85, 161, 138, 105, 148, 174, 115, 177, 73, 167, 253, 26, 179, 102, 155, 3, 105, 150, 225, 36, 57, 249, 193, 107, 24, 103, 116, 86, 160, 111, 187, 156, 209, 213, 11, 108, 194, 80, 169, 208, 83, 100 },
                            Name = "ادمین",
                            PeaperType = 0,
                            Salt = new byte[] { 159, 54, 184, 219, 157, 143, 180, 119, 192, 147, 67, 184, 54, 204, 248, 114, 68, 105, 129, 252, 58, 29, 116, 196, 14, 37, 6, 176, 146, 132, 249, 157, 29, 195, 35, 236, 19, 135, 215, 47, 109, 183, 243, 147, 187, 243, 190, 93, 14, 110, 84, 207, 89, 112, 89, 94, 222, 47, 108, 130, 242, 166, 68, 38 },
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