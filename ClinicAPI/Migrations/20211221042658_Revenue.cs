using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPI.Migrations
{
    public partial class Revenue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Services",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "Schedules",
                type: "varchar(40)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Revenues",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Revenues");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Services",
                type: "text",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ServiceId",
                table: "Schedules",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)");
        }
    }
}
