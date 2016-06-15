using NewTrackerforMike.Model;
using NewTrackerforMike.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTrackerforMike.General_Methods
{
    public class LogCountTotlals
    {
        private IDataService _dataService;
        private TrackerContext _db;
                
        public LogCountTotlals(IDataService dataService)
        {
            _dataService = dataService;
        }
        public int GetLogTotal()
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    var temp = _db.LogData.Count();
                    return temp;
                };
            }
            catch(Exception e)
            {
                return 0;
               //return
            }
        }
    }
}
