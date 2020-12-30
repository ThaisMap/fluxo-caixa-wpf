using Caixa.Models;
using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caixa.ViewModel
{
    public class FechamentoVM 
    { 

        public Fechamento_M Fechamento { get; set; } 

        public List<ItemFechamento> LancamentosPendentes { get; set; }

        public FechamentoVM()
        {
            Fechamento = new Fechamento_M(); 
            LancamentosPendentes = new List<ItemFechamento>();

            using (var Banco = new CaixaContext())
            {
                var lancamentos = Banco.Lancamentos.Select(x => x.Id);
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
            if( openFile.ShowDialog() == DialogResult.OK)
            {
                Fechamento.CaminhoArquivo = openFile.FileName;
            }
        }

        internal void Imprimir()
        {
            RelatoriosCrystal.Fechamento relatorio = new RelatoriosCrystal.Fechamento(); 

            relatorio.SetDataSource(LancamentosPendentes);
            Relatorios.ImprimirRelatorio imprimir = new Relatorios.ImprimirRelatorio(relatorio);
            imprimir.ShowDialog();
        }
    }
}
