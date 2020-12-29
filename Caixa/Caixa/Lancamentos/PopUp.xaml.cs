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

namespace Caixa.Lancamentos
{
    /// <summary>
    /// Interação lógica para PopUp.xam
    /// </summary>
    public partial class PopUp : UserControl
    {
        public string Tipo { get; set; } = "Débito";
        public PopUp(string tipo)
        {
            InitializeComponent();
            Tipo = tipo;
            if (Tipo == "Débito")
            {
                Debito debito = new Debito();
                debito.DebitoLancado += Fechar;
                conteudo.Content = debito; 
            }
            else
            if (Tipo == "Adiantamento")
            {
                Adiantamento adiantamento = new Adiantamento();
                adiantamento.AdiantamentoLancado += Fechar;
                conteudo.Content = adiantamento;
            }
            else
            if (Tipo == "Suprimento")
            {
                LancarSuprimento suprimento = new LancarSuprimento();
                suprimento.SuprimentoLancado += Fechar;
                conteudo.Content = suprimento;
            }

        }

        public static readonly RoutedEvent EventoFecharDialog =
          EventManager.RegisterRoutedEvent("EventoFecharDialog", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PopUp));

        public event RoutedEventHandler FecharDialog
        {
            add { AddHandler(EventoFecharDialog, value); }
            remove { RemoveHandler(EventoFecharDialog, value); }

        }

        private void Fechar(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(EventoFecharDialog));
        }

    }
}
