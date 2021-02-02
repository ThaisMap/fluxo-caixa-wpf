using Dados;
using Dados.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Caixa.Models
{
    public class Fechamento_M : Observavel
    {
        private Fechamento fechamento;

        public int Id { get => fechamento.Id; }
        public DateTime Data { get => fechamento.Data; }
        public double ValorInicial { get => fechamento.ValorInicial; set => fechamento.ValorInicial = value; }
        public double? ValorFinal { get => fechamento.ValorFinal; set => fechamento.ValorFinal = value; }

        public List<ItemFechamento> LancamentosPendentes { get; set; }

        public bool PodeFechar => podeFechar();

        public string CaminhoArquivo
        {
            get => fechamento.ArquivoScan;
            set
            {
                fechamento.ArquivoScan = value;
                ValidateProperty(value, "CaminhoArquivo");
                OnPropertyChanged("CaminhoArquivo");
            }
        }

        public bool Fechado
        {
            get => fechamento.Fechado; set => fechamento.Fechado = value;
        }

        private bool podeFechar()
        {
            if (fechamento.Fechado || Data.Date == DateTime.Today)
                return false;

            var pendentes = Listas.GetFechamentosPendentes();
            return !pendentes.Where(x => x.Data < Data && !x.Fechado).Any();
        }

        public Fechamento_M(Filial filial)
        {
            fechamento = new Fechamento(filial);
        }

        public Fechamento_M()
        {
            fechamento = new Fechamento();
        }

        public Fechamento_M(Fechamento doBanco)
        {
            fechamento = doBanco;
        }

        public void Salvar()
        {
            fechamento.Salvar();
        }

        public void CarregarLancamentos()
        {
            LancamentosPendentes = new List<ItemFechamento>();
            using (var Banco = new CaixaContext())
            {
                var lancamentos = Banco.Lancamentos.Where(x => x.Fechamento_Id == fechamento.Id).Select(x => x.Id);
                foreach (var id in lancamentos)
                {
                    LancamentosPendentes.Add(new ItemFechamento(id));
                }
            }
        }

        public double CalculaValorFinal()
        {
            ValorFinal = ValorInicial;
            foreach (var item in LancamentosPendentes)
            {
                ValorFinal += item.Valor;
            }
            return (double)ValorFinal;
        }
    }
}