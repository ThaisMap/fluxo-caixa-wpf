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

namespace Caixa.Componentes
{
    /// <summary>
    /// Interação lógica para Status.xam
    /// </summary>
    public partial class Status : UserControl
    {

        public string NomeUsuario { get; private set; } = Dados.Status.Usuario.Nome;
        public string NomeFilial { get; private set; } = Dados.Status.Filial.Nome;
        public double SaldoInicial { get; private set; } = 0;
        public double Saldo { get; private set; } = Dados.Status.Saldo;
        public DateTime Hoje { get; private set; } = DateTime.Today;
        public Status()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
