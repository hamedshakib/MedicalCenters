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
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

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
                            Id = 1L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1826),
                            Description = "افزودن مرکز درمانی",
                            Name = "AddMedicalCenter"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1828),
                            Description = "ویرایش مرکز درمانی",
                            Name = "EditMedicalCenter"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1829),
                            Description = "حذف مرکز درمانی",
                            Name = "DeleteMedicalCenter"
                        },
                        new
                        {
                            Id = 4L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1830),
                            Description = "مشاهده اطلاعات مرکز درمانی",
                            Name = "GetMedicalCenterInfo"
                        },
                        new
                        {
                            Id = 5L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1831),
                            Description = "مشاهده اطلاعات تمامی مراکز درمانی",
                            Name = "GetAllMedicalCenterInfos"
                        },
                        new
                        {
                            Id = 6L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1832),
                            Description = "افزودن بخش درمانی",
                            Name = "AddMedicalWard"
                        },
                        new
                        {
                            Id = 7L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1833),
                            Description = "ویرایش بخش درمانی",
                            Name = "EditMedicalWard"
                        },
                        new
                        {
                            Id = 8L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1835),
                            Description = "حذف بخش درمانی",
                            Name = "DeleteMedicalWard"
                        },
                        new
                        {
                            Id = 9L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1836),
                            Description = "مشاهده اطلاعات بخش درمانی",
                            Name = "GetMedicalWardInfo"
                        },
                        new
                        {
                            Id = 10L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1837),
                            Description = "مشاهده اطلاعات تمامی بخش های مرکز درمانی",
                            Name = "GetAllMedicalCenterWardsInfos"
                        });
                });

            modelBuilder.Entity("MedicalCenters.Identity.Models.Domains.PermissionGroup", b =>
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
                            DateTimeCreated = new DateTime(2024, 2, 11, 18, 51, 17, 193, DateTimeKind.Local).AddTicks(1273),
                            HashAlgorithmType = 0,
                            HashedPassword = new byte[] { 88, 225, 228, 132, 157, 27, 204, 235, 67, 173, 200, 247, 187, 191, 11, 249, 239, 148, 161, 38, 252, 155, 248, 16, 147, 142, 121, 12, 252, 72, 254, 78, 211, 19, 23, 154, 62, 135, 71, 139, 133, 117, 225, 219, 41, 190, 66, 244, 142, 164, 127, 1, 72, 92, 244, 171, 115, 52, 9, 209, 17, 80, 242, 140 },
                            Name = "ادمین",
                            PeaperType = 0,
                            Salt = new byte[] { 255, 95, 114, 75, 182, 241, 163, 200, 132, 158, 150, 162, 65, 87, 140, 95, 179, 228, 69, 163, 165, 14, 134, 187, 163, 112, 202, 173, 123, 52, 202, 34, 3, 166, 238, 152, 50, 154, 26, 200, 182, 58, 23, 140, 21, 39, 252, 143, 83, 139, 214, 232, 234, 130, 118, 188, 118, 94, 77, 140, 110, 45, 39, 135 },
                            UserName = "Administrator"
                        });
                });

            modelBuilder.Entity("PermissionGroupUser", b =>
                {
                    b.Property<long>("PermissionGroupsId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("PermissionGroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("PermissionGroupUser");
                });

            modelBuilder.Entity("PermissionPermissionGroup", b =>
                {
                    b.Property<long>("PermissionGroupsId")
                        .HasColumnType("bigint");

                    b.Property<long>("PermissionsId")
                        .HasColumnType("bigint");

                    b.HasKey("PermissionGroupsId", "PermissionsId");

                    b.HasIndex("PermissionsId");

                    b.ToTable("PermissionPermissionGroup");
                });

            modelBuilder.Entity("PermissionUser", b =>
                {
                    b.Property<long>("PermissionsId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("PermissionsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("PermissionUser");
                });

            modelBuilder.Entity("PermissionGroupUser", b =>
                {
                    b.HasOne("MedicalCenters.Identity.Models.Domains.PermissionGroup", null)
                        .WithMany()
                        .HasForeignKey("PermissionGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCenters.Identity.Models.Domains.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PermissionPermissionGroup", b =>
                {
                    b.HasOne("MedicalCenters.Identity.Models.Domains.PermissionGroup", null)
                        .WithMany()
                        .HasForeignKey("PermissionGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCenters.Identity.Models.Domains.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PermissionUser", b =>
                {
                    b.HasOne("MedicalCenters.Identity.Models.Domains.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCenters.Identity.Models.Domains.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
