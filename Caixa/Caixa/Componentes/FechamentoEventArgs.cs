using Caixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Caixa.Componentes
{
    public class FechamentoEventArgs : RoutedEventArgs
    {
        public Fechamento_M Fechamento { get; }

        //    public TabsEventArgs(RoutedEvent routedEvent, string text) : base(routedEvent)
        public FechamentoEventArgs(RoutedEvent routedEvent, Fechamento_M fechamento) : base(routedEvent)
        {
            Fechamento = fechamento;
        }

    }
}
