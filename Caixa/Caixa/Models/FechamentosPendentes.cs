using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Models
{
    public class FechamentosPendentes
    {
        private Sessao status = Sessao.Status;
        public List<Fechamento_M> Pendentes { get; private set; }

        public Fechamento_M LiberadoParaFechar { get; set; }

        public FechamentosPendentes()
        {
            Pendentes = new List<Fechamento_M>();
            LiberadoParaFechar = new Fechamento_M();
        }

        public void Carregar()
        {
            int filial_id = status.IdFilial;
            using (var Banco = new CaixaContext())
            {
                var pendentesBanco = Banco.Fechamentos
                    .Where(x => x.Filial_Id == filial_id && !x.Fechado)
                    .OrderBy(x=> x.Data)
                    .ToList();

                pendentesBanco.ForEach(item => Pendentes.Add(new Fechamento_M(item)));
            }
            if (Pendentes.Count > 0)
                LiberadoParaFechar = Pendentes.First();

        }

        public void CalcularSaldosIniciais()
        {
            double saldo = 0;
            foreach (var item in Pendentes)
            {
                item.CarregarLancamentos();

                if (item != Pendentes.First())
                {
                    item.ValorInicial = saldo;
                }

                if (item != Pendentes.Last())
                {
                    saldo = item.CalculaValorFinal();
                }
                item.ValorFinal = null;
                item.Salvar();
            }

        }



        
    }
}
