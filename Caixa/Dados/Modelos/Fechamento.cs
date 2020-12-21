using System;

namespace Dados.Modelos
{
    public class Fechamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Filial_Id { get; set; }
        public double ValorInicial { get; set; }
        public double? ValorFinal { get; set; }
        public string ArquivoScan { get; set; }
        public virtual Filial Filial { get; set; }

        public Fechamento()
        {
                
        }

        public Fechamento(DateTime data, Filial filial, double valorInicial, double? valorFinal, string arquivoScan)
        {
            Data = data;
            Filial_Id = filial.Id;
            ValorInicial = valorInicial;
            ValorFinal = valorFinal;
            ArquivoScan = arquivoScan;
        }

        public void Salvar()
        {
            using (var Banco = new CaixaContext())
            {
                if (Id == 0)
                {
                    Banco.Fechamentos.Add(this);
                }
                else
                {
                    var fechamento = Banco.Fechamentos.Find(Id);
                    fechamento.ArquivoScan = ArquivoScan;
                    fechamento.ValorFinal = ValorFinal;
                }
                Banco.SaveChanges();
            }
        }
    }
}