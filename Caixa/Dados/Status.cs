using Dados.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados
{
    public static class Status
    { 
        public static Usuario Usuario  = Listas.UsuariosCadastrados[0];
        public static Filial Filial = Usuario.Filial;
        public static double Saldo = Filial.Saldo;
        public static Fechamento FechamentoPendente = Listas.Fechamentos[1];
    }
}
