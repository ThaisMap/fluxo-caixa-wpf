using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Caixa.Commands;
using Caixa.Validacoes;
using Dados.Modelos;

namespace Caixa.Models
{
    public class Adiantamento_M : Observavel
    {
        private Adiantamento adiantamento;
        private Sessao status = Sessao.Status;
        public ICommand ComandoImprimir { get; private set; }
        public ICommand ComandoEstornar { get; private set; }
        public int Id { get => adiantamento.Id; }

        [Required(ErrorMessage = "Informe a data")]
        [FechamentoAberto(ErrorMessage = "Não há fechamento em aberto na data selecionada")]
        public DateTime Data
        {
            get => adiantamento.Data;
            set
            {
                adiantamento.Data = value;
                ValidateProperty(value, "Data");
                OnPropertyChanged("Data");
            }
        }

        [Required(ErrorMessage = "Informe o valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Informe um valor acima de 0")]
        [SaldoSuficiente(ErrorMessage = "Saldo insuficiente")]
        public double Valor
        {
            get => adiantamento.Valor;
            set
            {
                adiantamento.Valor = value;
                ValidateProperty(value, "Valor");
                OnPropertyChanged("Valor");
            }
        }



        [Required(ErrorMessage = "Informe a placa")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "A placa deve ter 7 caracteres")]
        public string Placa
        {
            get => adiantamento.Placa;
            set
            {
                value = value.ToUpper();
                adiantamento.Placa = value;
                ValidateProperty(value, "Placa");
                OnPropertyChanged("Placa");
            }
        }

        [Required(ErrorMessage = "Informe o nome do motorista")]
        [MinLength(3, ErrorMessage = "Minimo de 3 caracteres")]
        public string Motorista
        {
            get => adiantamento.Motorista;
            set
            {
                value = value.ToUpper();
                adiantamento.Motorista = value;
                ValidateProperty(value, "Motorista");
                OnPropertyChanged("Motorista");
            }
        }

        public bool IsValid { get => isValid(); }
               
        public Adiantamento_M()
        {
            adiantamento = new Adiantamento();
            adiantamento.Data = DateTime.Now;
            ComandoImprimir = new ImprimirAdiantamento(this);
        }

        public Adiantamento_M(Adiantamento doBanco)
        {
            adiantamento = doBanco;
            ComandoImprimir = new ImprimirAdiantamento(this);
        }


        private void DadosFixos()
        { 
            adiantamento.Usuario_Id = status.IdUsuario;
            adiantamento.Filial_Id = status.IdFilial;
            adiantamento.TipoDocumento_Id = Dados.Listas.TiposDocumento().Where(t => t.Descricao.ToLower() == "adiantamento").Select(t => t.Id).FirstOrDefault();
            adiantamento.Fechamento_Id = status.IdFechamento;
        }

        internal void Estornar()
        {
            if (adiantamento.Usuario_Id < 1)
                DadosFixos();
            adiantamento.Pendente = false;
            adiantamento.Salvar();
            status.AddValorSaldoFilial(Valor);
        }

        public void Salvar()
        {
            if (adiantamento.Usuario_Id < 1)
                DadosFixos();
            adiantamento.Salvar();
            status.AddValorSaldoFilial(-Valor);
        }
         
        internal void Imprimir()
        {
            RelatoriosCrystal.Adiantamento recibo = new RelatoriosCrystal.Adiantamento();
            List<AdiantamentoRelatorio> dadosRelatorio =
                new List<AdiantamentoRelatorio>() { new AdiantamentoRelatorio(Id) };
            recibo.SetDataSource(dadosRelatorio);
            Relatorios.ImprimirRelatorio imprimir = new Relatorios.ImprimirRelatorio(recibo);
            imprimir.ShowDialog();
        }
    }
}
