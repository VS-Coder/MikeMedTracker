using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikeMedTracker.Model
{
    public class TrackerContext : DbContext
    {
        public DbSet<Meds> Medications { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Logs> LogData { get; set; }

    }
}
