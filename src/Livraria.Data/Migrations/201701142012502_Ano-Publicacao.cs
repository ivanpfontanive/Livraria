namespace Livraria.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnoPublicacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livro", "Ano", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Livro", "Ano");
        }
    }
}
