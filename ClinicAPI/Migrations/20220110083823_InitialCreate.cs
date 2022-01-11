using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorServices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(40)", nullable: false),
                    ServiceId = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "medicines",
                columns: table => new
                {
                    IdMedicine = table.Column<string>(type: "varchar(40)", nullable: false),
                    NameMedicine = table.Column<string>(nullable: true),
                    UseMedicine = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Quantily = table.Column<string>(nullable: true),
                    PriceMedicine = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicines", x => x.IdMedicine);
                });

            migrationBuilder.CreateTable(
                name: "PreMedicine",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", nullable: false),
                    IdPrescription = table.Column<string>(type: "varchar(40)", nullable: false),
                    IdMedicine = table.Column<string>(type: "varchar(40)", nullable: false),
                    QuantilyMedicine = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreMedicine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", nullable: false),
                    IdSchedule = table.Column<string>(type: "varchar(40)", nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<string>(nullable: true),
                    IdMedicine = table.Column<byte[]>(nullable: false),
                    NameMedicine = table.Column<string>(nullable: true),
                    UseMedicine = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Quantily = table.Column<int>(nullable: false),
                    PriceMedicine = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Revenues",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", nullable: false),
                    ScheduleId = table.Column<string>(type: "varchar(40)", nullable: false),
                    Time = table.Column<long>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", nullable: false),
                    DoctorId = table.Column<string>(type: "varchar(40)", nullable: false),
                    PatientId = table.Column<string>(type: "varchar(40)", nullable: false),
                    DateTimeStamp = table.Column<string>(type: "varchar(40)", nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ServiceId = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPeoples",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    YearOfBirth = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    IdentityCard = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Note1 = table.Column<string>(nullable: true),
                    Note2 = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPeoples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(40)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorServices");

            migrationBuilder.DropTable(
                name: "medicines");

            migrationBuilder.DropTable(
                name: "PreMedicine");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Revenues");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "UserPeoples");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
