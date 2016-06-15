using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabbedMedTracker.Model
{
    public class Logs
    {
        [Key]
        public int LogsID { get; set; }

        [DisplayName("Time Stamp")]
        public DateTime TimeStamp { get; set; }

        [DisplayName("Log Notes")]
        public string LogNotes { get; set; }

        [DisplayName("Med Name")]
        public string MedName { get; set; }

        [DisplayName("Qty Taken")]
        public int QtyTaken { get; set; }

        //public int MedID { get; set; }
        //public virtual Meds Meds { get; set; }

        //public int PatientID { get; set; }
        //public virtual Patient Patient { get; set; }
    }
}
