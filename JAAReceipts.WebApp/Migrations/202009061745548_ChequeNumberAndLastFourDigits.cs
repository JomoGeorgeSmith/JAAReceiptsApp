namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChequeNumberAndLastFourDigits : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipt", "ChequeNumber", c => c.Long(nullable: false));
            AddColumn("dbo.Receipt", "LastFourDigits", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receipt", "LastFourDigits");
            DropColumn("dbo.Receipt", "ChequeNumber");
        }
    }
}
