using Dados.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class CaixaContext : DbContext 
    {  
        public CaixaContext() :
            base("CaixaConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CaixaContext, Migrations.Configuration>());
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Fechamento> Fechamentos { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Debito> Debitos { get; set; }
        public DbSet<Suprimento> Suprimentos { get; set; }
        public DbSet<Adiantamento> Adiantamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoCobranca> TiposCobranca { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }


      

    }
}
