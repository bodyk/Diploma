namespace Verbarium.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteNewField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotes", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotes", "Author");
        }
    }
}
