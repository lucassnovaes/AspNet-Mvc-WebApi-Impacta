namespace Impacta.AspNet.Mvc.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCelular : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Editora", "NumeroCelular", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Editora", "NumeroCelular");
        }
    }
}
