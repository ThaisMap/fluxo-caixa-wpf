using Caixa.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Caixa.Commands
{
    internal class InserirFilial : ICommand
    {
        private CadastroFilialVM cadastroFilial;

        public InserirFilial(CadastroFilialVM cadastroFilial)
        {
            this.cadastroFilial = cadastroFilial;
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object parameter) {
            return cadastroFilial.CanExecute;
        }
        void ICommand.Execute(object parameter)
        {
            cadastroFilial.Salvar();
        }
    }
}
