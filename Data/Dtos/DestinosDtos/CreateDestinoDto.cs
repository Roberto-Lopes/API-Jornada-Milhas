using System.ComponentModel.DataAnnotations;

namespace api_alura_challenge.Data.Dtos.DestinosDtos;

public class CreateDestinoDto
{
    [Required(ErrorMessage = "O nome do destino é obrigatório")]
    [MinLength(5, ErrorMessage = "O nome do destino deve possuir no mínimo 5 caracteres")]
    [MaxLength(255, ErrorMessage = "O nome do destino deve possuir no máximo 255 caracteres")]
    public string Nome { get; set; }

    public string Foto { get; set; }

    [Required(ErrorMessage = "O destino deve possuir um preço")]
    public double Preço { get; set; }

}
