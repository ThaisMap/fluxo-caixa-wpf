using System;
using System.Collections.Generic;
using System.Printing;
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

namespace Caixa.Relatorios
{
    /// <summary>
    /// Interação lógica para ImprimirAdiantamento.xam
    /// </summary>
    public partial class ImprimirAdiantamento : UserControl
    {
        public ImprimirAdiantamento()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

            PrintDialog printDlg = new PrintDialog(); 

            FlowDocument doc = ReciboAdiantamento.Document;
            doc = FormatDocument(doc);
            doc.Name = "TesteFlowDoc";
            // Create IDocumentPaginatorSource from FlowDocument  
            IDocumentPaginatorSource idpSource = doc;

            // Call PrintDocument method to send document to printer  
            if (printDlg.ShowDialog().Value)
                printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
        }

        private FlowDocument FormatDocument(FlowDocument doc)
        {
            // Formatação da página no papel
            double margens = 50;

            doc.PagePadding = new Thickness(margens);
            doc.PageWidth = 9 * 96 - margens * 2;
            doc.PageHeight = 11.7 * 96 - margens * 2;
            doc.ColumnWidth = doc.PageWidth;
            doc.IsColumnWidthFlexible = false;
            return doc;

        }
    }
}
