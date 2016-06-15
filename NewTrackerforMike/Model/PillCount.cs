using System;
using System.ComponentModel.DataAnnotations;

namespace NewTrackerforMike.Model
{
    public class PillCount
    {
        [Key]
        public int PillCountID { get; set; }

        public int PillCountToDate { get; set; }
        public DateTime CountDateTime { get; set; }
        public int CountQty { get; set; }
        public string MedName { get; set; }
    }
}
