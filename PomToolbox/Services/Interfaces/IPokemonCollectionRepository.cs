namespace PomToolbox.Services.Interfaces;

using System.Collections.Generic;
using PomToolbox.Data.Models;

public interface IPokemonCollectionRepository {
    public Task<PokemonCollection> Create(PokemonCollection collection);
    public Task<List<PokemonCollection>> Get();
    public Task<PokemonCollection?> Get(int id);
    public Task<PokemonCollection?> GetByUuid(string Uuid);
    public Task<PokemonCollection> Update(PokemonCollection collection);
    public Task Delete(PokemonCollection collection);
}