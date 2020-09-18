namespace JAAReceipts.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Receipt", "DocumentTypeID", "dbo.DocumentType");
            DropPrimaryKey("dbo.DocumentType");
            AlterColumn("dbo.DocumentType", "DocumentTypeID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.DocumentType", "DocumentTypeID");
            AddForeignKey("dbo.Receipt", "DocumentTypeID", "dbo.DocumentType", "DocumentTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipt", "DocumentTypeID", "dbo.DocumentType");
            DropPrimaryKey("dbo.DocumentType");
            AlterColumn("dbo.DocumentType", "DocumentTypeID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DocumentType", "DocumentTypeID");
            AddForeignKey("dbo.Receipt", "DocumentTypeID", "dbo.DocumentType", "DocumentTypeID", cascadeDelete: true);
        }
    }
}
