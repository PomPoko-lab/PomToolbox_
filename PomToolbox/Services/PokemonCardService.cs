using PomToolbox.Data.Models;
using PomToolbox.Services.Interfaces;

using PokemonCardApi = PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards.PokemonCard;

namespace PomToolbox.Services;

public class PokemonCardService : IPokemonCardService {

    /// <summary>
    /// Converts an API PokemonCard into a PokemonCard.
    /// </summary>
    /// <param name="apiCard">The API PokemonCard to convert.</param>
    /// <returns>The converted PokemonCard.</returns>
    public PokemonCard ConvertApiCardToPokemonCard(PokemonCardApi apiCard) {
        DateTime formattedTcgPlayerUpdated = DateTime.Now;
        if (apiCard.Tcgplayer?.UpdatedAt != null) {
            formattedTcgPlayerUpdated = DateTime.ParseExact(
                apiCard.Tcgplayer.UpdatedAt.ToString(), 
                "yyyy/MM/dd",
                System.Globalization.CultureInfo.InvariantCulture);
        }
        PokemonCard card = new PokemonCard {
            ApiId = apiCard.Id,
            Name = apiCard.Name.ToString(),
            Number = apiCard.Number.ToString(),
            Set = apiCard.Set.Name.ToString(),
            Series = apiCard.Set.Series.ToString(),
            Rarity = apiCard.Rarity.ToString(),
            AverageTcgPlayerPrice = apiCard.Tcgplayer?.Prices?.Holofoil?.Market,
            TcgPlayerPriceLastUpdated = formattedTcgPlayerUpdated,
            TcgPlayerUrl = apiCard.Tcgplayer?.Url.ToString() ?? string.Empty,
            ImageUrlLarge = apiCard.Images.Large.ToString(),
            ImageUrlSmall = apiCard.Images.Small.ToString(),
        };

        return card;
    }
}