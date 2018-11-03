namespace Verbarium.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreationDateComputed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Words", "CreationTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Words", "CreationTime", c => c.DateTime(nullable: false));
        }
    }
}
