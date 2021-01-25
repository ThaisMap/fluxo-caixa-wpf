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

        public Fechamento_M Fechamento { get; set; }
        public ICommand ComandoFechar { get; private set; }

        public List<ItemFechamento> LancamentosPendentes { get; set; }
        public bool PodeFechar { get => Fechamento.CaminhoArquivo != String.Empty; }

        public double SaldoFinal => CalculaValorFinal();

        public FechamentoVM(Fechamento_M fechamento)
        {
            Fechamento = fechamento;
            LancamentosPendentes = new List<ItemFechamento>();
            ComandoFechar = new RealizaFechamento(this);
            using (var Banco = new CaixaContext())
            {
                var lancamentos = Banco.Lancamentos.Where(x => x.Fechamento_Id == fechamento.Id).Select(x => x.Id);
                foreach (var id in lancamentos)
                {
                    LancamentosPendentes.Add(new ItemFechamento(id));
                }
            }
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
            CalculaValorFinal();
            Fechamento.Salvar();
            LancamentosPendentes.ForEach(x => x.SaldoFinal = (double)Fechamento.ValorFinal); 
        }


        private double CalculaValorFinal()
        {
            Fechamento.ValorFinal = Fechamento.ValorInicial;
            foreach (var item in LancamentosPendentes)
            {
                Fechamento.ValorFinal += item.Valor;
            }
            return (double)Fechamento.ValorFinal;
        }

        internal void FecharEImprimir()
        {
            Fechar();
            Imprimir();
        } 

        private void Imprimir()
        { 
            RelatoriosCrystal.Fechamento relatorio = new RelatoriosCrystal.Fechamento(); 
            relatorio.SetDataSource(LancamentosPendentes);
            Relatorios.ImprimirRelatorio imprimir = new Relatorios.ImprimirRelatorio(relatorio);
            imprimir.ShowDialog();
        }
    }
}
