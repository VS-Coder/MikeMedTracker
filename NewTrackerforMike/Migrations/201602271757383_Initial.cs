namespace NewTrackerforMike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogsID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        LogNotes = c.String(),
                        MedName = c.String(),
                        QtyTaken = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LogsID);
            
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
                "dbo.Meds",
                c => new
                    {
                        MedsID = c.Int(nullable: false, identity: true),
                        MedName = c.String(),
                        MedStrength = c.String(),
                        RxNumber = c.String(),
                        RefillQty = c.Int(nullable: false),
                        RefillDateTime = c.DateTime(nullable: false),
                        Directions = c.String(),
                        QtyPerDose = c.Int(nullable: false),
                        ActiveStatus = c.Boolean(nullable: false),
                        MedCount = c.Int(nullable: false),
                        CountDate = c.DateTime(nullable: false),
                        DocPath = c.String(),
                    })
                .PrimaryKey(t => t.MedsID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                    })
                .PrimaryKey(t => t.PatientID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
            DropTable("dbo.Meds");
            DropTable("dbo.PillCounts");
            DropTable("dbo.Logs");
        }
    }
}
