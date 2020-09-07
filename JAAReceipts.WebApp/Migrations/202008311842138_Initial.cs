namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentType",
                c => new
                    {
                        DocumentTypeID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DocumentTypeID);
            
            CreateTable(
                "dbo.PaymentType",
                c => new
                    {
                        PaymentTypeID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PaymentTypeID);
            
            CreateTable(
                "dbo.Receipt",
                c => new
                    {
                        ReceiptID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BankAccountNumber = c.Long(nullable: false),
                        IncomeAccountNumber = c.Long(nullable: false),
                        LineOfBusinessAccountNumber = c.String(),
                        DocumentTypeID = c.Int(nullable: false),
                        ReceiptCode = c.Long(nullable: false),
                        ReceivedFrom = c.String(),
                        AdditionalInfo = c.String(),
                        PaymentType_PaymentTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ReceiptID)
                .ForeignKey("dbo.DocumentType", t => t.DocumentTypeID, cascadeDelete: true)
                .ForeignKey("dbo.PaymentType", t => t.PaymentType_PaymentTypeID)
                .Index(t => t.DocumentTypeID)
                .Index(t => t.PaymentType_PaymentTypeID);
            
            CreateTable(
                "dbo.ReceiptItem",
                c => new
                    {
                        RecieptItemID = c.Int(nullable: false, identity: true),
                        ReceiptID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RecieptItemID)
                .ForeignKey("dbo.Receipt", t => t.ReceiptID, cascadeDelete: true)
                .Index(t => t.ReceiptID);
            
            CreateTable(
                "dbo.ReceiptType",
                c => new
                    {
                        ReceiptTypeID = c.Int(nullable: false, identity: true),
                        RecieptTypeCategoryID = c.Int(nullable: false),
                        Description = c.String(),
                        ReceiptTypeCategory_ReceiptTypeCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ReceiptTypeID)
                .ForeignKey("dbo.ReceiptTypeCategory", t => t.ReceiptTypeCategory_ReceiptTypeCategoryID)
                .Index(t => t.ReceiptTypeCategory_ReceiptTypeCategoryID);
            
            CreateTable(
                "dbo.ReceiptTypeCategory",
                c => new
                    {
                        ReceiptTypeCategoryID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ReceiptTypeCategoryID);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        RecieptTypeID = c.Int(nullable: false),
                        Description = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ServiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceiptType", "ReceiptTypeCategory_ReceiptTypeCategoryID", "dbo.ReceiptTypeCategory");
            DropForeignKey("dbo.ReceiptItem", "ReceiptID", "dbo.Receipt");
            DropForeignKey("dbo.Receipt", "PaymentType_PaymentTypeID", "dbo.PaymentType");
            DropForeignKey("dbo.Receipt", "DocumentTypeID", "dbo.DocumentType");
            DropIndex("dbo.ReceiptType", new[] { "ReceiptTypeCategory_ReceiptTypeCategoryID" });
            DropIndex("dbo.ReceiptItem", new[] { "ReceiptID" });
            DropIndex("dbo.Receipt", new[] { "PaymentType_PaymentTypeID" });
            DropIndex("dbo.Receipt", new[] { "DocumentTypeID" });
            DropTable("dbo.Service");
            DropTable("dbo.ReceiptTypeCategory");
            DropTable("dbo.ReceiptType");
            DropTable("dbo.ReceiptItem");
            DropTable("dbo.Receipt");
            DropTable("dbo.PaymentType");
            DropTable("dbo.DocumentType");
        }
    }
}
