namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableChequeAndLastFourDigits : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Receipt", "ChequeNumber", c => c.Long());
            AlterColumn("dbo.Receipt", "LastFourDigits", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Receipt", "LastFourDigits", c => c.Int(nullable: false));
            AlterColumn("dbo.Receipt", "ChequeNumber", c => c.Long(nullable: false));
        }
    }
}
