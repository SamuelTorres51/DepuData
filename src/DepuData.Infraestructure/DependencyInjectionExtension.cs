using DepuData.Domain.Repositories;
using DepuData.Infraestructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DepuData.Infraestructure;

public static class DependencyInjectionExtension {
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services) {
        services.AddScoped<ICamaraDespesaRepository, CamaraDespesaRepository>();
    }
}
