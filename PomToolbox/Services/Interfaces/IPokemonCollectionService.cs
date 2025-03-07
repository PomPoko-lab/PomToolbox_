using PomToolbox.Data.Models;

namespace PomToolbox.Services.Interfaces;

public interface IPokemonCollectionService
{
    Task GetUpdatedCollectionCards(PokemonCollection collection);
}