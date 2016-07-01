using NewTrackerforMike.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTrackerforMike.General_Methods
{
    public class MedRecon
    {
        private IDataService _dataService;
        public MedRecon(IDataService dataService)
        {
            _dataService = dataService;
        }

        public void FirstTask()
        {

        }
    }
}
