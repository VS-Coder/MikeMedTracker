﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabbedMedTracker.Model
{
    public class Meds
    {
        [Key]
        public int MedsID { get; set; }

        [DisplayName("Med Name")]
        public string MedName { get; set; }

        [DisplayName("Med Strength")]
        public string MedStrength { get; set; }

        [DisplayName("Rx Number")]
        public string RxNumber { get; set; }

        [DisplayName("Refill Qty")]
        public int RefillQty { get; set; }

        [DisplayName("Refill DateTime")]
        public DateTime RefillDateTime { get; set; }

        [DisplayName("Directions")]
        public string Directions { get; set; }

        [DisplayName("Qty Per Dose")]
        public int QtyPerDose { get; set; }

        [DisplayName("Active Status")]
        public bool ActiveStatus { get; set; }

        [DisplayName("Med Count")]
        public int MedCount { get; set; }

        [DisplayName("Count Date")]
        public DateTime CountDate { get; set; }

        [DisplayName("Document Path")]
        public string DocPath { get; set; }
    }
}
