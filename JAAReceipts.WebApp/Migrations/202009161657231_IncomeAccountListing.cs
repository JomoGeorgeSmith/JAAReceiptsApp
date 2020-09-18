namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncomeAccountListing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IncomeAccountListing",
                c => new
                    {
                        IncomeAccountListingID = c.Int(nullable: false, identity: true),
                        ServiceID = c.Int(nullable: false),
                        IncomeAccountNumber = c.Long(nullable: false),
                        CooperateClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IncomeAccountListingID)
                .ForeignKey("dbo.CooperateClients", t => t.CooperateClientID, cascadeDelete: true)
                .Index(t => t.CooperateClientID);
            
            CreateIndex("dbo.Receipt", "CooperateClientID");
            AddForeignKey("dbo.Receipt", "CooperateClientID", "dbo.CooperateClients", "CooperateClientID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipt", "CooperateClientID", "dbo.CooperateClients");
            DropForeignKey("dbo.IncomeAccountListing", "CooperateClientID", "dbo.CooperateClients");
            DropIndex("dbo.Receipt", new[] { "CooperateClientID" });
            DropIndex("dbo.IncomeAccountListing", new[] { "CooperateClientID" });
            DropTable("dbo.IncomeAccountListing");
        }
    }
}
