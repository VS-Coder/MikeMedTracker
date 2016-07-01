namespace NewTrackerforMike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MedIdAddedToLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "MedID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "MedID");
        }
    }
}
