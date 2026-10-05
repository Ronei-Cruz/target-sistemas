using System.Text.Json.Serialization;

public class Estoque
{
    [JsonPropertyName("codigoProduto")]
    public int CodProduto { get; set; }
    [JsonPropertyName("descricaoProduto")]
    public string DesProduto { get; set; }
    [JsonPropertyName("estoque")]
    public int Quantidade { get; set; }
}

public class RelatorioEstoque
{
    [JsonPropertyName("estoque")]
    public List<Estoque> Estoque { get; set; }
}

public class ResumoEstoque
{
    public int CodProduto { get; set; }
    public string DesProduto { get; set; }
    public int Movimentacao { get; set; }
    public int Quantidade { get; set; }
}