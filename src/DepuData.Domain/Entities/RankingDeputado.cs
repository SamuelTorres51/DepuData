namespace DepuData.Domain.Entities;

public class RankingDeputado {
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Urlfoto { get; set; } = string.Empty;
    public decimal TotalGastos { get; set; }
}
