using System.Globalization;

const decimal taxaJuros = 0.025m;

Console.WriteLine("=== CALCULAR JUROS ===");
Console.Write("Valor da Conta: [1000,00]: R$ ");
decimal valorInicial = decimal.Parse(Console.ReadLine());
Console.Write("Data de vencimento [dd/MM/yyyy]: ");
string entrada = Console.ReadLine();

if (!DateTime.TryParseExact(
        entrada,
        "dd/MM/yyyy",
        null,
        DateTimeStyles.None,
        out DateTime dataVencimento))
{
    Console.WriteLine("Data inválida.");
    return;
}

if(dataVencimento > DateTime.Today)
{
    Console.WriteLine("\n\t*** A data de vencimento não pode ser maior que a data atual.***\n");
    return;
}

int diasVencidos = (DateTime.Today - dataVencimento.Date).Days;
var juros = CalculadoraJuros.CalcularJuros(valorInicial, taxaJuros, diasVencidos);
Console.WriteLine("\n=== RESULTADO ===");
Console.WriteLine($"\nDias de atraso: {diasVencidos} dias \n" + 
                  $"Taxa de juros: {juros.TaxaJuros:P2} ao dia \n" + 
                  $"Valor Inicial: R$ {valorInicial:N2} \n" + 
                  $"Valor dos juros: R$ {juros.ValorJuros:N2} \n" + 
                  $"Valor final com juros: R$ {juros.ValorFinal:N2}\n");