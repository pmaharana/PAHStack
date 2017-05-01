namespace PAHStack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updowndeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PostVoteModels", "UpVotes");
            DropColumn("dbo.PostVoteModels", "DownVotes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostVoteModels", "DownVotes", c => c.Int());
            AddColumn("dbo.PostVoteModels", "UpVotes", c => c.Int());
        }
    }
}
