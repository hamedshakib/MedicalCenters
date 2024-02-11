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
                            DateTimeCreated = new DateTime(2024, 2, 11, 14, 5, 0, 249, DateTimeKind.Local).AddTicks(3805),
                            Description = "افزودن مرکز درمانی",
                            Name = "AddMedicalCenter"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 14, 5, 0, 249, DateTimeKind.Local).AddTicks(3808),
                            Description = "ویرایش مرکز درمانی",
                            Name = "EditMedicalCenter"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 14, 5, 0, 249, DateTimeKind.Local).AddTicks(3809),
                            Description = "حذف مرکز درمانی",
                            Name = "DeleteMedicalCenter"
                        },
                        new
                        {
                            Id = 4L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 14, 5, 0, 249, DateTimeKind.Local).AddTicks(3810),
                            Description = "مشاهده اطلاعات مرکز درمانی",
                            Name = "GetMedicalCenterInfo"
                        },
                        new
                        {
                            Id = 5L,
                            CreatedBy = 1L,
                            DateTimeCreated = new DateTime(2024, 2, 11, 14, 5, 0, 249, DateTimeKind.Local).AddTicks(3812),
                            Description = "مشاهده اطلاعات تمامی مراکز درمانی",
                            Name = "GetAllMedicalCenterInfos"
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
                            DateTimeCreated = new DateTime(2024, 2, 11, 14, 5, 0, 249, DateTimeKind.Local).AddTicks(3253),
                            HashAlgorithmType = 0,
                            HashedPassword = new byte[] { 44, 234, 234, 241, 59, 61, 186, 227, 130, 111, 49, 245, 180, 18, 63, 102, 234, 198, 252, 62, 143, 24, 68, 53, 57, 242, 193, 176, 95, 139, 10, 202, 185, 223, 180, 211, 179, 86, 197, 196, 97, 247, 150, 79, 28, 39, 174, 50, 57, 174, 56, 61, 99, 132, 208, 60, 158, 241, 220, 211, 184, 101, 164, 158 },
                            Name = "ادمین",
                            PeaperType = 0,
                            Salt = new byte[] { 134, 65, 77, 231, 151, 72, 189, 148, 185, 253, 46, 1, 114, 141, 249, 122, 84, 12, 227, 132, 229, 6, 151, 141, 68, 219, 210, 2, 73, 153, 216, 237, 111, 11, 132, 122, 62, 114, 164, 126, 245, 214, 97, 159, 28, 163, 136, 22, 53, 170, 180, 139, 216, 92, 233, 124, 174, 58, 53, 209, 149, 191, 214, 245 },
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