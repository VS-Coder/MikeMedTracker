using MikeMedTracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MikeMedTracker.Services
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
        void GetAllMedications(Action<ObservableCollection<Meds>, Exception> callback);
        void GetAllLogData(Action<ObservableCollection<Logs>, Exception> callback);
        Logs GetSingleLog(int id);
        Meds GetSingleMed(int id);
        Patient GetPatient(int id);
        bool AddLogData(Logs logData);
        bool AddPatientData(Patient person);
        bool AddMedData(Meds _meds);
    }
}
