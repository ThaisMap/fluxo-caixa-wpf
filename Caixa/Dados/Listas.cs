using Dados.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Dados
{
    public static class Listas
    {
        private static CaixaContext Context = new CaixaContext();

        public static List<Filial> Filiais = Context.Filiais.ToList(); 

        public static List<Usuario> UsuariosCadastrados = Context.Usuarios.Include("Filial").ToList();

        public static List<TipoCobranca> TiposCobranca()
        {
            return Context.TiposCobranca.ToList();
        }

        public static List<TipoDocumento> TiposDocumento()
        {
            return Context.TiposDocumento.ToList();
        }

        public static List<Cliente> Clientes()
        {
            return Context.Clientes.ToList();
        }

        public static List<Lancamento> Lancamentos() { return Context.Lancamentos.ToList(); }
         
        public static List<Debito> Debitos = Context.Debitos.ToList();

        public static List<Fechamento> Fechamentos = Context.Fechamentos.ToList();

        public static List<Adiantamento> GetListaAdiantamentos()
        {
            return Context.Adiantamentos.Where(x => x.Pendente).ToList();
        }
    }
}

