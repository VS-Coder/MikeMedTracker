using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikeMedTracker.Model
{
    public class Logs
    {
        public int LogsID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string LogNotes { get; set; }
        public string MedName { get; set; }
        public int QtyTaken { get; set; }

        public int MedID { get; set; }
        public virtual Meds Meds { get; set; }

        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
