using DepuData.Domain.Entities;
using DepuData.Domain.Repositories;
using DepuData.Infraestructure.ExternalAPis.Camara;

namespace DepuData.Infraestructure.Repositories;

public class CamaraDespesaRepository : ICamaraDespesaRepository {
    private readonly CamaraApiClient _apiClient;

    public CamaraDespesaRepository(CamaraApiClient apiClient) {
        _apiClient = apiClient;
    }

    public async Task<List<Deputado>> ObterDeputados() {
        var deputadosApi = await _apiClient.ObterDeputados();
        return deputadosApi.Select(d =>
            new Deputado(
                d.Id,
                d.Nome,
                d.SiglaPartido,
                d.SiglaUf,
                d.UrlFoto
            )
        ).ToList();
    }

    public async Task<List<Despesa>> ObterDespesasDeputado(int deputadoId) {
        var despesasApi = await _apiClient.ObterDespesasDeputado(deputadoId);

        return despesasApi.Select(d =>
            new Despesa(
                d.TipoDespesa,
                d.ValorLiquido,
                d.DataDocumento,
                d.NomeFornecedor
            )
        ).ToList();
    }
}
