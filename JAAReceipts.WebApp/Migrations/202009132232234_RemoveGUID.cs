namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGUID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Receipt", "ReceiptNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Receipt", "ReceiptNumber", c => c.Guid(nullable: false));
        }
    }
}
