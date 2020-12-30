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
        public List<Dados.Modelos.Lancamento> LancamentosPendentes { get; set; }

        public FechamentoVM()
        {
            Fechamento = new Fechamento_M();
            LancamentosPendentes = Listas.Lancamentos();
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
    }
}
