using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace api_jornada_milhas.Models;

public class Destino
{
    [Key]
    [Required]
    public int Id { get; set; }

    [AllowNull]
    public string? foto_1 { get; set; }

    [AllowNull]
    public string? foto_2 { get; set; }

    [Required]
    public string nome { get; set; }

    [Required]
    [MaxLength(160)]
    public string meta { get; set; }

    [AllowNull]
    public string? texto_descritivo { get; set; }
}
