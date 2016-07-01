namespace NewTrackerforMike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MedIntChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Meds", "QtyPerDose", c => c.Double(nullable: false));
            AlterColumn("dbo.Meds", "MedCount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Meds", "MedCount", c => c.Int(nullable: false));
            AlterColumn("dbo.Meds", "QtyPerDose", c => c.Int(nullable: false));
        }
    }
}
