namespace PomToolbox.Services.Interfaces;

using PokemonTcgSdk.Standard.Features.FilterBuilder.Pokemon;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Set;

public interface IPokemonTcgApiService
{
    Task<List<PokemonCard>> GetPokemonCards(PokemonFilterCollection<string, string>? filter);
    Task<List<Set>> GetSets();
}