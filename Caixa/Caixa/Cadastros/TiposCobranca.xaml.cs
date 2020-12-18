using Dados;
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

namespace Caixa.Cadastros
{
    /// <summary>
    /// Interação lógica para TiposCobranca.xam
    /// </summary>
    public partial class TiposCobranca : UserControl
    {
        Dados.Modelos.TipoCobranca TipoSelecionado = new Dados.Modelos.TipoCobranca();
        List<Dados.Modelos.TipoCobranca> TiposCadastrados = new List<Dados.Modelos.TipoCobranca>();
        public TiposCobranca()
        {
            InitializeComponent();
            EsconderMsgErro();
            CarregarCadastros();
        }

        private void CarregarCadastros()
        {
            using (var Banco = new CaixaContext())
            {
                TiposCadastrados = Banco.TiposCobranca.ToList();
            }
            dgDados.ItemsSource = TiposCadastrados;
        }

        private void EsconderMsgErro()
        {
            DescricaoErro.Visibility = Visibility.Hidden; 
        }

        private void LimparCampos()
        {
            Descricao.Text = "";
            AlterarDescricao.Text = "";
            TipoSelecionado = new Dados.Modelos.TipoCobranca();

        }

        private bool VerificarPreenchimento()
        {
            if (Descricao.Text.Length < 3)
            {
                DescricaoErro.Visibility = Visibility.Visible;
                Descricao.Focus();
                return false;
            }
            else
            {
                DescricaoErro.Visibility = Visibility.Hidden;
            }

            return true;
        }

        public void MontarObjeto()
        {
            TipoSelecionado.Descricao = Descricao.Text; 
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarPreenchimento())
            {
                try
                {
                    MontarObjeto();
                    TipoSelecionado.Salvar();
                    LimparCampos();
                    CarregarCadastros();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Houve um erro");
                }
            }
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (AlterarDescricao.Text.Length > 3)
            {
                TipoSelecionado.Descricao = AlterarDescricao.Text;
                TipoSelecionado.Salvar();
                CarregarCadastros();
                LimparCampos();
                DialogAlteracao.IsOpen = false;
            }
        }

        private void dgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TipoSelecionado = dgDados.SelectedItem as Dados.Modelos.TipoCobranca;
            AlterarDescricao.Text = TipoSelecionado.Descricao;
            DialogAlteracao.IsOpen = true;
        }
    }
}
