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

namespace Caixa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Teste> testes = new List<Teste>()
            {
                new Teste("27/11/2020", "-", "-", "SUPRIMENTO", "R$ 2000,00", "SUPRIMENTO"), 
                new Teste("27/11/2020", "123456", "PRAFESTA", "DEBITO", "R$ 20,00", "RECIBO"), 
                new Teste("27/11/2020", "112233", "CASTELATO", "DEBITO", "R$ 200,00", "ADIANTAMENTO"), 
                new Teste("27/11/2020", "102030", "MARILAN", "DEBITO", "R$ 50,00", "RECIBO"), 
            };

            DgTipos.ItemsSource = testes;
        }
    }

    class Teste
    {
        public string Data {get; set;}
        public string Cte {get; set;}
        public string Cliente {get; set;}
        public string TipoValor {get; set;}
        public string valor {get; set;}
        public string TipoDoc { get; set; }

       

        public Teste(string data, string cte, string cliente, string tipoValor, string valor, string tipoDoc)
        {
            Data = data;
            Cte = cte;
            Cliente = cliente;
            TipoValor = tipoValor;
            this.valor = valor;
            TipoDoc = tipoDoc;
        }
    }
}
