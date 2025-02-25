namespace PomToolbox.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using PomToolbox.Data.Models;
using PomToolbox.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PokeCollectionCardRepository : IPokeCollectionCardRepository {
    private readonly ApplicationDbContext _db;

    public PokeCollectionCardRepository(ApplicationDbContext db) {
        this._db = db;
    }

    public async Task<PokeCollectionCard> Create(PokeCollectionCard association) {
        await this._db.PokeCollectionCards.AddAsync(association);
        await this._db.SaveChangesAsync();
        return association;
    }

    public async Task<List<PokeCollectionCard>> Get() {
        return await this._db.PokeCollectionCards.ToListAsync();
    }

    public async Task<PokeCollectionCard?> GetByCardId(int cardId) {
        return await this._db.PokeCollectionCards.FirstOrDefaultAsync(pc => pc.PokemonCardId == cardId);
    }

    public async Task<PokeCollectionCard?> GetByCollectionId(int collectionId) {
        return await this._db.PokeCollectionCards.FirstOrDefaultAsync(pc => pc.PokemonCollectionId == collectionId);
    }

    public async Task Delete(PokeCollectionCard association) {
        this._db.PokeCollectionCards.Remove(association);
        await this._db.SaveChangesAsync();
    }
}