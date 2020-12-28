using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Models
{
    public class Fechamento : Observavel
    {
        private Dados.Modelos.Fechamento fechamento;

        public int Id { get => fechamento.Id; }
        public double ValorInicial { get => fechamento.ValorInicial; }

        public Fechamento(Filial filial)
        {
            fechamento = new Dados.Modelos.Fechamento()
            {
                Data = DateTime.Now,
                Filial_Id = filial.Id,
                ValorInicial = filial.Saldo,
                ArquivoScan = ""
            };
        }

        public Fechamento(Dados.Modelos.Fechamento doBanco)
        {
            fechamento = doBanco;
        }

        public void Salvar()
        {
            fechamento.Salvar();
        }
    }
}
