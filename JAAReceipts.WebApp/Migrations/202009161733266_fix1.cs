namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IncomeAccountListing", "CooperateClientID", "dbo.CooperateClients");
            DropIndex("dbo.IncomeAccountListing", new[] { "CooperateClientID" });
            AlterColumn("dbo.IncomeAccountListing", "CooperateClientID", c => c.Int());
            CreateIndex("dbo.IncomeAccountListing", "CooperateClientID");
            AddForeignKey("dbo.IncomeAccountListing", "CooperateClientID", "dbo.CooperateClients", "CooperateClientID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IncomeAccountListing", "CooperateClientID", "dbo.CooperateClients");
            DropIndex("dbo.IncomeAccountListing", new[] { "CooperateClientID" });
            AlterColumn("dbo.IncomeAccountListing", "CooperateClientID", c => c.Int(nullable: false));
            CreateIndex("dbo.IncomeAccountListing", "CooperateClientID");
            AddForeignKey("dbo.IncomeAccountListing", "CooperateClientID", "dbo.CooperateClients", "CooperateClientID", cascadeDelete: true);
        }
    }
}
