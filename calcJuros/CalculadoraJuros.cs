public static class CalculadoraJuros
{
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