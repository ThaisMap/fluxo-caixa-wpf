using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
        public TiposDocumento()
        {
            string[] tiposPossiveis = { "Crédito", "Débito" };

            InitializeComponent();
            dgDados.ItemsSource = Dados.Listas.TiposDocumento;
            cbTipo.ItemsSource = tiposPossiveis;
        }
    }
}
