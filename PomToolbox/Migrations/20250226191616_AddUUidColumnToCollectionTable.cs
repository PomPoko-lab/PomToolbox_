using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PomToolbox.Migrations
{
    /// <inheritdoc />
    public partial class AddUUidColumnToCollectionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uuid",
                table: "PokemonCollections",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "PokemonCollections");
        }
    }
}
