namespace PomToolbox.Services.Interfaces;

using System.Collections.Generic;
using PomToolbox.Data.Models;

public interface IPokemonCardRepository {
    public Task<PokemonCard> Create(PokemonCard card);
    public Task<List<PokemonCard>> Get();
    public Task<PokemonCard?> Get(int id);
    public Task<PokemonCard?> GetByApiId(string apiId);
    public Task<PokemonCard> Update(PokemonCard card);
    public Task Delete(PokemonCard card);
}