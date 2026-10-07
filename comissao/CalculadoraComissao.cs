public static class CalculadoraComissao
{
    public static decimal ObterComissao(decimal valorVenda)
    {
        if(valorVenda < 100) 
            return 0.0m;
    
        if(valorVenda < 500)
            return valorVenda * 0.01m;
        else
            return valorVenda * 0.05m;
        
    }

    public static List<ResumoComissao> GerarRelatorioPorVendedor(List<Venda> vendas)
    {
        return vendas
            .GroupBy(v => v.Vendedor)
            .Select(grupo => new ResumoComissao
            {
                Vendedor = grupo.Key,
                TotalVendas = grupo.Count(),
                TotalComissao = Math.Round(
                    grupo.Sum(v => ObterComissao(v.Valor)), 2)
            })
            .ToList();
    }
}