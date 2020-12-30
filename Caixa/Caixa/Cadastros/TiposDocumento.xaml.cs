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
    /// Interação lógica para TiposDocumento.xam
    /// </summary>
    public partial class TiposDocumento : UserControl
    {
            string[] tiposPossiveis = { "Débito", "Crédito" };
        Dados.Modelos.TipoDocumento TipoSelecionado = new Dados.Modelos.TipoDocumento();
        List<Dados.Modelos.TipoDocumento> TiposCadastrados = Listas.TiposDescarga();
        public TiposDocumento()
        {
            InitializeComponent();

            cbTipo.ItemsSource = tiposPossiveis;
            cbTipo.SelectedIndex = 0;

            cbTipoAlterar.ItemsSource = tiposPossiveis;
            cbTipoAlterar.SelectedIndex = 0;

            EsconderMsgErro();
            CarregarCadastros();
        }

        private void CarregarCadastros()
        {
            TiposCadastrados = Listas.TiposDescarga();
            dgDados.ItemsSource = TiposCadastrados;
        }

        private void EsconderMsgErro()
        {
            DescricaoErro.Visibility = Visibility.Hidden;
        }

        private void LimparCampos()
        {
            Descricao.Text = "";
            cbTipo.SelectedIndex = 0;
            AlterarDescricao.Text = "";
            cbTipoAlterar.SelectedIndex = 0;
            TipoSelecionado = new Dados.Modelos.TipoDocumento();
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
            TipoSelecionado.Soma = (cbTipo.SelectedIndex == 1);
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
                TipoSelecionado.Soma = (cbTipoAlterar.SelectedIndex == 1);
                TipoSelecionado.Salvar();
                CarregarCadastros();
                LimparCampos();
                DialogAlteracao.IsOpen = false;
            }
        }

        private void dgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TipoSelecionado = dgDados.SelectedItem as Dados.Modelos.TipoDocumento;
            AlterarDescricao.Text = TipoSelecionado.Descricao;
            DialogAlteracao.IsOpen = true;
        }

        private void Descricao_LostFocus(object sender, RoutedEventArgs e)
        {
            Descricao.Text = Descricao.Text.ToUpper();
        }
    }
}
