namespace NewTrackerforMike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogChangeDoubleQtyTaken : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logs", "QtyTaken", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logs", "QtyTaken", c => c.Int(nullable: false));
        }
    }
}
