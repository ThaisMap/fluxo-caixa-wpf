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

        public int Id { get; private set; }
        [Required(ErrorMessage = "Informe um nome")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Mínimo de 5 caracteres")]
        public string Nome
        {
            get =>  filial.Nome;
            set
            {
                ValidateProperty(value, "Nome");
                filial.Nome = value;
                OnPropertyChanged("Nome");
            }
        }

        [Required(ErrorMessage = "Informe o saldo")]
        public double Saldo
        {
            get => filial.Saldo;

            set
            {
                ValidateProperty(value, "Saldo");
                filial.Saldo = value;
                OnPropertyChanged("Saldo");
            }
        }
        public Filial(string nome, double saldo)
        {
            Nome = nome;
            Saldo = saldo;
        }

        public Filial(Dados.Modelos.Filial filialBanco)
        {
            filial = filialBanco;
        }

        public Filial()
        {
        }


        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }

        public void Salvar()
        {
            using (var Banco = new CaixaContext())
            {
                if (Id == 0)
                {
                    Banco.Filiais.Add(filial);
                }
                else
                {
                    Banco.Filiais.Find(Id).Nome = Nome;
                }
                Banco.SaveChanges();
            }
        }
    }
}
