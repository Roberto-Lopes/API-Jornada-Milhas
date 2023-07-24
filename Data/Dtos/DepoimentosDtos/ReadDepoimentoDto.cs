namespace api_alura_challenge.Data.Dtos.DepoimentosDtos;

public class ReadDepoimentoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Foto { get; set; }
    public string Depoimento { get; set; }
    public DateTime HorarioDaConsulta { get; set; } = DateTime.Now;

}
