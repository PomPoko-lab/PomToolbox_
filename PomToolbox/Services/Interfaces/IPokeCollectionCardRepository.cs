namespace PomToolbox.Services.Interfaces;

using System.Collections.Generic;
using PomToolbox.Data.Models;

public interface IPokeCollectionCardRepository {
    public Task<PokeCollectionCard> Create(PokeCollectionCard association);
    public Task<PokeCollectionCard?> GetByCardId(int cardId);
    public Task<PokeCollectionCard?> GetByCollectionId(int collectionId);
    public Task Delete(PokeCollectionCard association);
}