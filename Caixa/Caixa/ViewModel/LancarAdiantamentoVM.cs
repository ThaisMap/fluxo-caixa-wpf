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
        public Adiantamento_M Adiantamento { get; }

        public ICommand ComandoSalvar { get; private set; } 

        public LancarAdiantamentoVM()
        {
            Adiantamento = new Models.Adiantamento_M();
            ComandoSalvar = new LancarAdiantamento(this); 
        }

        public bool CanExecute { get => Adiantamento.IsValid; }

        internal void Salvar()
        {
            Adiantamento.Salvar();
            Adiantamento.Imprimir();
        }

    }
}
