namespace PomToolbox.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using PomToolbox.Data.Models;
using PomToolbox.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PokemonCollectionRepository : IPokemonCollectionRepository{
    private readonly ApplicationDbContext _db;

    public PokemonCollectionRepository(ApplicationDbContext db) {
        this._db = db;
    }

    public async Task<PokemonCollection> Create(PokemonCollection collection) {
        await this._db.PokemonCollections.AddAsync(collection);
        await this._db.SaveChangesAsync();
        return collection;
    }

    public async Task<List<PokemonCollection>> Get() {
        return await this._db.PokemonCollections.ToListAsync();
    }

    public async Task<PokemonCollection?> Get(int id) {
        return await this._db.PokemonCollections.FindAsync(id);
    }

    public async Task<PokemonCollection> Update(PokemonCollection collection) {
        this._db.PokemonCollections.Update(collection);
        await this._db.SaveChangesAsync();
        return collection;
    }

    public async Task Delete(PokemonCollection collection) {
        this._db.PokemonCollections.Remove(collection);
        await this._db.SaveChangesAsync();
    }

    // public async Task<List<PokemonCollection>> GetByUserId(int userId) {
    //     return await this._db.PokemonCollections.Where(x => x.UserId == userId).ToListAsync();
    // }
}