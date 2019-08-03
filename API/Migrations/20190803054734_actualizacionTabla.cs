using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class actualizacionTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Operacion",
                table: "Valor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operacion",
                table: "Valor");
        }
    }
}
