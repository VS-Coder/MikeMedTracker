namespace NewTrackerforMike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newacc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logs", "LogMed_MedsID", "dbo.Meds");
            DropIndex("dbo.Logs", new[] { "LogMed_MedsID" });
            CreateTable(
                "dbo.PillCounts",
                c => new
                    {
                        PillCountID = c.Int(nullable: false, identity: true),
                        PillCountToDate = c.Int(nullable: false),
                        CountDateTime = c.DateTime(nullable: false),
                        CountQty = c.Int(nullable: false),
                        MedName = c.String(),
                    })
                .PrimaryKey(t => t.PillCountID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                    })
                .PrimaryKey(t => t.PatientID);
            
            DropColumn("dbo.Logs", "MedID");
            DropColumn("dbo.Logs", "LogMed_MedsID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logs", "LogMed_MedsID", c => c.Int());
            AddColumn("dbo.Logs", "MedID", c => c.Int(nullable: false));
            DropTable("dbo.Patients");
            DropTable("dbo.PillCounts");
            CreateIndex("dbo.Logs", "LogMed_MedsID");
            AddForeignKey("dbo.Logs", "LogMed_MedsID", "dbo.Meds", "MedsID");
        }
    }
}
