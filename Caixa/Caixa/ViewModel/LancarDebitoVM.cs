using Caixa.Models;
using Dados.Modelos;
using Dados;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Caixa.Commands;

namespace Caixa.ViewModel
{
    public class LancarDebitoVM
    {
        public List<TipoCobranca> TiposCobranca => Listas.TiposCobranca();
        public List<TipoDocumento> TiposDocumento => Listas.TiposDescarga();
        public List<Cliente> Clientes => Listas.Clientes(); 

        public string SelecionarId => "Id";
        public string DisplayTipo => "Descricao";
        public string DisplayCliente => "Nome";

        public string NomeCliente { get; set; }
        public ICommand ComandoSalvar { get; set; }
        public Debito_M Debito { get; }
        public bool PodeLancar { get => Debito.IsValid; }

        public bool exibirErro { get; set; }

        public LancarDebitoVM()
        {
            Debito = new Debito_M();
            ComandoSalvar = new LancarDebito(this);
        }

        internal void Salvar() {
            if(Debito.Cliente == 0)
            {
                Cliente novo = new Cliente(NomeCliente, Debito.TipoCobranca);
                novo.Salvar();
                Debito.Cliente = novo.Id;
            }
            exibirErro = !Debito.Salvar();
        }
    }
}
