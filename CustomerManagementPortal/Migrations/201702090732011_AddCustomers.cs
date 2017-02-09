namespace CustomerManagementPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerHistoryModels",
                c => new
                    {
                        CustomerHistoryModelId = c.Int(nullable: false, identity: true),
                        VisitDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.CustomerHistoryModelId);
            
            CreateTable(
                "dbo.CustomerModels",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Tel = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerModels");
            DropTable("dbo.CustomerHistoryModels");
        }
    }
}
