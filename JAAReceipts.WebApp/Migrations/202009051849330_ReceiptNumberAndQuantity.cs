namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReceiptNumberAndQuantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipt", "ReceiptNumber", c => c.Guid(nullable: false));
            AddColumn("dbo.ReceiptItem", "Quantity", c => c.Int());
            AlterColumn("dbo.ReceiptItem", "Amount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReceiptItem", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ReceiptItem", "Quantity");
            DropColumn("dbo.Receipt", "ReceiptNumber");
        }
    }
}
