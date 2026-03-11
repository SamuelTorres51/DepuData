namespace DepuData.Application.DTOs.Responses;

public class GetRankingGastosResponse {
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string UrlFoto { get; set; } = string.Empty;
    public decimal TotalGastos { get; set; }
}
