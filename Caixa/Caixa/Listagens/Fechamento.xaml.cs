﻿using Dados;
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
using Caixa.ViewModel;
using System.Windows.Shapes;
using Caixa.Models;

namespace Caixa.Listagens
{
    /// <summary>
    /// Interação lógica para Fechamento.xam
    /// </summary>
    public partial class Fechamento : UserControl
    {
        private FechamentoVM controlador;
        public Fechamento(Fechamento_M fechamento)
        {
            InitializeComponent();
            controlador = new FechamentoVM();
            DataContext = controlador; 
        }

        public static readonly RoutedEvent EventoVoltarListaFechamentos =
  EventManager.RegisterRoutedEvent("EventoVoltarListaFechamentos", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Fechamento));

        public event RoutedEventHandler BtnFechamento
        {
            add { AddHandler(EventoVoltarListaFechamentos, value); }
            remove { RemoveHandler(EventoVoltarListaFechamentos, value); }
        }


        private void BtnArquivo_Click(object sender, RoutedEventArgs e)
        {
            controlador.SelecionarArquivo();
        }

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fechamento finalizado");
            RaiseEvent(new RoutedEventArgs(EventoVoltarListaFechamentos));
        }
    }
}
