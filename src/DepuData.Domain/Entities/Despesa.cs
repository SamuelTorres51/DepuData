namespace DepuData.Domain.Entities;

public class Despesa {
    public string Tipo { get; private set; } = string.Empty;
    public decimal Valor { get; private set; }
    public DateTime Data { get; private set; }
    public string Fornecedor { get; private set; } = string.Empty;
}
