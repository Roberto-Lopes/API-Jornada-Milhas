using System.ComponentModel.DataAnnotations;

namespace api_jornada_milhas.Data.Dtos.DestinosDtos;

public class CreateDestinoDto
{
    [Required(ErrorMessage = "São necessárias 2 fotos para o destino")]
    public string Foto_1 { get; set; }

    [Required(ErrorMessage = "São necessárias 2 fotos para o destino")]
    public string Foto_2 { get; set; }

    [Required(ErrorMessage = "O nome do destino é obrigatório")]
    [MinLength(5, ErrorMessage = "O nome do destino deve possuir no mínimo 5 caracteres")]
    [MaxLength(255, ErrorMessage = "O nome do destino deve possuir no máximo 255 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O destino deve possuir uma meta")]
    [MaxLength(160, ErrorMessage = "A meta deve possuir no máximo 160 caracteres")]
    public string Meta { get; set; }

    public string Texto_Descritivo { get; set; }
}
