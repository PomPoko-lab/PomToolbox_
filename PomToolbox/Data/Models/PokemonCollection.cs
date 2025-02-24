using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public DateTime DateCreated { get; set; } = DateTime.Now;
}