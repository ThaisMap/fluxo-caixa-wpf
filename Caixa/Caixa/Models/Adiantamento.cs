using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caixa.Validacoes;

namespace Caixa.Models
{
    public class Adiantamento : Observavel
    {
        private Dados.Modelos.Adiantamento adiantamento;
        private Sessao status;

        public int Id { get => adiantamento.Id; }

        [Required(ErrorMessage ="Informe a data")]
        [FechamentoAberto(ErrorMessage = "Não há fechamento em aberto na data selecionada")]
        public DateTime Data
        {
            get => adiantamento.Data;
            set
            {
                ValidateProperty(value, "Data");
                adiantamento.Data = value;
                OnPropertyChanged("Data");
            }
        }

        [Required(ErrorMessage = "Informe o valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Informe um valor acima de 0")]
        public double Valor
        {
            get => adiantamento.Valor;
            set
            {
                ValidateProperty(value, "Valor");
                adiantamento.Valor = value;
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
                ValidateProperty(value, "Placa");
                adiantamento.Placa = value;
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
                ValidateProperty(value, "Motorista");
                adiantamento.Motorista = value;
                OnPropertyChanged("Motorista");
            }
        }

        public bool isValid()
        {
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(this, new ValidationContext(this), results, true);
        }

        public Adiantamento()
        {
            adiantamento = new Dados.Modelos.Adiantamento();
        }

        public Adiantamento(Dados.Modelos.Adiantamento doBanco)
        {
            adiantamento = doBanco;
        }


        private void DadosFixos()
        {
            adiantamento.Data = DateTime.Today;
            status = new Sessao();
            adiantamento.Usuario_Id = status.IdUsuario;
            adiantamento.Filial_Id = status.IdFilial;
            adiantamento.TipoDocumento_Id = Dados.Listas.TiposDocumento.Where(t => t.Descricao.ToLower() == "adiantamento").Select(t => t.Id).FirstOrDefault();
            adiantamento.Fechamento_Id = status.IdFechamento;
        }

        public void Salvar()
        {
            if (adiantamento.Usuario_Id < 1)
                DadosFixos();
            adiantamento.Salvar();
            status.AddValorSaldoFilial(-Valor);
        }
    }
}
