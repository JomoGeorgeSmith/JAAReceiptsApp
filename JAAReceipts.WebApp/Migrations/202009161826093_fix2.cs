namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Receipt", "BankAccountNumber", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Receipt", "BankAccountNumber", c => c.Long(nullable: false));
        }
    }
}
