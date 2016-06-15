namespace NewTrackerforMike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedArchivedstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meds", "Archived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meds", "Archived");
        }
    }
}
