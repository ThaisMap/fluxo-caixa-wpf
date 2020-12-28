using Caixa.Validacoes;
using Dados;
using Dados.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Models
{
    public class Debito_M : Observavel
    {
        private Debito debito;
        private Sessao status;



        [Required(ErrorMessage = "Informe a data")]
        [FechamentoAberto(ErrorMessage = "Não há fechamento em aberto na data selecionada")]
        public DateTime Data
        {
            get => debito.Data;
            set
            {
                ValidateProperty(value, "Data");
                debito.Data = value;
                OnPropertyChanged("Data");
            }
        }


        [Required(ErrorMessage = "Informe o valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Informe um valor acima de 0")]
        [SaldoSuficiente(ErrorMessage = "Saldo insuficiente")]
        public double Valor
        {
            get => debito.Valor;
            set
            {
                ValidateProperty(value, "Valor");
                debito.Valor = value;
                OnPropertyChanged("Valor");
            }
        }

        [Required(ErrorMessage = "Selecione um tipo")]
        public int TipoDocumento
        {
            get => debito.TipoDocumento_Id;
            set
            {
                ValidateProperty(value, "TipoDocumento");
                debito.TipoDocumento_Id = value;
                OnPropertyChanged("TipoDocumento");
            }
        }

        [Required(ErrorMessage = "Informe o numero do Cte")]
        public int Cte
        {
            get => debito.Cte;
            set
            {
                ValidateProperty(value, "TipoDocumento");
                debito.Cte = value;
                OnPropertyChanged("TipoDocumento");
            }
        }

        [Required(ErrorMessage = "Informe a quantidade de volumes")]
        public int Volumes
        {
            get => debito.Volumes;
            set
            {
                ValidateProperty(value, "TipoDocumento");
                debito.Volumes = value;
                OnPropertyChanged("TipoDocumento");
            }
        }

        [Required(ErrorMessage = "Informe o cliente")]
        public int Cliente
        {
            get => debito.Cliente_Id;
            set
            {
                ValidateProperty(value, "TipoDocumento");
                debito.Cliente_Id = value;
                OnPropertyChanged("TipoDocumento");
            }
        }

        [Required(ErrorMessage = "Selecione um tipo")]
        public int TipoCobranca
        {
            get => debito.TipoCobranca_Id;
            set
            {
                ValidateProperty(value, "TipoDocumento");
                debito.TipoCobranca_Id = value;
                OnPropertyChanged("TipoDocumento");
            }
        }
    }
}
