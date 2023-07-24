using System.ComponentModel.DataAnnotations;

namespace api_alura_challenge.Models;

public class Destino
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string nome { get; set; }

    public string foto { get; set; }

    [Required]
    public double preço { get; set; }
}
