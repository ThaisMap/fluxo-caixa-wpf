using Caixa.Componentes;
using Caixa.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Caixa.Listagens
{
    /// <summary>
    /// Interação lógica para FechamentosPendentes.xam
    /// </summary>
    public partial class FechamentosPendentes : UserControl
    {
        private FechamentosPendentesVM controlador = new FechamentosPendentesVM();
        public FechamentosPendentes()
        {
            InitializeComponent();
            DataContext = controlador;
        }

        public static readonly RoutedEvent EventoBtnFechamento =
  EventManager.RegisterRoutedEvent("EventoBtnFechamento", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FechamentosPendentes));

        public event RoutedEventHandler BtnFechamento
        {
            add { AddHandler(EventoBtnFechamento, value); }
            remove { RemoveHandler(EventoBtnFechamento, value); }
        }

        private void BtnFechamento_Click(object sender, RoutedEventArgs e)
        {
            FechamentoEventArgs args = new FechamentoEventArgs(EventoBtnFechamento, controlador.FechamentoSelecionado);
            RaiseEvent(args);
        }
    }
}
