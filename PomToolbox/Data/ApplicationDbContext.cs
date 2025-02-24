using Microsoft.EntityFrameworkCore;
using PomToolbox.Data.Models;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<PokemonCollection> PokemonCollections { get; set; }
}