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
using System.Windows.Shapes;

namespace Caixa.Listagens
{
    /// <summary>
    /// Interação lógica para Caixa.xam
    /// </summary>
    public partial class Caixa : UserControl
    {
        public Caixa()
        {
            InitializeComponent();
            DgCaixa.ItemsSource = Listas.Lancamentos;
        }

        public static readonly RoutedEvent EventoBtnFechamento =
          EventManager.RegisterRoutedEvent("EventoBtnFechamento", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Caixa));

        public event RoutedEventHandler BtnFechamento
        {
            add { AddHandler(EventoBtnFechamento, value); }
            remove { RemoveHandler(EventoBtnFechamento, value); }
        }

       
        private void FecharPopUpDialog(object sender, RoutedEventArgs e)
        {
            DialogLancamento.IsOpen = false;
        }

        private void btnFechamento_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(EventoBtnFechamento));
        }

        Lancamentos.PopUp popUp;
        private void BtnIncluir_Click(object sender, RoutedEventArgs e)
        {
            popUp = new Lancamentos.PopUp("Débito");
            AbrirPopUpDialog();
        }

        private void AbrirPopUpDialog()
        {
            PopUpDialog.Content = popUp;
            DialogLancamento.IsOpen = true;
            popUp.FecharDialog += FecharPopUpDialog;
        }

        private void BtnAdiantamento_Click(object sender, RoutedEventArgs e)
        {
           popUp = new Lancamentos.PopUp("Adiantamento");
            AbrirPopUpDialog();

        }

        private void BtnSuprimento_Click(object sender, RoutedEventArgs e)
        {
            popUp = new Lancamentos.PopUp("Suprimento");
            AbrirPopUpDialog();

        }
    }
}