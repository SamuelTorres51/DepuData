namespace DepuData.Infraestructure.ExternalAPis.Camara.Responses;

public class CamaraResponse {
    public List<DespesaApiResponse> Dados { get; set; } = [];
    public List<Link> Links { get; set; } = [];
}
