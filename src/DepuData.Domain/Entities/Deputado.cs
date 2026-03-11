namespace DepuData.Domain.Entities;

public class Deputado {
    public int Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Partido { get; private set; } = string.Empty;
    public string Estado { get; private set;  } = string.Empty;
    public string UrlFoto { get; private set; } = string.Empty;
    public List<Despesa> Despesas { get; private set; } = [];

    public Deputado(int id, string nome, string partido, string estado, string urlfoto) {
        Id = id;
        Nome = nome;
        Partido = partido;
        Estado = estado;
        UrlFoto = urlfoto;
    }
}
