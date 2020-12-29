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

namespace Caixa.Cadastros
{
    /// <summary>
    /// Interação lógica para Clientes.xam
    /// </summary>
    public partial class Clientes : UserControl
    {
        Dados.Modelos.Cliente ClienteSelecionado = new Dados.Modelos.Cliente();
        List<Dados.Modelos.Cliente> ClientesCadastrados = new List<Dados.Modelos.Cliente>();
        public Clientes()
        {
            InitializeComponent();
            cbTipo.ItemsSource = Listas.TiposCobranca();
            cbTipo.DisplayMemberPath = "Descricao";
            cbTipo.SelectedValuePath = "Id";
            CbCadastrados.DisplayMemberPath = "Nome";
            cbTipo.SelectedIndex = 0;
            EsconderMsgErro();
            CarregarCadastros();
        }

        private void CarregarCadastros()
        {
            ClientesCadastrados = Listas.Clientes();
            CbCadastrados.ItemsSource = ClientesCadastrados;
        }

        private void EsconderMsgErro()
        {
            NomeErro.Visibility = Visibility.Hidden;
        }

        private void LimparCampos()
        {
            Nome.Text = "";
            cbTipo.SelectedIndex = 0;
            NomeErro.Visibility = Visibility.Hidden; 
            ClienteSelecionado = new Dados.Modelos.Cliente();
        }

        private bool VerificarPreenchimento()
        {
            if (Nome.Text.Length < 3)
            {
                NomeErro.Visibility = Visibility.Visible;
                Nome.Focus();
                return false;
            }
            else
            {
                NomeErro.Visibility = Visibility.Hidden;
            }

            return true;
        }

        public void MontarObjeto()
        {
            ClienteSelecionado.Nome = Nome.Text;
            ClienteSelecionado.TipoCobranca_Id = (int)cbTipo.SelectedValue;
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarPreenchimento())
            {
                try
                {
                    MontarObjeto();
                    ClienteSelecionado.Salvar();
                    LimparCampos();
                    CarregarCadastros();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Houve um erro");
                }
            }
        }

        private void Limpar_Click(object sender, RoutedEventArgs e)
        {
            LimparCampos();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            ClienteSelecionado = CbCadastrados.SelectedItem as Dados.Modelos.Cliente;
            Nome.Text = ClienteSelecionado.Nome;
            cbTipo.SelectedValue = ClienteSelecionado.TipoCobranca_Id;
        }
    }
}
