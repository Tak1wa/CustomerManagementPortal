namespace CustomerManagementPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerModels", "Comment");
        }
    }
}
