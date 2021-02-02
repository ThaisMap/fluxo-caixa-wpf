using Caixa.Commands;
using Caixa.Models;
using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Caixa.ViewModel
{
    public class FechamentoVM
    {
        private FechamentosPendentes fechamentosPendentes;
        public Fechamento_M Fechamento => fechamentosPendentes.LiberadoParaFechar;
        public ICommand ComandoFechar { get; private set; }

        public List<ItemFechamento> LancamentosPendentes { get => Fechamento.LancamentosPendentes; }
        public bool PodeFechar { get => Fechamento.CaminhoArquivo != String.Empty; }

        public double SaldoInicial => Fechamento.ValorInicial;
        public double SaldoFinal => Fechamento.CalculaValorFinal();
       
        public FechamentoVM()
        {
            fechamentosPendentes = new FechamentosPendentes();
            fechamentosPendentes.Carregar();
            Fechamento.CarregarLancamentos();
            ComandoFechar = new RealizaFechamento(this);
        }

        public void SelecionarArquivo()
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                DefaultExt = "pdf",
                Filter = "Arquivos scanneados |*.pdf"
            };
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Fechamento.CaminhoArquivo = openFile.FileName;
            }
        }

        private void Fechar()
        {
            Fechamento.Fechado = true;
            Fechamento.CalculaValorFinal();
            Fechamento.Salvar();
            Fechamento.LancamentosPendentes.ForEach(x => x.SaldoFinal = (double)Fechamento.ValorFinal);
        }

        internal void FecharEImprimir()
        {
            Fechar();
            Imprimir();
        }

        private void Imprimir()
        {
            if (LancamentosPendentes.Count > 0)
            {
                RelatoriosCrystal.Fechamento relatorio = new RelatoriosCrystal.Fechamento();
                relatorio.SetDataSource(LancamentosPendentes);
                Relatorios.ImprimirRelatorio imprimir = new Relatorios.ImprimirRelatorio(relatorio);
                imprimir.ShowDialog();
            }
        }
    }
}
