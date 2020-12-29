﻿using Dados.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Dados
{
    public static class Listas
    {
        private static CaixaContext Context = new CaixaContext();

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
            return Context.Lancamentos.ToList();
        }

        public static List<Fechamento> Fechamentos()
        {
            return Context.Fechamentos.ToList();
        }

        public static List<Adiantamento> GetListaAdiantamentos()
        {
            return Context.Adiantamentos.Where(x => x.Pendente).ToList();
        }
    }
}

