using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPI.Migrations
{
    public partial class TenBang1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicines");
        }
    }
}
