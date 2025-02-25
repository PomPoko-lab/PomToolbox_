using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PomToolbox.Migrations
{
    /// <inheritdoc />
    public partial class CreatePokeCollectionCardsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokeCollectionCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PokemonCardId = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonCollectionId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokeCollectionCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokeCollectionCards_PokemonCards_PokemonCardId",
                        column: x => x.PokemonCardId,
                        principalTable: "PokemonCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokeCollectionCards_PokemonCollections_PokemonCollectionId",
                        column: x => x.PokemonCollectionId,
                        principalTable: "PokemonCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokeCollectionCards_PokemonCardId",
                table: "PokeCollectionCards",
                column: "PokemonCardId");

            migrationBuilder.CreateIndex(
                name: "IX_PokeCollectionCards_PokemonCollectionId",
                table: "PokeCollectionCards",
                column: "PokemonCollectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokeCollectionCards");
        }
    }
}
