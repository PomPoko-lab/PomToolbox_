using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PomToolbox.Migrations
{
    /// <inheritdoc />
    public partial class AddedNumberAndTcgUrlToCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "PokemonCards",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TcgPlayerUrl",
                table: "PokemonCards",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "PokemonCards");

            migrationBuilder.DropColumn(
                name: "TcgPlayerUrl",
                table: "PokemonCards");
        }
    }
}
