using DepuData.Infraestructure.ExternalAPis.Camara.Responses;
using System.Net.Http.Json;


namespace DepuData.Infraestructure.ExternalAPis.Camara;

public class CamaraApiClient {
    private const int ItensPorPagina = 100;
    private const int MaxPaginasSeguranca = 500;

    private readonly HttpClient _httpClient;

    public CamaraApiClient(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<List<DeputadoApiResponse>> ObterDeputados() {
        var response = await _httpClient.GetFromJsonAsync<DeputadosResponse>("deputados");
        if(response is not null)
            return response.Dados;
        return new List<DeputadoApiResponse>();
    }


    public async Task<List<DespesaApiResponse>> ObterDespesasDeputado(int deputadoId) {
        var todas = new List<DespesaApiResponse>();

        // Mantém seus critérios atuais, mas com paginação + 100 itens por página
        string? url = $"deputados/{deputadoId}/despesas?itens={ItensPorPagina}&ordem=ASC&ordenarPor=ano";

        for (var pagina = 1; pagina <= MaxPaginasSeguranca && url is not null; pagina++) {
            var response = await _httpClient.GetFromJsonAsync<DespesasResponse>(url);

            if (response is null)
                break;

            if (response.Dados.Count > 0)
                todas.AddRange(response.Dados);

            url = response.Links.FirstOrDefault(l => string.Equals(l.Rel, "next", StringComparison.OrdinalIgnoreCase))?.Href;
        }

        return todas;
    }
}
