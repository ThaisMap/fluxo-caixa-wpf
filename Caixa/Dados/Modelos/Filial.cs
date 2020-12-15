namespace Dados.Modelos
{
    public class Filial : BaseClass
    {
        public Filial(string nome, double saldo, int id) : base(id)
        {
            Nome = nome;
            Saldo = saldo;
        }

        public string Nome { get; set; }
        public double Saldo { get; set; }
    }

}
