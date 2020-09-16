namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BankCode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankCode",
                c => new
                    {
                        BankCodeID = c.Int(nullable: false, identity: true),
                        PaymentTypeID = c.Int(nullable: false),
                        BankCodeNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.BankCodeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BankCode");
        }
    }
}
