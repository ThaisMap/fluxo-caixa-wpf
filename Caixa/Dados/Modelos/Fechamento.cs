using System;

namespace Dados.Modelos
{
    public class Fechamento : BaseClass
    {
        public Fechamento(DateTime data, Filial filial, double valorInicial, double? valorFinal, string arquivoScan, int id) : base(id)
        {
            Data = data;
            Filial = filial;
            ValorInicial = valorInicial;
            ValorFinal = valorFinal;
            ArquivoScan = arquivoScan;
        }

        public DateTime Data { get; set; }
        public Filial Filial { get; set; }
        public double ValorInicial { get; set; }
        public double? ValorFinal { get; set; }
        public string ArquivoScan { get; set; }
    }
}