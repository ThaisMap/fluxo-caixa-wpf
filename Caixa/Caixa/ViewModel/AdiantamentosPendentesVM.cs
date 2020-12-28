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

            using (var Banco = new CaixaContext())
            {
                var doBanco = Banco.Adiantamentos.Where(x => x.Pendente == true);
                foreach (var item in doBanco)
                {
                    pendentes.Add(new Adiantamento(item));
                }

            }
        }

        internal void Imprimir()
        {
            if (AdiantamentoSelecionado != null)
            {
                RelatoriosCrystal.Adiantamento recibo = new RelatoriosCrystal.Adiantamento();
                //TODO: Criar um DataSet e um Modelo para impressão com as mesmas props 
                //ou alterar o adiantamento para ter o nome da filial
                List<AdiantamentoRelatorio> dadosRelatorio = 
                    new List<AdiantamentoRelatorio>() { new AdiantamentoRelatorio(AdiantamentoSelecionado.Id) };

                recibo.SetDataSource(dadosRelatorio);
                Relatorios.ImprimirRelatorio imprimir = new Relatorios.ImprimirRelatorio(recibo);
                imprimir.ShowDialog();
            }
        }
    }
}
