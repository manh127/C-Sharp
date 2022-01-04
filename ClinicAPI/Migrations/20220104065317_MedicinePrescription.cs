using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPI.Migrations
{
    public partial class MedicinePrescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicinePrescriptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinePrescriptions", x => x.Id);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicinePrescriptions");

            migrationBuilder.DropTable(
                name: "PreMedicine");
        }
    }
}
