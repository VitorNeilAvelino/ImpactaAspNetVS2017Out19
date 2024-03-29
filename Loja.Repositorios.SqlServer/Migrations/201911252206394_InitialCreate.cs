namespace Loja.Repositorios.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                        Preco = c.Decimal(nullable: false, precision: 9, scale: 2),
                        Estoque = c.Int(nullable: false),
                        Categoria_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id)
                .Index(t => t.Categoria_Id);
            
            CreateTable(
                "dbo.ProdutoImagem",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false),
                        Bytes = c.Binary(),
                        ContentType = c.String(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Produto", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.ProdutoPedido",
                c => new
                    {
                        Produto_Id = c.Int(nullable: false),
                        Pedido_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produto_Id, t.Pedido_Id })
                .ForeignKey("dbo.Produto", t => t.Produto_Id)
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id)
                .Index(t => t.Produto_Id)
                .Index(t => t.Pedido_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoPedido", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.ProdutoPedido", "Produto_Id", "dbo.Produto");
            DropForeignKey("dbo.ProdutoImagem", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.Produto", "Categoria_Id", "dbo.Categoria");
            DropIndex("dbo.ProdutoPedido", new[] { "Pedido_Id" });
            DropIndex("dbo.ProdutoPedido", new[] { "Produto_Id" });
            DropIndex("dbo.ProdutoImagem", new[] { "ProdutoId" });
            DropIndex("dbo.Produto", new[] { "Categoria_Id" });
            DropTable("dbo.ProdutoPedido");
            DropTable("dbo.ProdutoImagem");
            DropTable("dbo.Produto");
            DropTable("dbo.Pedido");
            DropTable("dbo.Categoria");
        }
    }
}
