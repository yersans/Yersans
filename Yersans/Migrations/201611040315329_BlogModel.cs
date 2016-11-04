namespace Yersans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        BlogCommentId = c.Int(nullable: false, identity: true),
                        BlogPostId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CommentText = c.String(nullable: false, maxLength: 4000),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogCommentId)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostId, cascadeDelete: true)
                .Index(t => t.BlogPostId);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        BlogPostId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Body = c.String(nullable: false),
                        BodyOverview = c.String(maxLength: 4000),
                        AllowComments = c.Boolean(nullable: false),
                        CommentCount = c.Int(nullable: false),
                        Tags = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogPostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogComments", "BlogPostId", "dbo.BlogPosts");
            DropIndex("dbo.BlogComments", new[] { "BlogPostId" });
            DropTable("dbo.BlogPosts");
            DropTable("dbo.BlogComments");
        }
    }
}
