namespace Livraria.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                        Valor = c.Decimal(nullable: false, precision: 16, scale: 2),
                        Paginas = c.Int(nullable: false),
                        Estoque = c.Int(nullable: false),
                        GeneroId = c.Long(nullable: false),
                        AutorId = c.Long(nullable: false),
                        EditoraId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autor", t => t.AutorId)
                .ForeignKey("dbo.Editora", t => t.EditoraId)
                .ForeignKey("dbo.Genero", t => t.GeneroId)
                .Index(t => t.GeneroId)
                .Index(t => t.AutorId)
                .Index(t => t.EditoraId);
            
            CreateTable(
                "dbo.Editora",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livro", "GeneroId", "dbo.Genero");
            DropForeignKey("dbo.Livro", "EditoraId", "dbo.Editora");
            DropForeignKey("dbo.Livro", "AutorId", "dbo.Autor");
            DropIndex("dbo.Livro", new[] { "EditoraId" });
            DropIndex("dbo.Livro", new[] { "AutorId" });
            DropIndex("dbo.Livro", new[] { "GeneroId" });
            DropTable("dbo.Genero");
            DropTable("dbo.Editora");
            DropTable("dbo.Livro");
            DropTable("dbo.Autor");
        }
    }
}
