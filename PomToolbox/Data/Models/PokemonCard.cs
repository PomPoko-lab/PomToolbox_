using System.ComponentModel.DataAnnotations;

namespace PomToolbox.Data.Models;

public class PokemonCard
{
    [Key]
    public int Id { get; set; }
    // [ForeignKey("User")]
    // public int UserId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(32)]
    public string Set { get; set; } = string.Empty;

    [Required]
    [MaxLength(32)]
    public string Series { get; set; } = string.Empty;


    public double AverageTcgPlayerPrice { get; set;} = 0.00;

    public DateTime DateCreated { get; set; } = DateTime.Now;
}