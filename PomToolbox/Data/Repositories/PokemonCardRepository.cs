namespace PomToolbox.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using PomToolbox.Data.Models;
using PomToolbox.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PokemonCardRepository : IPokemonCardRepository {
    private readonly ApplicationDbContext _db;

    public PokemonCardRepository(ApplicationDbContext db) {
        this._db = db;
    }

    public async Task<PokemonCard> Create(PokemonCard card) {
        await this._db.PokemonCards.AddAsync(card);
        await this._db.SaveChangesAsync();
        return card;
    }

    public async Task<List<PokemonCard>> Get() {
        return await this._db.PokemonCards.ToListAsync();
    }

    public async Task<PokemonCard?> Get(int id) {
        return await this._db.PokemonCards.FindAsync(id);
    }

    public async Task<PokemonCard?> GetByApiId(string apiId) {
        return await this._db.PokemonCards.FirstOrDefaultAsync(pc => pc.ApiId == apiId);
    }

    public async Task<PokemonCard> Update(PokemonCard card) {
        this._db.PokemonCards.Update(card);
        await this._db.SaveChangesAsync();
        return card;
    }

    public async Task Delete(PokemonCard card) {
        this._db.PokemonCards.Remove(card);
        await this._db.SaveChangesAsync();
    }
}