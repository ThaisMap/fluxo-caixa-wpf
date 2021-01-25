using CrystalDecisions.CrystalReports.Engine;
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

namespace Caixa.Relatorios
{
    /// <summary>
    /// Interação lógica para ImprimirAdiantamento.xam
    /// </summary>
    public partial class ImprimirRelatorio : Window
    {
        public ImprimirRelatorio()
        {
            InitializeComponent();
            RelatoriosCrystal.Fechamento fechamento = new RelatoriosCrystal.Fechamento();
            VisualizadorRelatorio.ViewerCore.ReportSource = fechamento;
            fechamento.SetDataSource(Dados.Listas.GetFechamentosPendentes());
        }

        public ImprimirRelatorio(ReportClass relatorio)
        {
            InitializeComponent();
            VisualizadorRelatorio.ViewerCore.ReportSource = relatorio;
        }
    }
}
