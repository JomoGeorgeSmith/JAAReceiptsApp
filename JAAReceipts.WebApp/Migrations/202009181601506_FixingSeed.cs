namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingSeed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IncomeAccountListing", "CooperateClientID", "dbo.CooperateClients");
            DropForeignKey("dbo.Receipt", "CooperateClientID", "dbo.CooperateClients");
            DropForeignKey("dbo.Receipt", "PaymentTypeID", "dbo.PaymentType");
            DropForeignKey("dbo.ReceiptItem", "ServiceID", "dbo.Service");
            DropForeignKey("dbo.ReceiptType", "ReceiptTypeCategory_ReceiptTypeCategoryID", "dbo.ReceiptTypeCategory");
            DropPrimaryKey("dbo.BankCode");
            DropPrimaryKey("dbo.CooperateClients");
            DropPrimaryKey("dbo.IncomeAccountListing");
            DropPrimaryKey("dbo.PaymentType");
            DropPrimaryKey("dbo.Service");
            DropPrimaryKey("dbo.ReceiptType");
            DropPrimaryKey("dbo.ReceiptTypeCategory");
            AlterColumn("dbo.BankCode", "BankCodeID", c => c.Int(nullable: false));
            AlterColumn("dbo.CooperateClients", "CooperateClientID", c => c.Int(nullable: false));
            AlterColumn("dbo.IncomeAccountListing", "IncomeAccountListingID", c => c.Int(nullable: false));
            AlterColumn("dbo.PaymentType", "PaymentTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Service", "ServiceID", c => c.Int(nullable: false));
            AlterColumn("dbo.ReceiptType", "ReceiptTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.ReceiptTypeCategory", "ReceiptTypeCategoryID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.BankCode", "BankCodeID");
            AddPrimaryKey("dbo.CooperateClients", "CooperateClientID");
            AddPrimaryKey("dbo.IncomeAccountListing", "IncomeAccountListingID");
            AddPrimaryKey("dbo.PaymentType", "PaymentTypeID");
            AddPrimaryKey("dbo.Service", "ServiceID");
            AddPrimaryKey("dbo.ReceiptType", "ReceiptTypeID");
            AddPrimaryKey("dbo.ReceiptTypeCategory", "ReceiptTypeCategoryID");
            AddForeignKey("dbo.IncomeAccountListing", "CooperateClientID", "dbo.CooperateClients", "CooperateClientID");
            AddForeignKey("dbo.Receipt", "CooperateClientID", "dbo.CooperateClients", "CooperateClientID");
            AddForeignKey("dbo.Receipt", "PaymentTypeID", "dbo.PaymentType", "PaymentTypeID", cascadeDelete: true);
            AddForeignKey("dbo.ReceiptItem", "ServiceID", "dbo.Service", "ServiceID", cascadeDelete: true);
            AddForeignKey("dbo.ReceiptType", "ReceiptTypeCategory_ReceiptTypeCategoryID", "dbo.ReceiptTypeCategory", "ReceiptTypeCategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceiptType", "ReceiptTypeCategory_ReceiptTypeCategoryID", "dbo.ReceiptTypeCategory");
            DropForeignKey("dbo.ReceiptItem", "ServiceID", "dbo.Service");
            DropForeignKey("dbo.Receipt", "PaymentTypeID", "dbo.PaymentType");
            DropForeignKey("dbo.Receipt", "CooperateClientID", "dbo.CooperateClients");
            DropForeignKey("dbo.IncomeAccountListing", "CooperateClientID", "dbo.CooperateClients");
            DropPrimaryKey("dbo.ReceiptTypeCategory");
            DropPrimaryKey("dbo.ReceiptType");
            DropPrimaryKey("dbo.Service");
            DropPrimaryKey("dbo.PaymentType");
            DropPrimaryKey("dbo.IncomeAccountListing");
            DropPrimaryKey("dbo.CooperateClients");
            DropPrimaryKey("dbo.BankCode");
            AlterColumn("dbo.ReceiptTypeCategory", "ReceiptTypeCategoryID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ReceiptType", "ReceiptTypeID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Service", "ServiceID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PaymentType", "PaymentTypeID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.IncomeAccountListing", "IncomeAccountListingID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CooperateClients", "CooperateClientID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.BankCode", "BankCodeID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ReceiptTypeCategory", "ReceiptTypeCategoryID");
            AddPrimaryKey("dbo.ReceiptType", "ReceiptTypeID");
            AddPrimaryKey("dbo.Service", "ServiceID");
            AddPrimaryKey("dbo.PaymentType", "PaymentTypeID");
            AddPrimaryKey("dbo.IncomeAccountListing", "IncomeAccountListingID");
            AddPrimaryKey("dbo.CooperateClients", "CooperateClientID");
            AddPrimaryKey("dbo.BankCode", "BankCodeID");
            AddForeignKey("dbo.ReceiptType", "ReceiptTypeCategory_ReceiptTypeCategoryID", "dbo.ReceiptTypeCategory", "ReceiptTypeCategoryID");
            AddForeignKey("dbo.ReceiptItem", "ServiceID", "dbo.Service", "ServiceID", cascadeDelete: true);
            AddForeignKey("dbo.Receipt", "PaymentTypeID", "dbo.PaymentType", "PaymentTypeID", cascadeDelete: true);
            AddForeignKey("dbo.Receipt", "CooperateClientID", "dbo.CooperateClients", "CooperateClientID");
            AddForeignKey("dbo.IncomeAccountListing", "CooperateClientID", "dbo.CooperateClients", "CooperateClientID");
        }
    }
}
