namespace NewTrackerforMike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RollbackChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Meds", "DoseInterval", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Meds", "DoseInterval", c => c.Double(nullable: false));
        }
    }
}
