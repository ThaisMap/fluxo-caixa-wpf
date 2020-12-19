using System;
using System.Collections.Generic;

namespace Dados.Modelos
{
    public class Filial
    {
        public Filial(string nome, double saldo)
        {
            Nome = nome;
            Saldo = saldo;
        }


        public Filial() : base()
        {
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public ICollection<Lancamento> Lancamentos { get; set; }
        public ICollection<Fechamento> Fechamentos { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
 
        
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
                    Banco.Filiais.Find(Id).Nome = Nome;
                }
                Banco.SaveChanges();
            }
        }

    }

}
