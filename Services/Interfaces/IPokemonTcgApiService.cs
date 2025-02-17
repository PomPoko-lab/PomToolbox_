using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Set;

namespace PomToolbox.Services.Interfaces
{
    public interface IPokemonTcgApiService
    {
        Task<List<PokemonCard>> GetPokemonByName(string name);
        Task<List<Set>> GetSets();
    }
}