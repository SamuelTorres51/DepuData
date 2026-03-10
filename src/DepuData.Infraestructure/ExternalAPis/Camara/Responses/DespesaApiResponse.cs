namespace DepuData.Infraestructure.ExternalAPis.Camara.Responses;

public class DespesaApiResponse {
    public int Ano { get; set; }
    public string CnpjCpfFornecedor { get; set; } = string.Empty;
    public string CodDocumento { get; set; } = string.Empty;
    public int CodLote { get; set; }
    public int CodTipoDocumento { get; set; }
    public string DataDocumento { get; set; } = string.Empty;
    public int Mes { get; set; }
    public string NomeFornecedor { get; set; } = string.Empty;
    public string NumDocumento { get; set; } = string.Empty;
    public string NumRessarcimento { get; set; } = string.Empty;
    public int Parcela { get; set; }
    public string TipoDespesa { get; set; } = string.Empty;
    public string TipoDocumento { get; set; } = string.Empty;
    public string UrlDocumento { get; set; } = string.Empty;
    public decimal ValorDocumento { get; set; }
    public decimal ValorGlosa { get; set; }
    public decimal ValorLiquido { get; set; }
}
