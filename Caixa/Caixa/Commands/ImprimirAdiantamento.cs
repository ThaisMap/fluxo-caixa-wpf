using Caixa.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Caixa.Commands
{
    internal class ImprimirAdiantamento : ICommand
    {
        private LancarAdiantamentoVM lancar;

        public ImprimirAdiantamento(LancarAdiantamentoVM lancar)
        {
            this.lancar = lancar;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return lancar.CanExecute;
        }
        public void Execute(object parameter)
        {
            lancar.Imprimir();
        }
    }
}
