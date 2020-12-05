using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Caixa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 

        }
         

        private void MenuFiliais_Click(object sender, RoutedEventArgs e)
        {
            Conteudo.Content = new Cadastros.Filial();
        }

        private void MenuUsuarios_Click(object sender, RoutedEventArgs e)
        {
            Conteudo.Content = new Cadastros.Usuarios();
        }

        private void MenuClientes_Click(object sender, RoutedEventArgs e)
        {
            Conteudo.Content = new Cadastros.Clientes();
        }

        private void MenuDocumentos_Click(object sender, RoutedEventArgs e)
        {
            Conteudo.Content = new Cadastros.TiposDocumento();
        }

        private void MenuCobrancas_Click(object sender, RoutedEventArgs e)
        {
            Conteudo.Content = new Cadastros.TiposCobranca();
        }

        private void MenuCaixa_Click(object sender, RoutedEventArgs e)
        {
            Conteudo.Content = new Listagens.Caixa();
        }

        private void MenuAdiantamentos_Click(object sender, RoutedEventArgs e)
        {
            Conteudo.Content = new Listagens.AdiantamentosPendentes();
        }

        private void MenuFechamento_Click(object sender, RoutedEventArgs e)
        {
            Conteudo.Content = new Listagens.Caixa();
        }
    }
}
