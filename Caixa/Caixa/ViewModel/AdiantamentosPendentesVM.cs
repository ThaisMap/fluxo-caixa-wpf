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
        private ObservableCollection<Adiantamento_M> pendentes;

        public ObservableCollection<Adiantamento_M> Pendentes => pendentes;

        public Adiantamento_M AdiantamentoSelecionado { get; set; } 

        public AdiantamentosPendentesVM()
        {
            CarregarPendentes();
        }

        public  void CarregarPendentes()
        {
            pendentes = new ObservableCollection<Adiantamento_M>();
            foreach (var item in Listas.GetListaAdiantamentos())
            {
                pendentes.Add(new Adiantamento_M(item));
            }
        }

        internal void EstornarSelecionado()
        {
            AdiantamentoSelecionado.Estornar();
            Suprimento estorno = new Suprimento("estorno de adiantamento")
            {
                Valor = AdiantamentoSelecionado.Valor
            };
            estorno.Salvar();
            CarregarPendentes();
        }
    }
}
