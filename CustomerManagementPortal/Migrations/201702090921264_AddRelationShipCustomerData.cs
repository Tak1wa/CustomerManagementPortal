namespace CustomerManagementPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationShipCustomerData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerHistoryModels", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerHistoryModels", "CustomerId");
            AddForeignKey("dbo.CustomerHistoryModels", "CustomerId", "dbo.CustomerModels", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerHistoryModels", "CustomerId", "dbo.CustomerModels");
            DropIndex("dbo.CustomerHistoryModels", new[] { "CustomerId" });
            DropColumn("dbo.CustomerHistoryModels", "CustomerId");
        }
    }
}
