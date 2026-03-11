namespace DepuData.Infraestructure.ExternalAPis.Camara.Responses;

public class DeputadosResponse {
    public List<DeputadoApiResponse> Dados { get; set; } = [];
    public List<Link> Links { get; set; } = [];
}
