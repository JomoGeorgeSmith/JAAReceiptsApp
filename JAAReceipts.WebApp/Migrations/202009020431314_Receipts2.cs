namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Receipts2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReceiptItem", "Receipt_ReceiptID", "dbo.Receipt");
            DropIndex("dbo.ReceiptItem", new[] { "Receipt_ReceiptID" });
            RenameColumn(table: "dbo.ReceiptItem", name: "Receipt_ReceiptID", newName: "ReceiptID");
            AlterColumn("dbo.ReceiptItem", "ReceiptID", c => c.Int(nullable: false));
            CreateIndex("dbo.ReceiptItem", "ReceiptID");
            AddForeignKey("dbo.ReceiptItem", "ReceiptID", "dbo.Receipt", "ReceiptID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceiptItem", "ReceiptID", "dbo.Receipt");
            DropIndex("dbo.ReceiptItem", new[] { "ReceiptID" });
            AlterColumn("dbo.ReceiptItem", "ReceiptID", c => c.Int());
            RenameColumn(table: "dbo.ReceiptItem", name: "ReceiptID", newName: "Receipt_ReceiptID");
            CreateIndex("dbo.ReceiptItem", "Receipt_ReceiptID");
            AddForeignKey("dbo.ReceiptItem", "Receipt_ReceiptID", "dbo.Receipt", "ReceiptID");
        }
    }
}
