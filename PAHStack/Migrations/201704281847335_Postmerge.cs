namespace PAHStack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Postmerge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnswerModels", "PostId", c => c.Int(nullable: false));
            AlterColumn("dbo.AnswerModels", "ApprovedAnswer", c => c.Boolean());
            CreateIndex("dbo.AnswerModels", "PostId");
            AddForeignKey("dbo.AnswerModels", "PostId", "dbo.PostModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnswerModels", "PostId", "dbo.PostModels");
            DropIndex("dbo.AnswerModels", new[] { "PostId" });
            AlterColumn("dbo.AnswerModels", "ApprovedAnswer", c => c.Boolean(nullable: false));
            DropColumn("dbo.AnswerModels", "PostId");
        }
    }
}
