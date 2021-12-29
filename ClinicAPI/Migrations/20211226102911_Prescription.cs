using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPI.Migrations
{
    public partial class Prescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Time",
                table: "Revenues",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdMedicine = table.Column<string>(type: "varchar(40)", nullable: false),
                    NameMedicine = table.Column<string>(nullable: true),
                    UseMedicine = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Quantily = table.Column<int>(nullable: false),
                    PriceMedicine = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdMedicine);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Revenues",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
