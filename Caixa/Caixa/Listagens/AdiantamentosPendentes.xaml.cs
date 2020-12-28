using Caixa; 
using Dados;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Caixa.Listagens
{
    /// <summary>
    /// Interação lógica para AdiantamentosPendentes.xam
    /// </summary>
    public partial class AdiantamentosPendentes : UserControl
    {
        public List<Models.Adiantamento> Pendentes { get; private set; }
        public Models.Adiantamento AdiantamentoSelecionado { get; set; }

        public AdiantamentosPendentes()
        {
            InitializeComponent();
            Pendentes = new List<Models.Adiantamento>();
            foreach (var item in Listas.AdiantamentosPendentes)
            {
                Pendentes.Add(new Models.Adiantamento(item));
            }

            DataContext = this;
        }

        private void BtnIncluir_Click(object sender, RoutedEventArgs e)
        {
            DialogoLancamento.IsOpen = true;
        }

        private void Adiantamento_AdiantamentoLancado(object sender, RoutedEventArgs e)
        {
            DialogoLancamento.IsOpen = false;
        }

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (AdiantamentoSelecionado != null)
            {
                RelatoriosCrystal.Adiantamento recibo = new RelatoriosCrystal.Adiantamento();
                //TODO: Criar um DataSet e um Modelo para impressão com as mesmas props 
                //ou alterar o adiantamento para ter o nome da filial
                List<Models.AdiantamentoRelatorio> dadosRelatorio =
                    new List<Models.AdiantamentoRelatorio>() { new Models.AdiantamentoRelatorio(AdiantamentoSelecionado.Id) };

                recibo.SetDataSource(dadosRelatorio);
                Relatorios.ImprimirRelatorio imprimir = new Relatorios.ImprimirRelatorio(recibo);
                imprimir.ShowDialog();
            }
        }
    }
}
