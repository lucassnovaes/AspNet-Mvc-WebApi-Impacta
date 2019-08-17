namespace Impacta.AspNet.Mvc.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Impacta.AspNet.Mvc.EF.RealBooksContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Impacta.AspNet.Mvc.EF.RealBooksContexto";
        }

        protected override void Seed(Impacta.AspNet.Mvc.EF.RealBooksContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
