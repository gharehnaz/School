﻿// <auto-generated />
using System;
using ESchool.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ESchool.Infrastructure.Migrations
{
    [DbContext(typeof(ESchoolContext))]
    [Migration("20220619170717_teachercourse")]
    partial class teachercourse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ESchool.Domain.AccountAgg.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ProfilePhoto")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SchoolId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ESchool.Domain.AccountAgg.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClassRoomId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NationalCode")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ProfilePhoto")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ClassRoomId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ESchool.Domain.ClassRoomAgg.ClassRoom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Number")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int>("SchoolCode")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<long>("SchoolId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("ClassRoom");
                });

            modelBuilder.Entity("ESchool.Domain.CourseAgg.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<long>("ClassRoomId")
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.HasIndex("ClassRoomId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ESchool.Domain.RoleAgg.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreationDate = new DateTime(2022, 6, 19, 21, 37, 17, 263, DateTimeKind.Local).AddTicks(7290),
                            Name = "مدیر سیستم"
                        },
                        new
                        {
                            Id = 2L,
                            CreationDate = new DateTime(2022, 6, 19, 21, 37, 17, 268, DateTimeKind.Local).AddTicks(1279),
                            Name = "مدیر مدرسه"
                        },
                        new
                        {
                            Id = 3L,
                            CreationDate = new DateTime(2022, 6, 19, 21, 37, 17, 268, DateTimeKind.Local).AddTicks(1647),
                            Name = "معلم"
                        });
                });

            modelBuilder.Entity("ESchool.Domain.SchoolAgg.School", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<int>("Code")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.ToTable("School");
                });

            modelBuilder.Entity("ESchool.Domain.AccountAgg.Account", b =>
                {
                    b.HasOne("ESchool.Domain.RoleAgg.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ESchool.Domain.AccountAgg.Student", b =>
                {
                    b.HasOne("ESchool.Domain.ClassRoomAgg.ClassRoom", "ClassRoom")
                        .WithMany("Students")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassRoom");
                });

            modelBuilder.Entity("ESchool.Domain.ClassRoomAgg.ClassRoom", b =>
                {
                    b.HasOne("ESchool.Domain.SchoolAgg.School", "School")
                        .WithMany("ClassRooms")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("ESchool.Domain.CourseAgg.Course", b =>
                {
                    b.HasOne("ESchool.Domain.AccountAgg.Account", "Account")
                        .WithOne("Course")
                        .HasForeignKey("ESchool.Domain.CourseAgg.Course", "AccountId");

                    b.HasOne("ESchool.Domain.ClassRoomAgg.ClassRoom", "ClassRoom")
                        .WithMany("Courses")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("ClassRoom");
                });

            modelBuilder.Entity("ESchool.Domain.RoleAgg.Role", b =>
                {
                    b.OwnsMany("ESchool.Domain.RoleAgg.Permission", "Permissions", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Code")
                                .HasColumnType("int");

                            b1.Property<long>("RoleId")
                                .HasColumnType("bigint");

                            b1.HasKey("Id");

                            b1.HasIndex("RoleId");

                            b1.ToTable("RolePermissions");

                            b1.WithOwner("Role")
                                .HasForeignKey("RoleId");

                            b1.Navigation("Role");
                        });

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("ESchool.Domain.SchoolAgg.School", b =>
                {
                    b.HasOne("ESchool.Domain.AccountAgg.Account", "Account")
                        .WithOne("School")
                        .HasForeignKey("ESchool.Domain.SchoolAgg.School", "AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ESchool.Domain.AccountAgg.Account", b =>
                {
                    b.Navigation("Course");

                    b.Navigation("School");
                });

            modelBuilder.Entity("ESchool.Domain.ClassRoomAgg.ClassRoom", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("ESchool.Domain.RoleAgg.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("ESchool.Domain.SchoolAgg.School", b =>
                {
                    b.Navigation("ClassRooms");
                });
#pragma warning restore 612, 618
        }
    }
}
