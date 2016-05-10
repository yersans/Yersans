namespace Yersans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQqPropertyToIdentityModelsAndAccountViewModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Qq", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Qq");
        }
    }
}
