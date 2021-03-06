﻿using TabbedMedTracker.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabbedMedTracker.Model
{
    public class TabbedTrackerContext : DbContext
    {
        public DbSet<Meds> Medications { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Logs> LogData { get; set; }
        //public DbSet<MedDocuments> Documents { get; set; }
        //public DbSet<PillCount> MedCount { get; set; }

    }
}
