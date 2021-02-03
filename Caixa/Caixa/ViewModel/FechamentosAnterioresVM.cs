using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caixa.Models;
using Dados;

namespace Caixa.ViewModel
{
    public class FechamentosAnterioresVM : Observavel
    {
        private DateTime dataInicial = DateTime.Today;
        private DateTime dataFinal = DateTime.Today;

        public DateTime DataInicial
        {
            get => dataInicial;
            set
            {
                dataInicial = value;
                OnPropertyChanged("DataInicial");
            }
        }

        public DateTime DataFinal
        {
            get => dataFinal;
            set
            {
                dataFinal = value;
                OnPropertyChanged("DataFinal");
            }
        }


        public Fechamento_M FechamentoSelecionado { get; set; }
        public ObservableCollection<Fechamento_M> Fechamentos { get; set; }

        public FechamentosAnterioresVM()
        { 
            Fechamentos = new ObservableCollection<Fechamento_M>();
        }

        public void Filtrar()
        {
            Sessao status = Sessao.Status;
            using (var Banco = new CaixaContext())
            {
                var fechamentosBanco = Banco.Fechamentos
                    .Where(x=> x.Filial_Id == status.IdFilial)
                    .Where(x => x.Data >= DbFunctions.TruncateTime(DataInicial) && x.Data <= DbFunctions.TruncateTime(DataFinal));
                Fechamentos.Clear();
                foreach (var item in fechamentosBanco)
                {
                    Fechamentos.Add(new Fechamento_M(item));
                }
            }
        }

        public void Imprimir()
        {
            FechamentoSelecionado.CarregarLancamentos();
            if (FechamentoSelecionado.LancamentosPendentes.Count > 0)
            {
                RelatoriosCrystal.Fechamento relatorio = new RelatoriosCrystal.Fechamento();
                relatorio.SetDataSource(FechamentoSelecionado.LancamentosPendentes);
                Relatorios.ImprimirRelatorio imprimir = new Relatorios.ImprimirRelatorio(relatorio);
                imprimir.ShowDialog();
            }
        }

        public bool AbrirArquivo()
        {
            if (File.Exists(FechamentoSelecionado.CaminhoArquivo))
            {
                System.Diagnostics.Process.Start(@FechamentoSelecionado.CaminhoArquivo);
                return true;
            }
            else
                return false;
        }
    }
}
