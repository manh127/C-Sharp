using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPI.Migrations
{
    public partial class schedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Schedules");

            migrationBuilder.AlterColumn<string>(
                name: "DateTimeStamp",
                table: "Schedules",
                type: "varchar(40)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "DateTimeStamp",
                table: "Schedules",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)");

            migrationBuilder.AddColumn<string>(
                name: "ServiceId",
                table: "Schedules",
                type: "varchar(40)",
                nullable: false,
                defaultValue: "");
        }
    }
}
