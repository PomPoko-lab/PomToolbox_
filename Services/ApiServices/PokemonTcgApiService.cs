namespace PomToolbox.Services.ApiServices;

using PokemonTcgSdk.Standard.Infrastructure.HttpClients;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;
using PomToolbox.Services.Interfaces;

public class PokemonTcgApiService : IPokemonTcgApiService
{
    private readonly IConfiguration _configuration;
    private readonly PokemonApiClient pokeclient;

    public PokemonTcgApiService(IConfiguration configuration) 
    {
        this._configuration = configuration;
        this.pokeclient = new PokemonApiClient(_configuration["POKEMONTCG_API_KEY"]);
    }

    public async Task<string> GetPokemonByName(string name)
    {
        var card = await this.pokeclient.GetApiResourceAsync<PokemonCard>(take: 10, skip: 2);
        return card.ToString();
    }
}