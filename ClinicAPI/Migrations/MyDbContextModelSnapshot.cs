﻿// <auto-generated />
using System;
using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("ClinicAPI.Models.DoctorService", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("DoctorServices");
                });

            modelBuilder.Entity("ClinicAPI.Models.Revenue", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("ScheduleId")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Revenues");
                });

            modelBuilder.Entity("ClinicAPI.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ClinicAPI.Models.Schedule", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(40)");

                    b.Property<long>("DateTimeStamp")
                        .HasColumnType("bigint");

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ClinicAPI.Models.ScheduleService", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("ScheduleId")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("scheduleServices");
                });

            modelBuilder.Entity("ClinicAPI.Models.Service", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Price")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ClinicAPI.Models.UserPeople", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PassWord")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Sex")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<int>("YearOfBirth")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserPeoples");
                });

            modelBuilder.Entity("ClinicAPI.Models.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
