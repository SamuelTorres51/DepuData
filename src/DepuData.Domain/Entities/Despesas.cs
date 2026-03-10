namespace DepuData.Domain.Entities;

public class Despesas {
    public string Tipo { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
}
