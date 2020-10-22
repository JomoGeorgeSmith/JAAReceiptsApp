namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankCode",
                c => new
                    {
                        BankCodeID = c.Int(nullable: false),
                        PaymentTypeID = c.Int(nullable: false),
                        BankCodeNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.BankCodeID);
            
            CreateTable(
                "dbo.CooperateClients",
                c => new
                    {
                        CooperateClientID = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CooperateClientID);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        CurrencyID = c.Int(nullable: false),
                        Description = c.String(),
                        CurrencyCode = c.String(),
                    })
                .PrimaryKey(t => t.CurrencyID);
            
            CreateTable(
                "dbo.DocumentType",
                c => new
                    {
                        DocumentTypeID = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DocumentTypeID);
            
            CreateTable(
                "dbo.IncomeAccountListing",
                c => new
                    {
                        IncomeAccountListingID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                        IncomeAccountNumber = c.Long(nullable: false),
                        CooperateClientID = c.Int(),
                    })
                .PrimaryKey(t => t.IncomeAccountListingID)
                .ForeignKey("dbo.CooperateClients", t => t.CooperateClientID)
                .Index(t => t.CooperateClientID);
            
            CreateTable(
                "dbo.PaymentType",
                c => new
                    {
                        PaymentTypeID = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PaymentTypeID);
            
            CreateTable(
                "dbo.Receipt",
                c => new
                    {
                        ReceiptID = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        PaymentTypeID = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IncomeAccountNumber = c.Long(nullable: false),
                        LineOfBusinessAccountNumber = c.String(),
                        DocumentTypeID = c.Int(nullable: false),
                        ReceiptCode = c.Long(nullable: false),
                        ReceivedFrom = c.String(),
                        AdditionalInfo = c.String(),
                        ChequeNumber = c.Long(),
                        LastFourDigits = c.Int(),
                        CustomerID = c.String(),
                        ReceiptNumber = c.String(),
                        CooperateClientID = c.Int(),
                        BankAccountNumber = c.Long(),
                    })
                .PrimaryKey(t => t.ReceiptID)
                .ForeignKey("dbo.CooperateClients", t => t.CooperateClientID)
                .ForeignKey("dbo.DocumentType", t => t.DocumentTypeID, cascadeDelete: true)
                .ForeignKey("dbo.PaymentType", t => t.PaymentTypeID, cascadeDelete: true)
                .Index(t => t.PaymentTypeID)
                .Index(t => t.DocumentTypeID)
                .Index(t => t.CooperateClientID);
            
            CreateTable(
                "dbo.ReceiptItem",
                c => new
                    {
                        RecieptItemID = c.Int(nullable: false, identity: true),
                        ReceiptID = c.Long(nullable: false),
                        ServiceID = c.Int(nullable: false),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(),
                        AdditionalInformation = c.String(),
                    })
                .PrimaryKey(t => t.RecieptItemID)
                .ForeignKey("dbo.Receipt", t => t.ReceiptID, cascadeDelete: true)
                .ForeignKey("dbo.Service", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.ReceiptID)
                .Index(t => t.ServiceID);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        ServiceID = c.Int(nullable: false),
                        RecieptTypeID = c.Int(nullable: false),
                        Description = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.Currency", t => t.CurrencyID, cascadeDelete: true)
                .Index(t => t.CurrencyID);
            
            CreateTable(
                "dbo.ReceiptType",
                c => new
                    {
                        ReceiptTypeID = c.Int(nullable: false),
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
                        ReceiptTypeCategoryID = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ReceiptTypeCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceiptType", "ReceiptTypeCategory_ReceiptTypeCategoryID", "dbo.ReceiptTypeCategory");
            DropForeignKey("dbo.ReceiptItem", "ServiceID", "dbo.Service");
            DropForeignKey("dbo.Service", "CurrencyID", "dbo.Currency");
            DropForeignKey("dbo.ReceiptItem", "ReceiptID", "dbo.Receipt");
            DropForeignKey("dbo.Receipt", "PaymentTypeID", "dbo.PaymentType");
            DropForeignKey("dbo.Receipt", "DocumentTypeID", "dbo.DocumentType");
            DropForeignKey("dbo.Receipt", "CooperateClientID", "dbo.CooperateClients");
            DropForeignKey("dbo.IncomeAccountListing", "CooperateClientID", "dbo.CooperateClients");
            DropIndex("dbo.ReceiptType", new[] { "ReceiptTypeCategory_ReceiptTypeCategoryID" });
            DropIndex("dbo.Service", new[] { "CurrencyID" });
            DropIndex("dbo.ReceiptItem", new[] { "ServiceID" });
            DropIndex("dbo.ReceiptItem", new[] { "ReceiptID" });
            DropIndex("dbo.Receipt", new[] { "CooperateClientID" });
            DropIndex("dbo.Receipt", new[] { "DocumentTypeID" });
            DropIndex("dbo.Receipt", new[] { "PaymentTypeID" });
            DropIndex("dbo.IncomeAccountListing", new[] { "CooperateClientID" });
            DropTable("dbo.ReceiptTypeCategory");
            DropTable("dbo.ReceiptType");
            DropTable("dbo.Service");
            DropTable("dbo.ReceiptItem");
            DropTable("dbo.Receipt");
            DropTable("dbo.PaymentType");
            DropTable("dbo.IncomeAccountListing");
            DropTable("dbo.DocumentType");
            DropTable("dbo.Currency");
            DropTable("dbo.CooperateClients");
            DropTable("dbo.BankCode");
        }
    }
}
