namespace DepuData.Infraestructure.ExternalAPis.Camara.Responses;

public class DeputadoApiResponse {
    public string Email { get; set; } = string.Empty;
    public int Id { get; set; }
    public int IdLegislatura { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string SiglaPartido { get; set; } = string.Empty;
    public string SiglaUf { get; set; } = string.Empty;
    public string Uri { get; set; } = string.Empty;
    public string UriPartido { get; set; } = string.Empty;
    public string UrlFoto { get; set; } = string.Empty;
}
