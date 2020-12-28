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
        private Adiantamento_M adiantamento;

        public Adiantamento_M Adiantamento { get => adiantamento; }

        public ICommand ComandoSalvar { get; private set; } 

        public LancarAdiantamentoVM()
        {
            adiantamento = new Models.Adiantamento_M();
            ComandoSalvar = new LancarAdiantamento(this); 
        }

        public bool CanExecute { get => adiantamento.isValid(); }

        internal void Salvar()
        {
            adiantamento.Salvar();
            adiantamento.Imprimir();
        }

    }
}
