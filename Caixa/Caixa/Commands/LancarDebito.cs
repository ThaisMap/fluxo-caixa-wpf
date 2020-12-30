using Caixa.Models;
using Caixa.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Caixa.Commands
{
    public class LancarDebito : ICommand
    {
        private LancarDebitoVM controlador;

        public LancarDebito(LancarDebitoVM controlador)
        {
            this.controlador = controlador;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return controlador.PodeLancar;
        }
        public void Execute(object parameter)
        {
            //deixei a execução no code behind por causa do evento pra fechar o pop up
            //mas mantive o comando pra controlar o canExecute
        }
    }
}
