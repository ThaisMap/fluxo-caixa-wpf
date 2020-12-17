using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Caixa.Cadastros
{
    /// <summary>
    /// Interação lógica para Filial.xam
    /// </summary>
    public partial class Filial : UserControl 
    {
        private List<Dados.Modelos.Filial> FiliaisCadastradas;
        private Dados.Modelos.Filial FilialSelecionada;

        public Filial()
        {
            InitializeComponent();
            EsconderMsgErro();
            CarregarCadastros();
            FilialSelecionada = new Dados.Modelos.Filial();
        }

        private void CarregarCadastros()
        {
            using (var Banco = new CaixaContext())
            {
                FiliaisCadastradas = Banco.Filiais.ToList();
            }
            dgDados.ItemsSource = FiliaisCadastradas;
        }

        private void EsconderMsgErro()
        {
            NomeErro.Visibility = Visibility.Hidden;
            SaldoErro.Visibility = Visibility.Hidden;
        }

        private void LimparCampos()
        {
            Nome.Text = "";
            Saldo.Text = "";
            AlterarNomeFilial.Text = "";
            FilialSelecionada = new Dados.Modelos.Filial();
        }

        private bool VerificarPreenchimento()
        {
            if (Nome.Text.Length < 3)
            {
                NomeErro.Visibility = Visibility.Visible;
                Nome.Focus();
                return false;
            }
            else
            {
                NomeErro.Visibility = Visibility.Hidden;
            }

            if (!double.TryParse(Saldo.Text, out _))
            {
                SaldoErro.Visibility = Visibility.Visible;
                Saldo.Focus();
                return false;
            }
            else
            {
                SaldoErro.Visibility = Visibility.Hidden;
            }
            return true;
        }

        public void MontarObjeto()
        {
            FilialSelecionada.Nome = Nome.Text;
            FilialSelecionada.Saldo = double.Parse(Saldo.Text);
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarPreenchimento())
            {
                try
                {
                    MontarObjeto();
                    FilialSelecionada.Salvar();
                    CarregarCadastros();
                    LimparCampos();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Houve um erro");
                }
            }
        }

        private void dgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FilialSelecionada = dgDados.SelectedItem as Dados.Modelos.Filial;
            AlterarNomeFilial.Text = FilialSelecionada.Nome;
            DialogFilial.IsOpen = true;
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (AlterarNomeFilial.Text.Length < 3)
                AlterarNomeFilial.Focus();
            else
            {
                FilialSelecionada.Nome = AlterarNomeFilial.Text;
                FilialSelecionada.Salvar();
            }
            LimparCampos();
            CarregarCadastros();
            DialogFilial.IsOpen = false;
        }
    }
}