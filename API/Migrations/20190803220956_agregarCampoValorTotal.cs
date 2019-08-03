using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class agregarCampoValorTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ValorTotal",
                table: "Usuario",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Usuario");
        }
    }
}
