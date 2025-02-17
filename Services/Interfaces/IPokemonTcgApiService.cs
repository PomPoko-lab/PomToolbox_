using PokemonTcgSdk.Standard.Features.FilterBuilder.Pokemon;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Set;

namespace PomToolbox.Services.Interfaces
{
    public interface IPokemonTcgApiService
    {
        Task<List<PokemonCard>> GetPokemonByName(PokemonFilterCollection<string, string>? filter);
        Task<List<Set>> GetSets();
    }
}