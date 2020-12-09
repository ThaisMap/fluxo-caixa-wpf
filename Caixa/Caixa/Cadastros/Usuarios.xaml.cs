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
    /// Interação lógica para Usuarios.xam
    /// </summary>
    public partial class Usuarios : UserControl
    {
        public Usuarios()
        {
            InitializeComponent();
            CbCadastrados.ItemsSource = Listas.UsuariosCadastrados;
            CbCadastrados.DisplayMemberPath = "Nome";
            cbFilial.ItemsSource = Dados.Listas.Filiais;
            cbFilial.DisplayMemberPath = "Nome";

        }
    }
}
