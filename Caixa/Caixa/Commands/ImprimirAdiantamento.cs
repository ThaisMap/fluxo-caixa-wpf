using Caixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Caixa.Commands
{
    public class ImprimirAdiantamento : ICommand
    {
        private Adiantamento_M controlador;

        public ImprimirAdiantamento(Adiantamento_M pendentes)
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
            return true;
        }
        public void Execute(object parameter)
        {
            controlador.Imprimir();
        }
    }
}
