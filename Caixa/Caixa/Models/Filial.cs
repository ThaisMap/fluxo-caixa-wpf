using Dados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Models
{
    public class Filial : Observavel
    {
        private Dados.Modelos.Filial filial = new Dados.Modelos.Filial();

        public int Id { get => filial.Id; }
        [Required(ErrorMessage = "Informe um nome")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Mínimo de 5 caracteres")]
        public string Nome
        {
            get =>  filial.Nome;
            set
            {
                filial.Nome = value;
                ValidateProperty(value, "Nome");
                OnPropertyChanged("Nome");
            }
        }

        [Required(ErrorMessage = "Informe o saldo")]
        public double Saldo
        {
            get => filial.Saldo;

            set
            {
                filial.Saldo = value;
                ValidateProperty(value, "Saldo");
                OnPropertyChanged("Saldo");
            }
        }

        public Filial(Dados.Modelos.Filial filialBanco)
        {
            filial = filialBanco;
        }

        public Filial()
        {
        }

        public void Salvar()
        {
            filial.Salvar();
        }
    }
}
