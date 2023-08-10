using System.ComponentModel.DataAnnotations;

namespace api_jornada_milhas.Models;

public class Depoimento
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string nome { get; set; }

    public string foto { get; set; }

    [Required]
    public string depoimento { get; set; }
    
}
