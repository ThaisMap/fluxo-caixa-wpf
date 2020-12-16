using System.Collections.Generic;

namespace Dados.Modelos
{
    public class Filial : BaseClass
    {
        public Filial(string nome, double saldo, int id) : base(id)
        {
            Nome = nome;
            Saldo = saldo;
        }


        public Filial() : base()
        {
        }

        public string Nome { get; set; }
        public double Saldo { get; set; }
        public ICollection<Lancamento> Lancamentos { get; set; }
        public ICollection<Fechamento> Fechamentos { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }

}
