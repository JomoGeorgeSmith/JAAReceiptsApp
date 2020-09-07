namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LongId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReceiptItem", "ReceiptID", "dbo.Receipt");
            DropIndex("dbo.ReceiptItem", new[] { "ReceiptID" });
            DropPrimaryKey("dbo.Receipt");
            AlterColumn("dbo.Receipt", "ReceiptID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.ReceiptItem", "ReceiptID", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Receipt", "ReceiptID");
            CreateIndex("dbo.ReceiptItem", "ReceiptID");
            AddForeignKey("dbo.ReceiptItem", "ReceiptID", "dbo.Receipt", "ReceiptID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceiptItem", "ReceiptID", "dbo.Receipt");
            DropIndex("dbo.ReceiptItem", new[] { "ReceiptID" });
            DropPrimaryKey("dbo.Receipt");
            AlterColumn("dbo.ReceiptItem", "ReceiptID", c => c.Int(nullable: false));
            AlterColumn("dbo.Receipt", "ReceiptID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Receipt", "ReceiptID");
            CreateIndex("dbo.ReceiptItem", "ReceiptID");
            AddForeignKey("dbo.ReceiptItem", "ReceiptID", "dbo.Receipt", "ReceiptID", cascadeDelete: true);
        }
    }
}
