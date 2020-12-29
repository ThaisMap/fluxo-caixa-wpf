using Caixa.Commands;
using Caixa.Models;
using Dados;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Caixa.ViewModel
{
    public class AdiantamentosPendentesVM
    {
        public ObservableCollection<Adiantamento_M> Pendentes { get; private set; }

        public Adiantamento_M AdiantamentoSelecionado { get; set; } 

        public AdiantamentosPendentesVM()
        {
            CarregarPendentes();
        }

        public  void CarregarPendentes()
        {
            Pendentes = new ObservableCollection<Adiantamento_M>();
            foreach (var item in Listas.GetListaAdiantamentos())
            {
                Pendentes.Add(new Adiantamento_M(item));
            }
        }

        internal void EstornarSelecionado()
        {
            AdiantamentoSelecionado.Estornar();
            Suprimento_M estorno = new Suprimento_M("estorno de adiantamento")
            {
                Valor = AdiantamentoSelecionado.Valor
            };
            estorno.Salvar();
            CarregarPendentes();
        }
    }
}
