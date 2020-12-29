using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados.Modelos;  
using System.Threading.Tasks;

namespace Caixa.Models
{
    public class Fechamento_M : Observavel
    {
        private Fechamento fechamento;

        public int Id { get => fechamento.Id; }
        public double ValorInicial { get => fechamento.ValorInicial; }

        public Fechamento_M(Filial filial)
        {
            fechamento = new Fechamento(filial);
        }

        public Fechamento_M(Fechamento doBanco)
        {
            fechamento = doBanco;
        }

        public void Salvar()
        {
            fechamento.Salvar();
        }
    }
}
