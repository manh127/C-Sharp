using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPI.Migrations
{
    public partial class addPreMedicine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreMedicine");
        }
    }
}
