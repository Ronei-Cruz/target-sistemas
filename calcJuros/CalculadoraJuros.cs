public static class CalculadoraJuros
{
     // 1% de juros ao mês
    public static decimal CalcularJuros(decimal valorInicial, decimal taxaJuros, int diasAtraso)
    {
        decimal juros = valorInicial * (taxaJuros * diasAtraso);
        return valorInicial + juros;
    }
}