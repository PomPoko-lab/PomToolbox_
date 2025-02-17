namespace PomToolbox.Services.ApiServices;

using System.Text;
using PokemonTcgSdk.Standard.Features.FilterBuilder.Pokemon;
using PokemonTcgSdk.Standard.Features.FilterBuilder.Set;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Base;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Set;
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
        try {
            var filter = PokemonFilterBuilder.CreatePokemonFilter().AddName(name + "*");
            ApiResourceList<PokemonCard> response = await this.pokeclient.GetApiResourceAsync<PokemonCard>(filter);
            List<PokemonCard> cards = response.Results;

            return cards;
        } catch (Exception ex) {
            Console.WriteLine($"API Error: {ex.Message}");
            return [];
        }
    }

    public async Task<List<Set>> GetSets() {
        try {
            var filter = SetFilterBuilder.CreateSetFilter();
            List<string> series = [
                "Sword & Shield",
                "Scarlet & Violet",
                "Sun & Moon",
                "XY",
            ];

            var seriesFilterBuilder = new StringBuilder();
            foreach (string s in series) {
                seriesFilterBuilder.Append(s).Append(',');
            }

            string seriesFilter = seriesFilterBuilder.ToString().TrimEnd(',');
            filter.Add("series", seriesFilter);

            ApiResourceList<Set> response = await this.pokeclient.GetApiResourceAsync<Set>(filter);
            List<Set> sets = response.Results;

            return sets;
        } catch (Exception ex) {
            Console.WriteLine($"API Error: {ex.Message}");
            return [];
        }
    }
}