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
using Dados;
using Dados.Modelos;

namespace Caixa
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Vai pra tela de realizar fechamentos, vindo dos fechamentos pendentes
            AddHandler(Listagens.FechamentosPendentes.EventoBtnFechamento,
                new RoutedEventHandler(MenuFechamentos_Click));

            // Vai pra tela de fechamentos pendentes, voltando da realizar fechamentos
            AddHandler(Listagens.Fechamento.EventoVoltarListaFechamentos, 
                new RoutedEventHandler(MenuFechamentosPendentes_Click));

            Conteudo.Content = new Listagens.Caixa();
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


        private void MenuFechamentos_Click(object sender, RoutedEventArgs e)
        {
            Componentes.FechamentoEventArgs args = (Componentes.FechamentoEventArgs)e;
            Conteudo.Content = new Listagens.Fechamento(args.Fechamento);
        }

        private void MenuFechamentosPendentes_Click(object sender, RoutedEventArgs e)
        {
            Conteudo.Content = new Listagens.FechamentosPendentes();
        }

        private void MenuRelatorios_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
