using System.ComponentModel.DataAnnotations;

namespace api_alura_challenge.Models;

public class Destino
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string foto_1 { get; set; }

    [Required]
    public string foto_2 { get; set; }

    [Required]
    public string nome { get; set; }

    [Required]
    [MaxLength(160)]
    public string meta { get; set; }

    public string texto_descritivo { get; set; }
}
