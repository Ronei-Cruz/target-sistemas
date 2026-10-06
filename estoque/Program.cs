using System.Text.Json;

string estoque = Path.Combine(AppContext.BaseDirectory, "estoque.json");

if (File.Exists(estoque))
{
    string json = File.ReadAllText(estoque);
    var documento = JsonSerializer.Deserialize<RelatorioEstoque>(json);

    List<HistoricoEstoque> historicoEmMemoria = new List<HistoricoEstoque>();
    //var resumo = new List<Estoque>();
    bool executando = true;

    do
    {
        Console.Clear();
        Console.WriteLine("\n=== MENU ESTOQUE ===\n");
        Console.WriteLine(
        " 1 - Adicionar Produtos ao Estoque\n 2 - Remover Produtos do Estoque\n 3 - Listar Produtos em Estoque\n 4 - Histórico de Movimentação\n 5 - Sair");

        Console.WriteLine("Escolha uma opção...");
        string entrada = Console.ReadLine();
        int opcao, codProduto,quantidade;
        while (!int.TryParse(entrada, out opcao))
        {
            Console.WriteLine("Opção inválida. Por favor, digite um número válido.");
            Console.WriteLine("Escolha uma opção...");
            entrada = Console.ReadLine();
        }

        switch (opcao)
        {            
            case 1:
                Console.WriteLine("Novo Produto? (S/N)");
                string novoProduto = Console.ReadLine();
                if(novoProduto.ToUpper() == "S")
                {
                    Console.WriteLine("Digite o código do produto:");
                    codProduto = int.Parse(Console.ReadLine());                    
                    Console.WriteLine("Digite a descrição do produto:");
                    string desProduto = Console.ReadLine();
                    Console.WriteLine("Digite a quantidade a ser adicionada:");
                    quantidade = int.Parse(Console.ReadLine());

                    MovimentacaoEstoque.AdicionarProduto(codProduto, desProduto, quantidade, documento.Estoque, historicoEmMemoria);
                }
                else
                {
                    Console.WriteLine("Digite o código do produto:");
                    codProduto = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a quantidade a ser adicionada:");
                    quantidade = int.Parse(Console.ReadLine());

                    MovimentacaoEstoque.AdicionarProduto(codProduto, "", quantidade, documento.Estoque, historicoEmMemoria);
                }                

                MovimentacaoEstoque.PressionarParaContinuar();
                break;

            case 2:
                Console.WriteLine("Digite o código do produto:");
                codProduto = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite a quantidade a ser removida:");
                quantidade = int.Parse(Console.ReadLine());
                
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
    Console.WriteLine("Arquivo de vendas não encontrado.");
}