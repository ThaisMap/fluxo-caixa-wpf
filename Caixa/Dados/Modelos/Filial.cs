using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table("Filiais")]
    public class Filial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public virtual ICollection<Lancamento> Lancamentos { get; set; }
        public virtual ICollection<Fechamento> Fechamentos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }

        public Filial(string nome, double saldo)
        {
            Nome = nome;
            Saldo = saldo;
        }


        public Filial() : base()
        {
        }


        public void Salvar()
        {
            using (var Banco = new CaixaContext())
            {
                if (Id == 0)
                {
                    Banco.Filiais.Add(this);
                }
                else
                {
                    var doBanco = Banco.Filiais.Find(Id);
                    doBanco.Nome = Nome;
                    doBanco.Saldo = Saldo;

                }
                Banco.SaveChanges();
            }
        }

    }

}