namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cooperation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CooperateClients",
                c => new
                    {
                        CooperateClientID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CooperateClientID);
            
            AddColumn("dbo.Receipt", "CooperateClientID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receipt", "CooperateClientID");
            DropTable("dbo.CooperateClients");
        }
    }
}
