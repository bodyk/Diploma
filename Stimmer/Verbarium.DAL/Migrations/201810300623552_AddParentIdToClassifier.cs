namespace Verbarium.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParentIdToClassifier : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Classifiers", name: "Classifier_Id", newName: "ParentId");
            RenameIndex(table: "dbo.Classifiers", name: "IX_Classifier_Id", newName: "IX_ParentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Classifiers", name: "IX_ParentId", newName: "IX_Classifier_Id");
            RenameColumn(table: "dbo.Classifiers", name: "ParentId", newName: "Classifier_Id");
        }
    }
}
