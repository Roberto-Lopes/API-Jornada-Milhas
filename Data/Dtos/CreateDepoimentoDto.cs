using System.ComponentModel.DataAnnotations;

namespace api_alura_challenge.Data.Dtos;

public class CreateDepoimentoDto
{
    [Required(ErrorMessage = "O nome do criador do depoimento é obrigatório")]
    [MinLength(10, ErrorMessage = "O nome do criador deve possuir no mínimo 10 caracteres")]
    [StringLength(255, ErrorMessage = "O nome do criador deve possuir no máximo 255 caracteres")]
    public string Nome { get; set; }

    public string Foto { get; set; }

    [Required(ErrorMessage = "O depoimento não pode estar em branco")]
    [MinLength(10, ErrorMessage = "O depoimento deve possuir no mínimo 10 caracteres")]

    public string Depoimento { get; set; }
}
