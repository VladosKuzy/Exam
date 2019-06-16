namespace MagazineServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vlad_0001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleName = c.String(nullable: false),
                        Theme = c.String(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuthorModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        WorkShop = c.String(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleModels", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthorModels", "ArticleId", "dbo.ArticleModels");
            DropIndex("dbo.AuthorModels", new[] { "ArticleId" });
            DropTable("dbo.AuthorModels");
            DropTable("dbo.ArticleModels");
        }
    }
}
