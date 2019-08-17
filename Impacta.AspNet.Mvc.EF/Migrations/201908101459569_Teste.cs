namespace Impacta.AspNet.Mvc.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Editora",
                c => new
                    {
                        EditoraId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Cnpj = c.String(nullable: false),
                        Telefone = c.String(),
                        Endereco_Id = c.Int(),
                    })
                .PrimaryKey(t => t.EditoraId)
                .ForeignKey("dbo.Endereco", t => t.Endereco_Id)
                .Index(t => t.Endereco_Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                        Cep = c.String(),
                        Municipio = c.String(),
                        Uf = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Editora", "Endereco_Id", "dbo.Endereco");
            DropIndex("dbo.Editora", new[] { "Endereco_Id" });
            DropTable("dbo.Endereco");
            DropTable("dbo.Editora");
        }
    }
}
