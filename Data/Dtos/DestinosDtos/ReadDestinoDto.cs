namespace api_alura_challenge.Data.Dtos.DestinosDtos;

public class ReadDestinoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Foto { get; set; }
    public double Preço { get; set; }
    public DateTime HorarioDaConsulta { get; set; } = DateTime.Now;
}
