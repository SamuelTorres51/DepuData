using DepuData.Infraestructure.ExternalAPis.Camara.Responses;
using System.Net.Http.Json;


namespace DepuData.Infraestructure.ExternalAPis.Camara;

public class CamaraApiClient {
    private readonly HttpClient _httpClient;

    public CamaraApiClient(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<List<DespesaApiResponse>> ObterDespesasDeputado(int deputadoId) {
        var response = await _httpClient.GetFromJsonAsync<CamaraResponse>(
            $"deputados/{deputadoId}/despesas");

        if(response is not null)
            return response.Dados;

        return new List<DespesaApiResponse>();
    }
}
