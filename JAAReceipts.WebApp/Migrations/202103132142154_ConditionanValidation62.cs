namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConditionanValidation62 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Receipt", "LastFourDigits", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Receipt", "LastFourDigits", c => c.Int(nullable: false));
        }
    }
}
