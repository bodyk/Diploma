namespace Verbarium.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classifiers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        Classifier_Id = c.Int(),
                        Word_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classifiers", t => t.Classifier_Id)
                .ForeignKey("dbo.Words", t => t.Word_Id)
                .Index(t => t.Classifier_Id)
                .Index(t => t.Word_Id);
            
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        CurrentWord_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Words", t => t.CurrentWord_Id)
                .Index(t => t.CurrentWord_Id);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quotes", "CurrentWord_Id", "dbo.Words");
            DropForeignKey("dbo.Classifiers", "Word_Id", "dbo.Words");
            DropForeignKey("dbo.Classifiers", "Classifier_Id", "dbo.Classifiers");
            DropIndex("dbo.Quotes", new[] { "CurrentWord_Id" });
            DropIndex("dbo.Classifiers", new[] { "Word_Id" });
            DropIndex("dbo.Classifiers", new[] { "Classifier_Id" });
            DropTable("dbo.Words");
            DropTable("dbo.Quotes");
            DropTable("dbo.Classifiers");
        }
    }
}
