using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PomToolbox.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewColumnsToPokemonCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrlLarge",
                table: "PokemonCards",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrlSmall",
                table: "PokemonCards",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rarity",
                table: "PokemonCards",
                type: "TEXT",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrlLarge",
                table: "PokemonCards");

            migrationBuilder.DropColumn(
                name: "ImageUrlSmall",
                table: "PokemonCards");

            migrationBuilder.DropColumn(
                name: "Rarity",
                table: "PokemonCards");
        }
    }
}
