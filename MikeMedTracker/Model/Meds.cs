using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikeMedTracker.Model
{
    public class Meds
    {
        public int MedsID { get; set; }
        public string MedName { get; set; }
        public string MedStrength { get; set; }
        public string RxNumber { get; set; }
        public int RefillQty { get; set; }
        public DateTime RefillDateTime { get; set; }
        public string Directions { get; set; }

    }
}
