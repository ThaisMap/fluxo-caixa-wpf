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
    public class EstornarAdiantamento : ICommand
    {
        private Adiantamento_M controlador;

        public EstornarAdiantamento(Adiantamento_M controlador)
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
            return true;
        }
        public void Execute(object parameter)
        {
            controlador.Estornar();
        }
    }
}
