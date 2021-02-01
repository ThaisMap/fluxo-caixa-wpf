using Caixa.Models;
using Dados;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.ViewModel
{
    public class FechamentosPendentesVM
    {
        private FechamentosPendentes fechamentosPendentes;
        public List<Fechamento_M> Pendentes => fechamentosPendentes.Pendentes;

        public Fechamento_M FechamentoSelecionado { get; set; }

        public FechamentosPendentesVM()
        {
            fechamentosPendentes = new FechamentosPendentes();
            fechamentosPendentes.Carregar();
            fechamentosPendentes.CalcularSaldosIniciais();            
        }
        
    }
}
