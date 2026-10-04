using System.Text.Json;

string comissao = Path.Combine(AppContext.BaseDirectory, "comissao.json");

if (File.Exists(comissao))
{
    string json = File.ReadAllText(comissao);
    var documento = JsonSerializer.Deserialize<RelatorioVendas>(json);

    CalculadoraComissao.ProcessarComissoes(documento.Vendas);
    var resumo = CalculadoraComissao.GerarRelatorioPorVendedor(documento.Vendas);

    Console.WriteLine("--- RESUMO DE COMISSÕES POR VENDEDOR ---");
    foreach (var item in resumo)
        Console.WriteLine(
            $"Vendedor: {item.Vendedor,-15} | Total Vendas: {item.TotalVendas,8} | Total Comissão: R$ {item.TotalComissao,6:N2}");       
    
}
else
{
    Console.WriteLine("Arquivo de vendas não encontrado.");
}