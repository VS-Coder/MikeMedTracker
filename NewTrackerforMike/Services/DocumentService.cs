using NewTrackerforMike.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTrackerforMike.Services
{
    public class DocumentService : IDocumentService
    {
        private TrackerContext _db;
        public string GetImagePath(Meds _med)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    var _path = _db.Medications.Single( r => r.MedsID == _med.MedsID).DocPath.ToString();
                    return _path.ToString();
                }
            }
            catch(Exception e)
            {
                return e.InnerException.ToString();
            }
            //return String.Empty;
        }
    }
}
