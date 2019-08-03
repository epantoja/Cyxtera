using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AgregarCampoSigno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Signo",
                table: "Valor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Signo",
                table: "Valor");
        }
    }
}
