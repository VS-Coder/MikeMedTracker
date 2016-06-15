namespace NewTrackerforMike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoseInterval : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meds", "DoseInterval", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meds", "DoseInterval");
        }
    }
}
