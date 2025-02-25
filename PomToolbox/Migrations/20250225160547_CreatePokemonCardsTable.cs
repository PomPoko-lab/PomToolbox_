using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PomToolbox.Migrations
{
    /// <inheritdoc />
    public partial class CreatePokemonCardsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokemonCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApiId = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Set = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Series = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    AverageTcgPlayerPrice = table.Column<double>(type: "REAL", precision: 14, scale: 2, nullable: true),
                    TcgPlayerPriceLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCards", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonCards");
        }
    }
}
