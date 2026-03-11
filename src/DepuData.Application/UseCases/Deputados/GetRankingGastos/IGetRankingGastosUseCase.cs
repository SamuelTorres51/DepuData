using DepuData.Application.DTOs.Responses;

namespace DepuData.Application.UseCases.Deputados.GetRankingGastos;

public interface IGetRankingGastosUseCase {
    Task<List<GetRankingGastosResponse>> Execute();
}
