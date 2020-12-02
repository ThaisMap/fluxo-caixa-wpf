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
                new Teste("27/11/2020", "001", "123456", "JOSE DA SILVA", 500, "ABC1234"), 
                new Teste("27/11/2020", "002", "123475", "JOAO DOS SANTOS", 20, "CDE2346"), 
                new Teste("27/11/2020", "003", "123478", "ANTONIO DE SOUZA", 200, "FGH1256"),  
            };

            DgCaixa.ItemsSource = testes;
        }
    }

    class Teste
    {
        public string Data {get; set;}
        public string Id {get; set;}
        public string Manifesto {get; set;}
        public string Motorista {get; set;}
        public int Valor {get; set;}
        public string Placa { get; set; }

       

        public Teste(string data, string id, string manifesto, string motorista, int valor, string placa)
        {
            Data = data;
            Id = id;
            Manifesto = manifesto;
            Motorista = motorista;
            Valor = valor;
            Placa = placa;
        }
    }
}
