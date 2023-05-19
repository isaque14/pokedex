using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Infra.Data.Migrations
{
    public partial class UpdateTablePoke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EvolutionLine",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvolutionLine",
                table: "Pokemons");
        }
    }
}
