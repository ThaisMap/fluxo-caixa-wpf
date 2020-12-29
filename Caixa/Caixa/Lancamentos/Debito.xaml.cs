using Caixa.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Caixa.Lancamentos
{
    /// <summary>
    /// Interação lógica para Debito.xam
    /// </summary>
    public partial class Debito : UserControl
    {
        private LancarDebitoVM controlador = new LancarDebitoVM();
        public Debito()
        {
            InitializeComponent();
            DataContext = controlador;
        }
        /****** passo a passo  https://stackoverflow.com/questions/3067617/raising-an-event-on-parent-window-from-a-user-control-in-net-c-sharp *******/
        public static readonly RoutedEvent EventoDebitoLancado =
            EventManager.RegisterRoutedEvent("EventoDebitoLancado", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Debito)); 

        public event RoutedEventHandler DebitoLancado
        {
            add { AddHandler(EventoDebitoLancado, value);  }
            remove { RemoveHandler(EventoDebitoLancado, value); }
        }

        private void BtnLancar_Click(object sender, RoutedEventArgs e)
        { 
            RaiseEvent(new RoutedEventArgs(EventoDebitoLancado));
        } 
    }
}
