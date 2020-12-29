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
using Caixa.ViewModel;

namespace Caixa.Lancamentos
{
    /// <summary>
    /// Interação lógica para Adiantamento.xam
    /// </summary>
    public partial class Adiantamento : UserControl
    {
        public Adiantamento()
        {
            InitializeComponent();
            DataContext = new LancarAdiantamentoVM();
        }

        public static readonly RoutedEvent EventoAdiantamentoLancado =
           EventManager.RegisterRoutedEvent("EventoAdiantamentoLancado", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Adiantamento));

        public event RoutedEventHandler AdiantamentoLancado
        {
            add { AddHandler(EventoAdiantamentoLancado, value); }
            remove { RemoveHandler(EventoAdiantamentoLancado, value); }
        }

        private void BtnLancar_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(EventoAdiantamentoLancado));
        }

    }
}
