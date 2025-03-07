using System.Text;
using PokemonTcgSdk.Standard.Features.FilterBuilder.Pokemon;
using PomToolbox.Data.Models;
using PomToolbox.Data.Repositories;
using PomToolbox.Services.ApiServices;
using PomToolbox.Services.Interfaces;

using PokemonCardApi = PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards.PokemonCard;

namespace PomToolbox.Services;

public class PokemonCollectionService : IPokemonCollectionService {
    private readonly IPokemonCardRepository _pokemonCardRepository;
    private readonly IPokemonCardService _pokemonCardService;
    private readonly IPokemonTcgApiService _pokemonTcgApiService;

    public PokemonCollectionService(
        IPokemonCardRepository pokemonCardRepository,
        IPokemonCardService pokemonCardService,
        IPokemonTcgApiService pokemonTcgApiService
        ) {
        this._pokemonCardRepository = pokemonCardRepository;
        this._pokemonCardService = pokemonCardService;
        this._pokemonTcgApiService = pokemonTcgApiService;
    }

    public async Task GetUpdatedCollectionCards(PokemonCollection collection) {
        PokemonFilterCollection<string, string> pokemonCardsFilter = PokemonFilterBuilder.CreatePokemonFilter();

        List<PokemonCard> cards = [];
        if (collection.PokeCollectionCards != null) {
            cards = [.. collection.PokeCollectionCards.Select(pc => pc.PokemonCard)];
        }

        if (cards.Count == 0) {
            throw new Exception("Collection has no cards");
        }

        Dictionary<string, bool> addedIds = [];
        StringBuilder idsBuilder = new StringBuilder();
        foreach (PokemonCard card in cards) {
            if (addedIds.ContainsKey(card.ApiId)) {
                continue;
            }
            idsBuilder.Append(card.ApiId).Append(',');
            addedIds.Add(card.ApiId, true);
        }

        string idsFilter = idsBuilder.ToString().TrimEnd(',');
        pokemonCardsFilter.Add("id", idsFilter);

        List<PokemonCardApi> fetchedCards = await _pokemonTcgApiService.GetPokemonCards(pokemonCardsFilter);
        if (fetchedCards.Count == 0) {
            throw new Exception("No cards were found");
        }

        foreach (PokemonCardApi card in fetchedCards) {
            PokemonCard convertedCard = _pokemonCardService.ConvertApiCardToPokemonCard(card);
            await _pokemonCardRepository.UpdateByMatchingApiId(convertedCard);
        }
    }
}