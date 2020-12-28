﻿using Caixa.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Caixa.Commands
{
    public class ImprimirAdiantamentoListaPendentes : ICommand
    {
        private AdiantamentosPendentesVM controlador;

        public ImprimirAdiantamentoListaPendentes(AdiantamentosPendentesVM pendentes)
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