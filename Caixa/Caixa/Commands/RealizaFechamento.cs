using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caixa.ViewModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Caixa.Models;

namespace Caixa.Commands
{
    internal class RealizaFechamento : ICommand
    {
        private FechamentoVM controlador;

        public RealizaFechamento(FechamentoVM pendentes)
        {
            this.controlador = pendentes;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return controlador.PodeFechar;
        }
        public void Execute(object parameter)
        {
            controlador.FecharEImprimir();
        }
    }
}
