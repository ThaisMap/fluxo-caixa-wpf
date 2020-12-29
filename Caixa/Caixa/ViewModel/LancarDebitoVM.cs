using Caixa.Models;
using Dados.Modelos;
using Dados;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.ViewModel
{
    public class LancarDebitoVM
    {
        public List<TipoCobranca> TiposCobranca => Listas.TiposCobranca();
        public List<TipoDocumento> TiposDocumento => Listas.TiposDocumento();
        public List<Cliente> Cliente => Listas.Clientes();

        public string SelecionarId => "Id";
    }
}
