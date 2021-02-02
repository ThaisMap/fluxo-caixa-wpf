using Dados.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace Dados
{
    public static class Listas
    {
        private static CaixaContext Context = new CaixaContext();
        //.Where(x => x.Filial_Id == idFilial)
        public static List<Filial> Filiais()
        {
            return Context.Filiais.ToList();
        }

        public static List<Usuario> UsuariosCadastrados()
        {
            return Context.Usuarios.Include("Filial").ToList();
        }

        public static List<TipoCobranca> TiposCobranca()
        {
            return Context.TiposCobranca.ToList();
        }

        public static List<TipoDocumento> TiposDocumento()
        {
            return Context.TiposDocumento.ToList();
        }

        public static List<TipoDocumento> TiposDescarga()
        {
            return Context.TiposDocumento.Where(d=> d.Id > 3).ToList();
        }

        public static List<Cliente> Clientes()
        {
            return Context.Clientes.ToList();
        }

        public static List<Lancamento> Lancamentos()
        {
            return Context.Lancamentos.Where(x=> !x.Fechamento.Fechado).ToList();
        }

        public static List<Fechamento> GetFechamentosPendentes()
        {
            return Context.Fechamentos.Where(x => !x.Fechado).ToList();
        }

        public static List<Adiantamento> GetListaAdiantamentos()
        {
            return Context.Adiantamentos.Where(x => x.Pendente).ToList();
        }
  
        public static int GetFechamentoNaData(int filial, DateTime Data)
        {
            return Context.Fechamentos
                    .Where(x => x.Filial_Id == filial && DbFunctions.TruncateTime(x.Data) == DbFunctions.TruncateTime(Data))
                    .Select(x => x.Id).FirstOrDefault();
        }
    }
}

