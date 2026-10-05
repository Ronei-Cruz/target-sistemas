public static class MovimentacaoEstoque
{
    public static void AtualizarEstoque(List<Estoque> estoque, List<Estoque> vendas)
    {
        foreach (var venda in vendas)
        {
            var produto = estoque.FirstOrDefault(e => e.CodProduto == venda.CodProduto);
            if (produto != null)
            {
                produto.Quantidade -= venda.Quantidade;
            }
        }
    }

    public static void AdicionarProduto(int codProduto, string desProduto, int quantidade, List<Estoque> estoque)
    {
        Console.Clear();
        var resumo = new List<Estoque>();
        var produtoExistente = estoque.FirstOrDefault(e => e.CodProduto == codProduto);
        if (produtoExistente != null)
        {
            Console.WriteLine($"Produto existente: {produtoExistente.DesProduto}, Quantidade atual: {produtoExistente.Quantidade}");
            Console.WriteLine("Deseja continuar? (S/N)");
            string continuar = Console.ReadLine();
            if (continuar.ToUpper() == "S")
            {
                produtoExistente.Quantidade += quantidade;
            }
        }
        else
        {
            estoque.Add(new Estoque
            {
                CodProduto = codProduto,
                DesProduto = desProduto,
                Quantidade = quantidade
            });
        }

        resumo.Add(new Estoque
        {
            CodProduto = codProduto,
            Quantidade = produtoExistente?.Quantidade ?? quantidade
        });
    }

    public static void RemoverProduto( int codProduto, int quantidade, List<Estoque> estoque)
    {
        Console.Clear();
        var produtoExistente = estoque.FirstOrDefault(e => e.CodProduto == codProduto);
        if (produtoExistente != null && produtoExistente.Quantidade >= quantidade)
        {
            produtoExistente.Quantidade -= quantidade;
        }
        var produtoAtualizado = estoque.FirstOrDefault(e => e.CodProduto == codProduto);
        if (produtoAtualizado != null && produtoAtualizado.Quantidade == 0)
        {
            estoque.Remove(produtoAtualizado);
        }
    }

    public static void ListarProdutos(List<Estoque> estoque)
    {
        Console.Clear();
        Console.WriteLine("\n=== RESUMO DE ESTOQUE ===\n");
        foreach (var item in estoque)
            Console.WriteLine(
                $"Produto: {item.CodProduto,-5} | Descrição: {item.DesProduto,-25} | Estoque: {item.Quantidade,6}");
    }
    
    public static void PressionarParaContinuar()
    {
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey(intercept: true);
    }
}