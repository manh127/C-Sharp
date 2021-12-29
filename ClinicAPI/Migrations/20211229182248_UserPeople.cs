using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPI.Migrations
{
    public partial class UserPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "UserPeoples",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityCard",
                table: "UserPeoples",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "UserPeoples",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note1",
                table: "UserPeoples",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note2",
                table: "UserPeoples",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "UserPeoples");

            migrationBuilder.DropColumn(
                name: "IdentityCard",
                table: "UserPeoples");

            migrationBuilder.DropColumn(
                name: "Job",
                table: "UserPeoples");

            migrationBuilder.DropColumn(
                name: "Note1",
                table: "UserPeoples");

            migrationBuilder.DropColumn(
                name: "Note2",
                table: "UserPeoples");
        }
    }
}
