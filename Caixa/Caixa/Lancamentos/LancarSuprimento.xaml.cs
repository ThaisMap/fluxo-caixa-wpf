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
    /// Interação lógica para Suprimento.xam
    /// </summary>
    public partial class LancarSuprimento : UserControl
    {
        private LancarSuprimentoVM controlador;
        public LancarSuprimento()
        {
            InitializeComponent();
            controlador = new LancarSuprimentoVM();
            DataContext = controlador;
        }
        public static readonly RoutedEvent EventoSuprimentoLancado =
          EventManager.RegisterRoutedEvent("EventoSuprimentoLancado", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LancarSuprimento));

        public event RoutedEventHandler SuprimentoLancado
        {
            add { AddHandler(EventoSuprimentoLancado, value); }
            remove { RemoveHandler(EventoSuprimentoLancado, value); }
        }

        private void BtnLancar_Click(object sender, RoutedEventArgs e)
        {
            controlador.Salvar();
            RaiseEvent(new RoutedEventArgs(EventoSuprimentoLancado));
        }


    }
}
