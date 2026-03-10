namespace DepuData.Domain.Entities;

public class Despesa {
    public string Tipo { get; private set; } = string.Empty;
    public decimal Valor { get; private set; }
    public string Data { get; private set; } = string.Empty;
    public string Fornecedor { get; private set; } = string.Empty;

    public Despesa(string tipo, decimal valor, string data, string fornecedor) {
        Tipo = tipo;
        Valor = valor;
        Data = data;
        Fornecedor = fornecedor;
    }
}
