using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;

namespace PomToolbox.Services.Interfaces
{
    public interface IPokemonTcgApiService
    {
        Task<List<PokemonCard>> GetPokemonByName(string name);
    }
}