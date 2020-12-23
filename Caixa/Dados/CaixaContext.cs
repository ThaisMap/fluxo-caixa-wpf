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
        public DbSet<Adiantamento> Adiantamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoCobranca> TiposCobranca { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)// => base.OnModelCreating(modelBuilder)
        { 
            modelBuilder.Entity<Cliente>().HasRequired(x => x.TipoCobranca).WithMany(x => x.Clientes).HasForeignKey(x => x.TipoCobranca_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<Fechamento>().HasRequired(x => x.Filial).WithMany(x => x.Fechamentos).HasForeignKey(x => x.Filial_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<Lancamento>().HasRequired(x => x.Filial).WithMany(x => x.Lancamentos).HasForeignKey(x => x.Filial_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<Lancamento>().HasRequired(x => x.Usuario).WithMany(x => x.Lancamentos).HasForeignKey(x => x.Usuario_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<Lancamento>().HasRequired(x => x.TipoDocumento).WithMany(x => x.Lancamentos).HasForeignKey(x => x.TipoDocumento_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<Lancamento>().HasRequired(x => x.Fechamento).WithMany(x => x.Lancamentos).HasForeignKey(x => x.Fechamento_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<Debito>().HasRequired(x => x.Cliente).WithMany(x => x.Debitos).HasForeignKey(x => x.Cliente_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<Debito>().HasRequired(x => x.TipoCobranca).WithMany(x => x.Debitos).HasForeignKey(x => x.TipoCobranca_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<Usuario>().HasRequired(x => x.Filial).WithMany(x => x.Usuarios).HasForeignKey(x => x.Filial_Id).WillCascadeOnDelete(false);
        }
    }
}
     
