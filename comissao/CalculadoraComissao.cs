public static class CalculadoraComissao
{
    public static double ObterComissao(double valorVenda)
    {
        if(valorVenda < 100) 
            return 0.0;
    
        if(valorVenda < 500)
            return Math.Round(valorVenda * 0.01, 2);
        else
            return Math.Round(valorVenda * 0.05, 2);
        
    }

    public static void ProcessarComissoes(List<Venda> vendas)
    {
        foreach (var venda in vendas)
        {
            double comissao = ObterComissao(venda.Valor);
        }
    }

    public static List<ResumoComissao> GerarRelatorioPorVendedor(List<Venda> vendas)
    {
        return vendas
            .GroupBy(v => v.Vendedor)
            .Select(grupo => new ResumoComissao
            {
                Vendedor = grupo.Key,
                TotalVendas = grupo.Count(),
                TotalComissao = Math.Round(grupo.Sum(v => ObterComissao(v.Valor)), 2)
            })
            .ToList();
    }
}