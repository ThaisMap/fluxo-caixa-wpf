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
        public Models.Suprimento_M Suprimento { get; }
        public bool CanExecute
        {
            get
            {
                if (Suprimento.Valor > 0 )
                    return true;
                else
                    return false;
            }
        }

        public ICommand ComandoSalvar { get; private set; }

        public LancarSuprimentoVM()
        {
            Suprimento = new Models.Suprimento_M("suprimento");
            ComandoSalvar = new LancarSuprimento(this);
        }

        internal void Salvar()
        {
            Suprimento.Salvar();
        }
    }
}
