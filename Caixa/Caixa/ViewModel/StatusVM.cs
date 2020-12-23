using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.ViewModel
{
    public class StatusVM 
    {
        private Models.Sessao status;

        public Models.Sessao Status { get => status; }

        public StatusVM()
        {
            status = new Models.Sessao();
        }
    }
}
