using Dados.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class Status
    { 
        public static Usuario Usuario  = Listas.UsuariosCadastrados.FirstOrDefault();
        public static Filial Filial = Usuario.Filial;
        public static double Saldo = Filial.Saldo;
        public static Fechamento FechamentoPendente = Listas.Fechamentos.FirstOrDefault();
    }
}
