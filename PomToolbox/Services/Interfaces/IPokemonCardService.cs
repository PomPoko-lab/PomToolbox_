using PomToolbox.Data.Models;
using PokemonCardApi = PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards.PokemonCard;

namespace PomToolbox.Services.Interfaces;

public interface IPokemonCardService
{
    PokemonCard ConvertApiCardToPokemonCard(PokemonCardApi card);
}