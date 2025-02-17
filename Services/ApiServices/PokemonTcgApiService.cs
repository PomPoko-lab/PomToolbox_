namespace PomToolbox.Services.ApiServices;

using PokemonTcgSdk.Standard.Features.FilterBuilder.Pokemon;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Base;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;
using PomToolbox.Services.Interfaces;

public class PokemonTcgApiService : IPokemonTcgApiService
{
    private readonly PokemonApiClient pokeclient;

    public PokemonTcgApiService() 
    {
        string? apiKey = Environment.GetEnvironmentVariable("POKEMONTCG_API_KEY");
        this.pokeclient = new PokemonApiClient(apiKey);
    }

    public async Task<List<PokemonCard>> GetPokemonByName(string name)
    {
        try 
        {
            var filter = PokemonFilterBuilder.CreatePokemonFilter().AddName(name);
            ApiResourceList<PokemonCard> response = await this.pokeclient.GetApiResourceAsync<PokemonCard>(10, 1, filter);
            List<PokemonCard> cards = response.Results;
            if (cards.Count == 0)
            {
                return [];
            }
            return cards;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"API Error: {ex.Message}");
            return [];
        }
    }
}