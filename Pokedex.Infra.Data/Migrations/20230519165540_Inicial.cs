using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PokedexNumber = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvolutionStage = table.Column<int>(type: "int", nullable: false),
                    IsStarter = table.Column<bool>(type: "bit", nullable: false),
                    IsLegendary = table.Column<bool>(type: "bit", nullable: false),
                    IsMythical = table.Column<bool>(type: "bit", nullable: false),
                    IsUltraBeast = table.Column<bool>(type: "bit", nullable: false),
                    IsMega = table.Column<bool>(type: "bit", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Pokemons_Regions_RegionName",
                        column: x => x.RegionName,
                        principalTable: "Regions",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_RegionName",
                table: "Pokemons",
                column: "RegionName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
