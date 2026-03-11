using DepuData.Application.UseCases.Deputados.GetRankingGastos;
using Microsoft.Extensions.DependencyInjection;

namespace DepuData.Application;

public static class DependencyInjectionExtension {
    public static void AddApplication(this IServiceCollection services) {
        AddUseCases(services);
    }

    private static void AddUseCases(IServiceCollection services) {
        services.AddScoped<IGetRankingGastosUseCase, GetRankingGastosUseCase>();
    }
}