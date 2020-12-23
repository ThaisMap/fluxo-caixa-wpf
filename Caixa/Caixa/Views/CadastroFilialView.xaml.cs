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

namespace Caixa.Views
{
    /// <summary>
    /// Interação lógica para CadastroFilialView.xam
    /// </summary>
    public partial class CadastroFilialView : UserControl
    {
        public CadastroFilialView()
        {
            InitializeComponent();
            ViewModel.CadastroFilialVM cadastro = new ViewModel.CadastroFilialVM();
            DataContext = cadastro;
        }
    }
}
