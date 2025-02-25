using Microsoft.EntityFrameworkCore;
using PomToolbox.Data.Models;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<PokemonCollection> PokemonCollections { get; set; }
    public DbSet<PokemonCard> PokemonCards { get; set;}
    public DbSet<PokeCollectionCard> PokeCollectionCards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PokeCollectionCard>()
            .HasKey(pc => pc.Id);
        
        // Creates the one-to-many relationship between PokemonCard and PokeCollectionCard
        modelBuilder.Entity<PokeCollectionCard>()
            .HasOne(pc => pc.PokemonCard)
            .WithMany(pc => pc.PokeCollectionCards)
            .HasForeignKey(pc => pc.PokemonCardId);
        
        // Creates the one-to-many relationship between PokemonCollection and PokeCollectionCard
        modelBuilder.Entity<PokeCollectionCard>()
            .HasOne(pc => pc.PokemonCollection)
            .WithMany(pc => pc.PokeCollectionCards)
            .HasForeignKey(pc => pc.PokemonCollectionId);
    }
}