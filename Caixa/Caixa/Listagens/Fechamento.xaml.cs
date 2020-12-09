using Dados;
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

namespace Caixa.Listagens
{
    /// <summary>
    /// Interação lógica para Fechamento.xam
    /// </summary>
    public partial class Fechamento : UserControl
    {
        public Fechamento()
        {
            InitializeComponent();
            DgCaixa.ItemsSource = Listas.Lancamentos;
        }
    }
}
