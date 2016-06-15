using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikeMedTracker.Model
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }

        public virtual List<Meds> PatientMeds { get; set; }
        public virtual List<Logs> PatientLogs { get; set; }
    }
}
