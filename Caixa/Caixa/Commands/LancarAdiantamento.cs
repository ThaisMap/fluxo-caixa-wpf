using Caixa.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Caixa.Commands
{
    internal class LancarAdiantamento : ICommand
    {
        private LancarAdiantamentoVM lancar;

        public LancarAdiantamento(LancarAdiantamentoVM lancar)
        {
            this.lancar = lancar;
        }

        event EventHandler ICommand.CanExecuteChanged
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
            lancar.Salvar();
        }
    }
}
