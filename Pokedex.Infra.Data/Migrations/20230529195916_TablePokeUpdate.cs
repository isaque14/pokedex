using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Infra.Data.Migrations
{
    public partial class TablePokeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pokemons",
                table: "Pokemons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pokemons",
                table: "Pokemons",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pokemons",
                table: "Pokemons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pokemons",
                table: "Pokemons",
                column: "Name");
        }
    }
}
