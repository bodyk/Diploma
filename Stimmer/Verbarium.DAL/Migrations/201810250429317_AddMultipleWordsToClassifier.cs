namespace Verbarium.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMultipleWordsToClassifier : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classifiers", "Word_Id", "dbo.Words");
            DropIndex("dbo.Classifiers", new[] { "Word_Id" });
            CreateTable(
                "dbo.WordClassifiers",
                c => new
                    {
                        Word_Id = c.Int(nullable: false),
                        Classifier_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Word_Id, t.Classifier_Id })
                .ForeignKey("dbo.Words", t => t.Word_Id, cascadeDelete: true)
                .ForeignKey("dbo.Classifiers", t => t.Classifier_Id, cascadeDelete: true)
                .Index(t => t.Word_Id)
                .Index(t => t.Classifier_Id);
            
            DropColumn("dbo.Classifiers", "Word_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classifiers", "Word_Id", c => c.Int());
            DropForeignKey("dbo.WordClassifiers", "Classifier_Id", "dbo.Classifiers");
            DropForeignKey("dbo.WordClassifiers", "Word_Id", "dbo.Words");
            DropIndex("dbo.WordClassifiers", new[] { "Classifier_Id" });
            DropIndex("dbo.WordClassifiers", new[] { "Word_Id" });
            DropTable("dbo.WordClassifiers");
            CreateIndex("dbo.Classifiers", "Word_Id");
            AddForeignKey("dbo.Classifiers", "Word_Id", "dbo.Words", "Id");
        }
    }
}
