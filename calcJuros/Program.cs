decimal taxaJuros = 0.025m;

Console.WriteLine("=== CALCULAR JUROS ===");
Console.Write("Valor da Conta: [1000,00]: R$ ");
decimal valorInicial = decimal.Parse(Console.ReadLine());
Console.Write("Dia de vencimento: [dd]: ");
int diaVencimento = int.Parse(Console.ReadLine());
Console.Write("Mês de vencimento: [mm]: ");
int mesVencimento = int.Parse(Console.ReadLine());
Console.Write("Ano de vencimento: [yyyy]: ");
int anoVencimento = int.Parse(Console.ReadLine());

DateTime dataVencimento = new DateTime(anoVencimento, mesVencimento, diaVencimento);
if(dataVencimento > DateTime.Today)
{
    Console.WriteLine("\n\t*** A data de vencimento não pode ser maior que a data atual.***\n");
    return;
}

int diasVencidos = (DateTime.Today - dataVencimento.Date).Days;
var juros = CalculadoraJuros.CalcularJuros(valorInicial, taxaJuros, diasVencidos);
Console.WriteLine("\n=== RESULTADO ===");
Console.WriteLine($"\nDias de atraso: {diasVencidos} dias \nTaxa de juros: {juros.TaxaJuros:P2} ao dia \nValor Inicial: R$ {valorInicial:F2} \nValor dos juros: R$ {juros.ValorJuros:F2} \nValor final com juros: R$ {juros.ValorFinal:F2}");