namespace PAHStack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reverted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostVoteModels", "UpVotes", c => c.Int());
            AddColumn("dbo.PostVoteModels", "DownVotes", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostVoteModels", "DownVotes");
            DropColumn("dbo.PostVoteModels", "UpVotes");
        }
    }
}
