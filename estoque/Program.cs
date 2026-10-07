using System.Text.Json;

string estoque = Path.Combine(AppContext.BaseDirectory, "estoque.json");

if (File.Exists(estoque))
{
    string json = File.ReadAllText(estoque);
    var documento = JsonSerializer.Deserialize<RelatorioEstoque>(json);

    List<HistoricoEstoque> historicoEmMemoria = new List<HistoricoEstoque>();
    bool executando = true;

    do
    {
        Console.Clear();
        Console.WriteLine("\n=== MENU ESTOQUE ===\n");
        Console.WriteLine($" 1 - Adicionar Produtos ao Estoque\n" +
                          $" 2 - Remover Produtos do Estoque\n" +
                          $" 3 - Listar Produtos em Estoque\n" +
                          $" 4 - Histórico de Movimentação\n" +
                          $" 5 - Sair");

        
        int opcao = MovimentacaoEstoque.LerInteiro("Escolha uma opção...");
        int codProduto,quantidade;

        switch (opcao)
        {            
            case 1:
                Console.WriteLine("Novo Produto? (S/N)");
                string novoProduto = Console.ReadLine();
                if(novoProduto.ToUpper() == "S")
                {
                    codProduto = MovimentacaoEstoque.LerInteiro("Digite o código do produto:");                    
                    Console.WriteLine("Digite a descrição do produto:");
                    string desProduto = Console.ReadLine();
                    quantidade = MovimentacaoEstoque.LerInteiro("Digite a quantidade a ser adicionada:");
                    if(quantidade <= 0)
                    {
                        Console.WriteLine("Quantidade inválida. A quantidade deve ser maior que zero.");
                        MovimentacaoEstoque.PressionarParaContinuar();
                        break;
                    }

                    MovimentacaoEstoque.AdicionarProduto(codProduto, desProduto, quantidade, documento.Estoque, historicoEmMemoria);
                }
                else
                {
                    codProduto = MovimentacaoEstoque.LerInteiro("Digite o código do produto:");
                    quantidade = MovimentacaoEstoque.LerInteiro("Digite a quantidade a ser adicionada:");

                    MovimentacaoEstoque.AdicionarProduto(codProduto, "", quantidade, documento.Estoque, historicoEmMemoria);
                }                

                MovimentacaoEstoque.PressionarParaContinuar();
                break;

            case 2:
                codProduto = MovimentacaoEstoque.LerInteiro("Digite o código do produto:");
                quantidade = MovimentacaoEstoque.LerInteiro("Digite a quantidade a ser removida:");

                MovimentacaoEstoque.RemoverProduto(codProduto, quantidade, documento.Estoque, historicoEmMemoria);
                
                MovimentacaoEstoque.PressionarParaContinuar();
                break;

            case 3:
                MovimentacaoEstoque.ListarProdutos(documento.Estoque);
                MovimentacaoEstoque.PressionarParaContinuar();
                break;

            case 4:
                MovimentacaoEstoque.ListarHistoricoMovimentacao(historicoEmMemoria);
                MovimentacaoEstoque.PressionarParaContinuar();
                break;

            case 5:
                executando = false;
                Console.WriteLine("Saindo do programa...");
                break;
            
            default:
                Console.WriteLine("Essa opção não é válida!");
                MovimentacaoEstoque.PressionarParaContinuar();
                break;
        }
                  
    }while (executando);
}
else
{
    Console.WriteLine("Arquivo de estoque não encontrado.");
}