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

namespace Caixa.Relatorios
{
    /// <summary>
    /// Interação lógica para FechamentosAnteriores.xam
    /// </summary>
    public partial class FechamentosAnteriores : UserControl
    {
        FechamentosAnterioresVM controlador; 
        public FechamentosAnteriores()
        {
            InitializeComponent();
            controlador = new FechamentosAnterioresVM();
            DataContext = controlador;
        }

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            controlador.Imprimir();
        }

        private void BtnArquivo_Click(object sender, RoutedEventArgs e)
        {
            if (!controlador.AbrirArquivo())
            {
                MessageBox.Show("Arquivo não encontrado. Ele pode ter sido movido ou deletado.");
            }
        }

        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            controlador.Filtrar();
        }
    }
}
