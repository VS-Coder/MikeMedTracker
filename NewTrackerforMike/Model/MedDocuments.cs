using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTrackerforMike.Model
{
    public class MedDocuments
    {
        [Key]
        public int MedDocumentID { get; set; }
        public string DocName { get; set; }
        public string DocPath { get; set; }
    }
}
