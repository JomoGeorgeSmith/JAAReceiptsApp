namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReceiptItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReceiptItem", "ReceiptID", "dbo.Receipt");
            DropIndex("dbo.ReceiptItem", new[] { "ReceiptID" });
            RenameColumn(table: "dbo.ReceiptItem", name: "ReceiptID", newName: "Receipt_ReceiptID");
            AlterColumn("dbo.ReceiptItem", "Receipt_ReceiptID", c => c.Int());
            CreateIndex("dbo.ReceiptItem", "ServiceID");
            CreateIndex("dbo.ReceiptItem", "Receipt_ReceiptID");
            AddForeignKey("dbo.ReceiptItem", "ServiceID", "dbo.Service", "ServiceID", cascadeDelete: true);
            AddForeignKey("dbo.ReceiptItem", "Receipt_ReceiptID", "dbo.Receipt", "ReceiptID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceiptItem", "Receipt_ReceiptID", "dbo.Receipt");
            DropForeignKey("dbo.ReceiptItem", "ServiceID", "dbo.Service");
            DropIndex("dbo.ReceiptItem", new[] { "Receipt_ReceiptID" });
            DropIndex("dbo.ReceiptItem", new[] { "ServiceID" });
            AlterColumn("dbo.ReceiptItem", "Receipt_ReceiptID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ReceiptItem", name: "Receipt_ReceiptID", newName: "ReceiptID");
            CreateIndex("dbo.ReceiptItem", "ReceiptID");
            AddForeignKey("dbo.ReceiptItem", "ReceiptID", "dbo.Receipt", "ReceiptID", cascadeDelete: true);
        }
    }
}
