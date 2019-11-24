namespace Loja.Repositorios.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarPedidoEntregue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "Entregue", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedido", "Entregue");
        }
    }
}
