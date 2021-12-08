using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPI.Migrations
{
    public partial class Revenues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Revenues",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", nullable: false),
                    ScheduleId = table.Column<string>(type: "varchar(40)", nullable: false),
                    ServiceId = table.Column<string>(type: "varchar(40)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "scheduleServices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", nullable: false),
                    ScheduleId = table.Column<string>(type: "varchar(40)", nullable: false),
                    ServiceId = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scheduleServices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Revenues");

            migrationBuilder.DropTable(
                name: "scheduleServices");
        }
    }
}
