using System.ComponentModel.DataAnnotations;

namespace PomToolbox.Data.Models;

public class PokemonCollection
{
    [Key]
    public int Id { get; set; }
    // [ForeignKey("User")]
    // public int UserId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<PokeCollectionCard>? PokeCollectionCards { get; set; } = [];

    public DateTime DateCreated { get; set; } = DateTime.Now;
}