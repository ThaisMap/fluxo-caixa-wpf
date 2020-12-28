using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caixa.Commands;
using System.Windows.Input;
using Caixa.Models;

namespace Caixa.ViewModel
{
    public class LancarAdiantamentoVM
    {
        private Models.Adiantamento adiantamento;

        public Models.Adiantamento Adiantamento { get => adiantamento; }

        public ICommand ComandoSalvar { get; private set; }
        public ICommand ComandoImprimir { get; private set; }

        public LancarAdiantamentoVM()
        {
            adiantamento = new Models.Adiantamento();
            ComandoSalvar = new LancarAdiantamento(this);
            ComandoImprimir = new ImprimirAdiantamento(this);
        }

        public bool CanExecute { get => adiantamento.isValid(); }

        internal void Salvar()
        {
            adiantamento.Salvar();
        }

        internal void Imprimir()
        {
            if (Adiantamento.Id == 0)
                adiantamento.Salvar();
            RelatoriosCrystal.Adiantamento recibo = new RelatoriosCrystal.Adiantamento();
            //TODO: Criar um DataSet e um Modelo para impressão com as mesmas props 
            //ou alterar o adiantamento para ter o nome da filial
            List<AdiantamentoRelatorio> dadosRelatorio = new List<AdiantamentoRelatorio>() { new AdiantamentoRelatorio(adiantamento.Id) };

            recibo.SetDataSource(dadosRelatorio);
            Relatorios.ImprimirRelatorio imprimir = new Relatorios.ImprimirRelatorio(recibo);
            imprimir.ShowDialog();
        }
    }
}
