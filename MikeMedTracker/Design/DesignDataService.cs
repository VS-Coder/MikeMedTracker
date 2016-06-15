using System;
using MikeMedTracker.Model;
using MikeMedTracker.Services;
using System.Collections.ObjectModel;

namespace MikeMedTracker.Design
{
    public class DesignDataService : IDataService
    {
        private IDataService _dataService;
        public DesignDataService(IDataService dataService)
        {
            _dataService = dataService;

        }
        public void GetData(Action<DataItem, Exception> callback)
        {
            var item = new DataItem("Mike's Med Tracker [design]");
            callback(item, null);
        }

        public void GetAllMedications(Action<ObservableCollection<Meds>, Exception> callback)
        {
        }
        public void GetAllLogData(Action<ObservableCollection<Logs>, Exception> callback)
        {
        }
        public Logs GetSingleLog(int id)
        {
            return null;
        }
        public Meds GetSingleMed(int id)
        {
            return null;
        }
        public Patient GetPatient(int id)
        {
            return null;
        }

        public bool AddLogData(Logs logData)
        {
            return false;
        }
        public bool AddPatientData(Patient person)
        {
            return false;
        }
        public bool AddMedData(Meds _meds)
        {
            return false;
        }


    }
}