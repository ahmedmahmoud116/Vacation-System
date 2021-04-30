﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Data.DBContexts;

namespace Data.Migrations
{
    [DbContext(typeof(VacationContext))]
    [Migration("20210328083059_fkv1")]
    partial class fkv1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VacationForm.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(254)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            ID = 4572,
                            BirthDate = new DateTime(1998, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ahmed@gmail.com",
                            FullName = "Ahmed Mahmouud",
                            Gender = "Male"
                        },
                        new
                        {
                            ID = 4777,
                            BirthDate = new DateTime(1998, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "marwan@gmail.com",
                            FullName = "Marwan Salem",
                            Gender = "Male"
                        },
                        new
                        {
                            ID = 4999,
                            BirthDate = new DateTime(1999, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "nadine@gmail.com",
                            FullName = "Nadine Ahmed",
                            Gender = "Female"
                        });
                });

            modelBuilder.Entity("VacationForm.Models.EmployeeBalance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("VacationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("VacationID");

                    b.ToTable("EmployeeBalances");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Balance = 7,
                            EmployeeID = 4572,
                            VacationID = 1
                        },
                        new
                        {
                            ID = 2,
                            Balance = 14,
                            EmployeeID = 4572,
                            VacationID = 2
                        },
                        new
                        {
                            ID = 3,
                            Balance = 5,
                            EmployeeID = 4777,
                            VacationID = 1
                        },
                        new
                        {
                            ID = 4,
                            Balance = 12,
                            EmployeeID = 4777,
                            VacationID = 2
                        },
                        new
                        {
                            ID = 5,
                            Balance = 7,
                            EmployeeID = 4999,
                            VacationID = 1
                        },
                        new
                        {
                            ID = 6,
                            Balance = 14,
                            EmployeeID = 4999,
                            VacationID = 2
                        });
                });

            modelBuilder.Entity("VacationForm.Models.EmployeeRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("VacationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("VacationID");

                    b.ToTable("EmployeeRequests");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Days = 3,
                            EmployeeID = 4572,
                            VacationID = 1
                        },
                        new
                        {
                            ID = 2,
                            Days = 5,
                            EmployeeID = 4777,
                            VacationID = 2
                        },
                        new
                        {
                            ID = 3,
                            Days = 6,
                            EmployeeID = 4999,
                            VacationID = 2
                        },
                        new
                        {
                            ID = 4,
                            Days = 2,
                            EmployeeID = 4572,
                            VacationID = 1
                        });
                });

            modelBuilder.Entity("VacationForm.Models.Vacation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Vacations");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Balance = 7,
                            Type = "casual"
                        },
                        new
                        {
                            ID = 2,
                            Balance = 14,
                            Type = "schedule"
                        });
                });

            modelBuilder.Entity("VacationForm.Models.EmployeeBalance", b =>
                {
                    b.HasOne("VacationForm.Models.Employee", "Employee")
                        .WithMany("EmployeeBalance")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VacationForm.Models.Vacation", "Vacation")
                        .WithMany("EmployeeBalance")
                        .HasForeignKey("VacationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VacationForm.Models.EmployeeRequest", b =>
                {
                    b.HasOne("VacationForm.Models.Employee", "Employee")
                        .WithMany("EmployeeRequest")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VacationForm.Models.Vacation", "Vacation")
                        .WithMany("EmployeeRequest")
                        .HasForeignKey("VacationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
