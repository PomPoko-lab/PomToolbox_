using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PomToolbox.Data.Models;

public class PokeCollectionCard
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PokemonCardId { get; set; }

    [ForeignKey("PokemonCardId")]
    public virtual PokemonCard? PokemonCard { get; set; }

    [Required]
    public int PokemonCollectionId { get; set; }

    [ForeignKey("PokemonCollectionId")]
    public virtual PokemonCollection? PokemonCollection { get; set; }

    [Required]
    public DateTime DateCreated { get; set; } = DateTime.Now;
}