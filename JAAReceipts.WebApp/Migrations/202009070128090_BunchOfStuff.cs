namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BunchOfStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceiptItem", "AdditionalInformation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceiptItem", "AdditionalInformation");
        }
    }
}
