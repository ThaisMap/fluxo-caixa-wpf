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
using System.Windows.Shapes;
using Dados.Modelos;
using Dados;
using System.Linq;
using Caixa.ViewModel;

namespace Caixa
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private LoginVM controlador = new LoginVM();
        public Login()
        {
            InitializeComponent();
            DataContext = controlador;
        }

        public bool Validar()
        {
            return controlador.ValidarLogin(TxbSenha.Password);
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Validar())
            {
                MainWindow main = new MainWindow(controlador.Id);
                this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Login / senha inválidos");
            }
        }
    }
}
