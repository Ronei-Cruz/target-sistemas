public static class MovimentacaoEstoque
{
    public static void AdicionarProduto(int codProduto, string desProduto, int quantidade, List<Estoque> estoque, List<HistoricoEstoque> historicoMovimentacao)
    {
        Console.Clear();

        var produtoExistente = estoque.FirstOrDefault(e => e.CodProduto == codProduto);
        if (produtoExistente != null)
        {
            Console.WriteLine("**** ATENÇÃO ****\nProduto em estoque.");
            Console.WriteLine($"Código: {produtoExistente.CodProduto}\nDescrição: {produtoExistente.DesProduto}\nQuantidade atual: {produtoExistente.Quantidade}");
            Console.WriteLine("Confirmar Produto? (S/N)");
            string continuar = Console.ReadLine();
            if (continuar.ToUpper() == "S")
            {
                produtoExistente.DesProduto = produtoExistente.DesProduto ?? desProduto;
                produtoExistente.Quantidade += quantidade;
                HistoricoMovimentacao(codProduto, produtoExistente.DesProduto, quantidade, "ENTRADA", historicoMovimentacao);
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

            HistoricoMovimentacao(codProduto, desProduto, quantidade, "ENTRADA", historicoMovimentacao);
        }
    }

    public static void RemoverProduto( int codProduto, int quantidade, List<Estoque> estoque,List<HistoricoEstoque> historicoMovimentacao)
    {
        Console.Clear();
        var produtoExistente = estoque.FirstOrDefault(e => e.CodProduto == codProduto);
        Console.WriteLine("**** ATENÇÃO ****\nProduto em estoque.");
        Console.WriteLine($"Código: {produtoExistente.CodProduto}\nDescrição: {produtoExistente.DesProduto}\nQuantidade atual: {produtoExistente.Quantidade}");
        Console.WriteLine("Confirmar Produto? (S/N)");
        string continuar = Console.ReadLine();
        if (produtoExistente != null && produtoExistente.Quantidade >= quantidade && continuar.ToUpper() == "S")
        {
            produtoExistente.Quantidade -= quantidade;
            var produtoAtualizado = estoque.FirstOrDefault(e => e.CodProduto == codProduto);
            HistoricoMovimentacao(codProduto, produtoExistente.DesProduto, quantidade, "SAÍDA", historicoMovimentacao);

            if (produtoAtualizado != null && produtoAtualizado.Quantidade == 0)
            {
                estoque.Remove(produtoAtualizado);
            }
        }
        else
        {
            Console.WriteLine("Estoque insuficiente ou produto não encontrado.");
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

    public static void HistoricoMovimentacao(int codProduto, string desProduto, int quantidade, string movimentacao, List<HistoricoEstoque> historicoMovimentacao)
    {   
        historicoMovimentacao.Add (new HistoricoEstoque
        {
            CodProduto = codProduto,
            DesProduto = desProduto,
            Movimentacao = movimentacao, 
            Quantidade = quantidade,
            DataMovimentacao = DateTime.Now
        });
    }

    public static void ListarHistoricoMovimentacao(List<HistoricoEstoque> historico)
    {
        Console.Clear();
        Console.WriteLine("=== HISTÓRICO DE MOVIMENTAÇÕES  ===");

        if (historico.Count == 0)
        {
            Console.WriteLine("Nenhuma movimentação realizada nesta sessão.");
            return;
        }

        foreach (var item in historico)
        {
            Console.WriteLine($"\n[{item.DataMovimentacao:dd/MM/yyyy HH:mm:ss}] \nCód: {item.CodProduto} \nProduto: {item.DesProduto,-15} \nTipo: {item.Movimentacao,-7} \nQuantidade: {item.Quantidade}");
            Console.WriteLine(new string('-', 25));
        }
    }
    
    public static void PressionarParaContinuar()
    {
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey(intercept: true);
    }
}