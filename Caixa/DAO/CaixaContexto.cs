using Microsoft.EntityFrameworkCore;
using Database.Modelos;
using System;

namespace Database
{
    public class CaixaContexto : DbContext
    {
        public CaixaContexto(DbContextOptions<CaixaContexto> options) : base(options)
        {
        }

        public DbSet<Filial> Filial { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Filial>().HasKey(mbox => mbox.Id);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
                optionsBuilder.UseSqlite("Data Source=CaixaDB.sqlite"); 
        }
    }
}
