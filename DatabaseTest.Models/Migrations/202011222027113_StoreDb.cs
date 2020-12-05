namespace DatabaseTest.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        BuyerName = c.String(),
                        OrderTime = c.DateTime(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductOrder",
                c => new
                    {
                        Product_ProductId = c.Guid(nullable: false),
                        Order_OrderId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Order_OrderId })
                .ForeignKey("dbo.Product", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.Order_OrderId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Order_OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrder", "Order_OrderId", "dbo.Order");
            DropForeignKey("dbo.ProductOrder", "Product_ProductId", "dbo.Product");
            DropIndex("dbo.ProductOrder", new[] { "Order_OrderId" });
            DropIndex("dbo.ProductOrder", new[] { "Product_ProductId" });
            DropTable("dbo.ProductOrder");
            DropTable("dbo.Product");
            DropTable("dbo.Order");
        }
    }
}
