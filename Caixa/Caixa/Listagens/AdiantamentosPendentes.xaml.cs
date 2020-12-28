﻿using Caixa; 
using Caixa.ViewModel; 
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
    
        public AdiantamentosPendentes()
        {
            InitializeComponent();
            DataContext = new AdiantamentosPendentesVM();
        }

        private void BtnIncluir_Click(object sender, RoutedEventArgs e)
        {
            DialogoLancamento.IsOpen = true;
        }

        private void Adiantamento_AdiantamentoLancado(object sender, RoutedEventArgs e)
        {
            DialogoLancamento.IsOpen = false;
        }

    }
}
