namespace PAHStack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesFKandPK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        ApprovedAnswer = c.Boolean(nullable: false),
                        DateAnswered = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AnswerVoteModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnswerVoteValue = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnswerModels", t => t.AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "dbo.PostModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        Img = c.String(),
                        Starred = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PostVoteModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostVoteValue = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostModels", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.TagModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostVoteModels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostVoteModels", "PostId", "dbo.PostModels");
            DropForeignKey("dbo.PostModels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AnswerVoteModels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AnswerVoteModels", "AnswerId", "dbo.AnswerModels");
            DropForeignKey("dbo.AnswerModels", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.PostVoteModels", new[] { "PostId" });
            DropIndex("dbo.PostVoteModels", new[] { "UserId" });
            DropIndex("dbo.PostModels", new[] { "UserId" });
            DropIndex("dbo.AnswerVoteModels", new[] { "AnswerId" });
            DropIndex("dbo.AnswerVoteModels", new[] { "UserId" });
            DropIndex("dbo.AnswerModels", new[] { "UserId" });
            DropTable("dbo.TagModels");
            DropTable("dbo.PostVoteModels");
            DropTable("dbo.PostModels");
            DropTable("dbo.AnswerVoteModels");
            DropTable("dbo.AnswerModels");
        }
    }
}
