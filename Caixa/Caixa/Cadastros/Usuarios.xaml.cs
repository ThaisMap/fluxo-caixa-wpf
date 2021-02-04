using Caixa.Models;
using Dados;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interação lógica para Usuarios.xam
    /// </summary>
    public partial class Usuarios : UserControl
    {
        private bool estaEditando = false;
        Dados.Modelos.Usuario UsuarioSelecionado = new Dados.Modelos.Usuario();
        List<Dados.Modelos.Usuario> UsuariosCadastrados;
        List<Dados.Modelos.Filial> filiaisCadastradas = Listas.Filiais();
        public Usuarios()
        {
            InitializeComponent(); 
            CbCadastrados.DisplayMemberPath = "Nome";
            cbFilial.DisplayMemberPath = "Nome";
            cbFilial.SelectedValuePath = "Id";
            Sessao status = Sessao.Status;
            CkAdmin.IsEnabled = status.UsuarioMaster;
            CarregarCadastros();
        }

        private void CarregarCadastros()
        {
            UsuariosCadastrados =  Listas.UsuariosCadastrados();
            CbCadastrados.ItemsSource = UsuariosCadastrados;
            cbFilial.ItemsSource = filiaisCadastradas;
        }

        private void LimparCampos()
        {
            Nome.Text = "";
            Login.Text = "";
            Senha.Password = "";
            Senha2.Password = "";
            tbAtivo.IsChecked = true;
            CkAdmin.IsChecked = false;
            cbFilial.SelectedIndex = -1;
            UsuarioSelecionado = new Dados.Modelos.Usuario();
            estaEditando = false;
        }

        private bool VerificarPreenchimento()
        {
            if (Nome.Text.Length < 3)
            { 
                Nome.Focus();
                return false;
            }
            if (cbFilial.SelectedIndex == -1)
            {
                cbFilial.Focus();
                return false;
            }
            if (Login.Text.Length < 3)
            {
                Login.Focus();
                return false;
            }
            if (!estaEditando)
            {
                if (Senha.Password.Length < 4)
                {
                    Senha.Focus();
                    return false;
                }
                if (Senha2.Password != Senha.Password)
                {
                    Senha2.Focus();
                    return false;
                }
            }
            else
            { 
                if (Senha.Password != UsuarioSelecionado.Senha)
                {
                    Senha.Focus();
                    return false;
                }
                if (Senha2.Password.Length > 0 && Senha2.Password.Length < 4)
                {
                    Senha2.Focus();
                    return false;
                }
            }
            return true;
        }

        public void MontarObjeto()
        {
            UsuarioSelecionado.Nome = Nome.Text;
            UsuarioSelecionado.Login = Login.Text;
            if (estaEditando && Senha2.Password != "")
            {
                UsuarioSelecionado.Senha = Senha2.Password;
            }
            else if (!estaEditando)
            {
                UsuarioSelecionado.Senha = Senha.Password;
            }
            UsuarioSelecionado.Ativo = (bool)tbAtivo.IsChecked;
            UsuarioSelecionado.Admin = (bool)CkAdmin.IsChecked;
            UsuarioSelecionado.Filial_Id = (int)cbFilial.SelectedValue;
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarPreenchimento())
            {
                try
                {
                    MontarObjeto();
                    UsuarioSelecionado.Salvar();
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
            UsuarioSelecionado = CbCadastrados.SelectedItem as Dados.Modelos.Usuario;
            Nome.Text = UsuarioSelecionado.Nome;
            Login.Text = UsuarioSelecionado.Login;
            tbAtivo.IsChecked = UsuarioSelecionado.Ativo;
            CkAdmin.IsChecked = UsuarioSelecionado.Admin;
            cbFilial.SelectedValue = UsuarioSelecionado.Filial_Id;
            estaEditando = true;
        }
    }
}
