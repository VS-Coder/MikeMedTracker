namespace NewTrackerforMike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StrengthAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "Strength", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "Strength");
        }
    }
}
