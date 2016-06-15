using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTrackerforMike.Model
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        [DisplayName("Patient Name")]
        public string PatientName { get; set; }

        //public virtual List<Meds> PatientMeds { get; set; }
        //public virtual List<Logs> PatientLogs { get; set; }
    }
}
