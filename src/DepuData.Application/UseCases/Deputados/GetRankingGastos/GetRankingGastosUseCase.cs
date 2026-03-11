using DepuData.Application.DTOs.Responses;
using DepuData.Domain.Entities;
using DepuData.Domain.Repositories;

namespace DepuData.Application.UseCases.Deputados.GetRankingGastos;

public class GetRankingGastosUseCase : IGetRankingGastosUseCase{
    private readonly ICamaraDespesaRepository _repository;

    public GetRankingGastosUseCase(ICamaraDespesaRepository repository) {
        _repository = repository;
    }

    public async Task<List<GetRankingGastosResponse>> Execute() {
        var deputados = await _repository.ObterDeputados();

        var tasks = deputados.Select(async deputado =>
        {
            var despesas = await _repository.ObterDespesasDeputado(deputado.Id);

            return new RankingDeputado {
                Id = deputado.Id,
                Nome = deputado.Nome,
                Urlfoto = deputado.UrlFoto,
                TotalGastos = despesas.Sum(d => d.Valor)
            };
        });

        var ranking = await Task.WhenAll(tasks);

        var rankingOrdenado = ranking.OrderByDescending(r => r.TotalGastos).ToList();

        var response = rankingOrdenado.Select(r => new GetRankingGastosResponse {
            Id = r.Id,
            Nome = r.Nome,
            UrlFoto = r.Urlfoto,
            TotalGastos = r.TotalGastos
        }).ToList();

        return response;
    }
}
