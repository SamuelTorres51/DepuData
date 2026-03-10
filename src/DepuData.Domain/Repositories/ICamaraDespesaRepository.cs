using DepuData.Domain.Entities;

namespace DepuData.Domain.Repositories;

public interface ICamaraDespesaRepository {
    Task<List<Despesa>> ObterDespesasDeputado(int deputadoId);
}
