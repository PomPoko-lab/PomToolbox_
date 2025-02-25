using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PomToolbox.Data.Models;

public class PokeCollectionCard
{
    [Key]
    public int Id { get; set; }
    // [ForeignKey("User")]
    // public int UserId { get; set; }

    [Required]
    [ForeignKey("PokemonCard")]
    public int PokemonCardId { get; set; }

    [Required]
    [ForeignKey("PokemonCollection")]
    public int PokemonCollectionId { get; set; }

    [Required]
    public DateTime DateCreated { get; set; } = DateTime.Now;
}