namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTypeID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Receipt", "PaymentType_PaymentTypeID", "dbo.PaymentType");
            DropIndex("dbo.Receipt", new[] { "PaymentType_PaymentTypeID" });
            RenameColumn(table: "dbo.Receipt", name: "PaymentType_PaymentTypeID", newName: "PaymentTypeID");
            AlterColumn("dbo.Receipt", "PaymentTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Receipt", "PaymentTypeID");
            AddForeignKey("dbo.Receipt", "PaymentTypeID", "dbo.PaymentType", "PaymentTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipt", "PaymentTypeID", "dbo.PaymentType");
            DropIndex("dbo.Receipt", new[] { "PaymentTypeID" });
            AlterColumn("dbo.Receipt", "PaymentTypeID", c => c.Int());
            RenameColumn(table: "dbo.Receipt", name: "PaymentTypeID", newName: "PaymentType_PaymentTypeID");
            CreateIndex("dbo.Receipt", "PaymentType_PaymentTypeID");
            AddForeignKey("dbo.Receipt", "PaymentType_PaymentTypeID", "dbo.PaymentType", "PaymentTypeID");
        }
    }
}
