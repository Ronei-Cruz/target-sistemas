using System.Text.Json.Serialization;

public class Venda
{
    [JsonPropertyName("vendedor")]
    public string Vendedor { get; set; }
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}

public class RelatorioVendas
{
    [JsonPropertyName("vendas")]
    public List<Venda> Vendas { get; set; }
}

public class ResumoComissao
{
    public string Vendedor { get; set; }
    public int TotalVendas { get; set; }
    public decimal TotalComissao { get; set; }

}

