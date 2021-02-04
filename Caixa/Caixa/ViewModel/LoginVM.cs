using Caixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.ViewModel
{
    public class LoginVM : Observavel
    {
        public Usuario_M Usuario { get; set; }

        public int Id => Usuario.Id;

        public LoginVM()
        {
            Usuario = new Usuario_M();
        }
        
        public bool ValidarLogin(string senha)
        {
            return Usuario.UsuarioExiste() && Usuario.SenhaCorreta(senha);
        }

        
    }
}
