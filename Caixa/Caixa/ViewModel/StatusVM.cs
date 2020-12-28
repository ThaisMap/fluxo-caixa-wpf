using Caixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.ViewModel
{
    public class StatusVM 
    {
        private Sessao status;

        public Sessao Status { get => status; }

        public StatusVM()
        {
            status = Sessao.Status;
        }
    }
}
