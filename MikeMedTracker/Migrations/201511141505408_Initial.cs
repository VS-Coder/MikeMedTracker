namespace MikeMedTracker.Migrations
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
                        MedID = c.Int(nullable: false),
                        PatientID = c.Int(nullable: false),
                        Meds_MedsID = c.Int(),
                    })
                .PrimaryKey(t => t.LogsID)
                .ForeignKey("dbo.Meds", t => t.Meds_MedsID)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.PatientID)
                .Index(t => t.Meds_MedsID);
            
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
                        Patient_PatientID = c.Int(),
                    })
                .PrimaryKey(t => t.MedsID)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientID)
                .Index(t => t.Patient_PatientID);
            
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
            DropForeignKey("dbo.Meds", "Patient_PatientID", "dbo.Patients");
            DropForeignKey("dbo.Logs", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Logs", "Meds_MedsID", "dbo.Meds");
            DropIndex("dbo.Meds", new[] { "Patient_PatientID" });
            DropIndex("dbo.Logs", new[] { "Meds_MedsID" });
            DropIndex("dbo.Logs", new[] { "PatientID" });
            DropTable("dbo.Patients");
            DropTable("dbo.Meds");
            DropTable("dbo.Logs");
        }
    }
}
