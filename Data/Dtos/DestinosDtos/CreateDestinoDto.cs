using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace api_jornada_milhas.Data.Dtos.DestinosDtos;

public class CreateDestinoDto
{
    [AllowNull]
    public string? foto_1 { get; set; }

    [AllowNull]
    public string? foto_2 { get; set; }

    [Required(ErrorMessage = "O nome do destino é obrigatório")]
    [MinLength(5, ErrorMessage = "O nome do destino deve possuir no mínimo 5 caracteres")]
    [MaxLength(255, ErrorMessage = "O nome do destino deve possuir no máximo 255 caracteres")]
    public string nome { get; set; }

    [Required(ErrorMessage = "O destino deve possuir uma meta")]
    [MaxLength(160, ErrorMessage = "A meta deve possuir no máximo 160 caracteres")]
    public string meta { get; set; }

    [AllowNull]
    public string? texto_descritivo { get; set; }
}
