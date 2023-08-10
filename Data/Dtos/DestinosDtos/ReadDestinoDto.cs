namespace api_jornada_milhas.Data.Dtos.DestinosDtos;

public class ReadDestinoDto
{
    public int Id { get; set; }
    public string Foto_1 { get; set; }

    public string Foto_2 { get; set; }

    public string Nome { get; set; }

    public string Meta { get; set; }

    public string Texto_Descritivo { get; set; }

    public DateTime HorarioDaConsulta { get; set; } = DateTime.Now;
}
