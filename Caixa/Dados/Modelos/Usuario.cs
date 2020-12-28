using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dados.Modelos
{
    [Table("Usuarios")]
    public class Usuario 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
        public bool Admin { get; set; }
        public int Filial_Id { get; set; }
        public bool Ativo { get; set; }
        public virtual Filial Filial { get; set; }
        public virtual ICollection<Lancamento> Lancamentos { get; set; }

        public Usuario(string nome, string senha, string login, bool admin, int filial, bool ativo) 
        {
            Nome = nome;
            Senha = senha;
            Login = login;
            Admin = admin;
            Filial_Id = filial;
            Ativo = ativo;
        }        
        public Usuario()
        {

        }
        public void Salvar()
        {
            using (var Banco = new CaixaContext())
            {
                if (Id == 0)
                {
                    Banco.Usuarios.Add(this);
                }
                else
                {
                    var usuario = Banco.Usuarios.Find(Id);
                    usuario.Nome = Nome;
                    usuario.Senha = Senha;
                    usuario.Login = Login;
                    usuario.Admin = Admin;
                    usuario.Ativo = Ativo;
                }
                Banco.SaveChanges();
            }
        }
    }
}