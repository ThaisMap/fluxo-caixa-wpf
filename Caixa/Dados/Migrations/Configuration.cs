namespace Dados.Migrations
{
    using Dados.Modelos;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CaixaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CaixaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            Filial padrao = new Filial("Filial 1", 1000);
            Usuario master = new Usuario("Master", "mapster", "MASTER", true, padrao.Id, true);

            if (context.Filiais.Count() == 0)
                context.Filiais.AddOrUpdate(padrao);
            if (context.Usuarios.Count() == 0)
                context.Usuarios.AddOrUpdate(master);

            TipoDocumento suprimento = new TipoDocumento("Suprimento", true);
            TipoDocumento adiantamento = new TipoDocumento("Adiantamento", false);
            TipoDocumento estorno = new TipoDocumento("Estorno de adiantamento", true);
            context.TiposDocumento.AddOrUpdate(suprimento);
            context.TiposDocumento.AddOrUpdate(adiantamento);
            context.TiposDocumento.AddOrUpdate(estorno);
            context.SaveChanges();
        }
    }
}
