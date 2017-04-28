namespace PAHStack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingFKConstraints : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnswerModels", "PostId", "dbo.PostModels");
            DropForeignKey("dbo.AnswerModels", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AnswerModels", new[] { "UserId" });
            DropIndex("dbo.AnswerModels", new[] { "PostId" });
            AlterColumn("dbo.AnswerModels", "UserId", c => c.String());
            AlterColumn("dbo.AnswerModels", "PostId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AnswerModels", "PostId", c => c.Int());
            AlterColumn("dbo.AnswerModels", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AnswerModels", "PostId");
            CreateIndex("dbo.AnswerModels", "UserId");
            AddForeignKey("dbo.AnswerModels", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AnswerModels", "PostId", "dbo.PostModels", "Id");
        }
    }
}
