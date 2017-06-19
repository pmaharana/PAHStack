namespace PAHStack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class laffo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostModels", "ViewCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostModels", "ViewCount");
        }
    }
}
