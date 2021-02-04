using Dados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Models
{
    public class Usuario_M : Observavel
    {
        private Dados.Modelos.Usuario usuario;
        private string login;
        private string senha;

        [Required(ErrorMessage ="Informe o login")]
        public string Login
        {
            get => login;
            set
            {
                login = value;
                ValidateProperty(value, "Login");
                OnPropertyChanged("Login");
            }
        }
         
        public int Id
        {
            get ;
            private set;
        }

        public Usuario_M()
        {
            usuario = new Dados.Modelos.Usuario();
        }

        public bool UsuarioExiste()
        { 
            using (var Banco = new CaixaContext())
            {
                return Banco.Usuarios.Any(x => x.Login == Login);
            }
        }

        public bool SenhaCorreta(string senha)
        {
            using (var Banco = new CaixaContext())
            {
                Id = Banco.Usuarios
                    .Where(x => x.Login == Login && x.Senha == senha)
                    .Select(x=> x.Id)
                    .DefaultIfEmpty(-1)
                    .FirstOrDefault();
                return Id > 0;
            }
        }

    }
}
