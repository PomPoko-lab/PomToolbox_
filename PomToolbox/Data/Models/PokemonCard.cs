using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PomToolbox.Data.Models;

public class PokemonCard
{
    [Key]
    public int Id { get; set; }
    // [ForeignKey("User")]
    // public int UserId { get; set; }
    [Required]
    [MaxLength(16)]
    public string ApiId { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(32)]
    public string Set { get; set; } = string.Empty;

    [Required]
    [MaxLength(32)]
    public string Series { get; set; } = string.Empty;

    [Precision(14, 2)]
    public double? AverageTcgPlayerPrice { get; set;} = 0.00;

    [Required]
    public DateTime TcgPlayerPriceLastUpdated { get; set; } = DateTime.Now;

    public virtual ICollection<PokeCollectionCard>? PokeCollectionCards { get; set; } = [];

    [Required]
    public DateTime DateCreated { get; set; } = DateTime.Now;
}