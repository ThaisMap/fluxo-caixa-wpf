﻿using Caixa.ViewModel;
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

namespace Caixa.Views
{
    /// <summary>
    /// Interação lógica para Suprimento.xam
    /// </summary>
    public partial class LancarSuprimento : UserControl
    {

        public LancarSuprimento()
        {
            InitializeComponent();
            DataContext = new LancarSuprimentoVM();
        }
        public static readonly RoutedEvent EventoSuprimentoLancado =
          EventManager.RegisterRoutedEvent("EventoSuprimentoLancado", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LancarSuprimento));

        public event RoutedEventHandler SuprimentoLancado
        {
            add { AddHandler(EventoSuprimentoLancado, value); }
            remove { RemoveHandler(EventoSuprimentoLancado, value); }
        }

        private void BtnLancar_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(EventoSuprimentoLancado));
        }
            }
}
