namespace PAHStack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingFKback : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AnswerModels", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AnswerModels", "UserId");
            CreateIndex("dbo.AnswerModels", "PostId");
            AddForeignKey("dbo.AnswerModels", "PostId", "dbo.PostModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AnswerModels", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnswerModels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AnswerModels", "PostId", "dbo.PostModels");
            DropIndex("dbo.AnswerModels", new[] { "PostId" });
            DropIndex("dbo.AnswerModels", new[] { "UserId" });
            AlterColumn("dbo.AnswerModels", "UserId", c => c.String());
        }
    }
}
