using System.Collections.Generic;

namespace Dados.Modelos
{
    public class Usuario 
    {
        public Usuario(string nome, string senha, string login, bool admin, Filial filial) 
        {
            Nome = nome;
            Senha = senha;
            Login = login;
            Admin = admin;
            Filial = filial;
        }
        public Usuario()
        {

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
        public bool Admin { get; set; }
        public Filial Filial { get; set; }
        public ICollection<Lancamento> Lancamentos { get; set; }
    }
}