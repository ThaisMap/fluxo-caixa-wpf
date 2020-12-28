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
        private List<Adiantamento> pendentes;
        public ICommand ComandoImprimir { get; private set; }
        public ICommand ComandoEstornar { get; private set; }
        public ICommand ComandoIncluir { get; private set; }

        public List<Adiantamento> Pendentes { get => pendentes; }

        public Adiantamento AdiantamentoSelecionado { get; set; } 

        public AdiantamentosPendentesVM()
        {
            pendentes = new List<Adiantamento>();
            foreach (var item in Listas.AdiantamentosPendentes)
            {
                pendentes.Add(new Adiantamento(item));
            }
            ComandoImprimir = new ImprimirAdiantamentoListaPendentes(this);
        }

        internal void Estornar()
        {
            AdiantamentoSelecionado.Estornar();
            //TODO: LANÇAMENTO DE ESTORNO
        }

        internal void Imprimir()
        {
            if (AdiantamentoSelecionado != null)
            {
                RelatoriosCrystal.Adiantamento recibo = new RelatoriosCrystal.Adiantamento();
                List<AdiantamentoRelatorio> dadosRelatorio =
                    new List<AdiantamentoRelatorio>() { new AdiantamentoRelatorio(AdiantamentoSelecionado.Id) };

                recibo.SetDataSource(dadosRelatorio);
                Relatorios.ImprimirRelatorio imprimir = new Relatorios.ImprimirRelatorio(recibo);
                imprimir.ShowDialog();
            }
        }
    }
}
