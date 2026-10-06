public static class CalculadoraJuros
{
     // 1% de juros ao mês
    public static JurosSimples CalcularJuros(decimal valorInicial, decimal taxaJuros, int diasAtraso)
    {
        decimal juros = valorInicial * (taxaJuros * diasAtraso);
        return new JurosSimples
        {
            ValorJuros = juros,
            TaxaJuros = taxaJuros,
            DiasAtraso = diasAtraso,
            ValorFinal = valorInicial + juros
        };
    }
}