using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caixa.Commands;
using System.Windows.Input;

namespace Caixa.ViewModel
{
    public class LancarSuprimentoVM
    {
        private Models.Suprimento suprimento;
        public Models.Suprimento Suprimento { get => suprimento; }
        public bool CanExecute { get => suprimento.Valor > 0; }

        public ICommand ComandoSalvar { get; private set; }

        public LancarSuprimentoVM()
        {
            suprimento = new Models.Suprimento("suprimento");
            ComandoSalvar = new LancarSuprimento(this);
        }

        internal void Salvar()
        {

            suprimento.Salvar();
        }
    }
}
