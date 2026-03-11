namespace DepuData.Infraestructure.ExternalAPis.Camara.Responses;

public class DespesasResponse {
    public List<DespesaApiResponse> Dados { get; set; } = [];
    public List<Link> Links { get; set; } = [];
}
