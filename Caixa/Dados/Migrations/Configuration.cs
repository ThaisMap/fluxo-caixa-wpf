namespace Dados.Migrations
{
    using Dados.Modelos;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dados.CaixaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Dados.CaixaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            Filial padrao = new Filial("Filial 1", 1000) { Id = 1 };
            Usuario master = new Usuario("Master", "mapster", "MASTER", true, padrao) { Id = 1 };
            context.Filiais.AddOrUpdate(padrao);
            context.Usuarios.AddOrUpdate(master);
            context.SaveChanges();
        }
    }
}
