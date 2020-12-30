using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caixa.ViewModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Caixa.Commands
{
    internal class LancarSuprimento : ICommand
    {
        private LancarSuprimentoVM lancar;

        public LancarSuprimento(LancarSuprimentoVM lancar)
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
            //deixei a execução no code behind por causa do evento pra fechar o pop up
            //mas mantive o comando pra controlar o canExecute
        }
    }
}
