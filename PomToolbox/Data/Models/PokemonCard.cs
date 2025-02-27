using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PomToolbox.Data.Models;

public class PokemonCard
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(16)]
    public string ApiId { get; set; } = string.Empty;

    [Required]
    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Number { get; set; } = string.Empty;

    [Required]
    [MaxLength(32)]
    public string Set { get; set; } = string.Empty;

    [Required]
    [MaxLength(32)]
    public string Series { get; set; } = string.Empty;

    [Required]
    [MaxLength(64)]
    public string Rarity { get; set; } = string.Empty;

    [Precision(14, 2)]
    public double? AverageTcgPlayerPrice { get; set;}

    public DateTime TcgPlayerPriceLastUpdated { get; set; } = DateTime.Now;

    public string TcgPlayerUrl { get; set; } = string.Empty;

    [Required]
    [MaxLength(128)]
    public string ImageUrlLarge { get; set; } = string.Empty;

    [Required]
    [MaxLength(128)]
    public string ImageUrlSmall { get; set; } = string.Empty;

    public virtual ICollection<PokeCollectionCard>? PokeCollectionCards { get; set; } = [];

    public DateTime DateCreated { get; set; } = DateTime.Now;
}