using Caixa.Models;
using Dados;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.ViewModel
{
    public class FechamentosPendentesVM
    {
        public ObservableCollection<Fechamento_M> Pendentes { get; private set; }

        public Fechamento_M FechamentoSelecionado { get; set; }

        public FechamentosPendentesVM()
        {
            CarregarPendentes();
        }

        private void CarregarPendentes()
        {
            Pendentes = new ObservableCollection<Fechamento_M>();
            foreach (var item in Listas.GetFechamentosPendentes())
            {
                Pendentes.Add(new Fechamento_M(item));
            }
        }

        public void FecharSelecionado()
        {

        }
    }
}
