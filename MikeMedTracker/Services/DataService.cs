using MikeMedTracker.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MikeMedTracker.Services
{
    public class DataService : IDataService
    {

        private TrackerContext _db;

        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Mike's Med Tracker");
            callback(item, null);
        }


        public void GetAllMedications(Action<ObservableCollection<Meds>, Exception> callback)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    var _meds = from t in _db.Medications
                                select t;
                    if (_meds != null)
                    {
                        callback(new ObservableCollection<Meds>(_meds), null);
                    }
                }
            }
            catch(Exception e)
            {
                callback(null, e.InnerException);
            }
        }
        public void GetAllLogData(Action<ObservableCollection<Logs>, Exception> callback)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    var logs = from d in _db.LogData
                               select d;
                    if (logs != null)
                    {
                        callback(new ObservableCollection<Logs>(logs), null);
                    }
                }
            }
            catch(Exception e)
            {
                callback(null, e.InnerException);
            }
        }
        public Logs GetSingleLog(int id)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    var _log = _db.LogData.SingleOrDefault(t => t.LogsID == id);
                    return _log;
                }
            }
            catch(Exception e)
            {
                return null;
            }
            //return null;
        }
        public Meds GetSingleMed(int id)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    var _med = _db.Medications.SingleOrDefault(r => r.MedsID == id);
                    return _med;
                }
            }
            catch
            {
                return null;
            }
        }
        public Patient GetPatient(int id)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    var _pat = _db.Patients.SingleOrDefault(t => t.PatientID == id);
                    return _pat;
                }
            }
            catch
            {
                return null;
            }
        }

        public  bool AddLogData(Logs logData)
        {
            using (_db = new TrackerContext())
            {
                _db.Entry<Logs>(logData).State = System.Data.Entity.EntityState.Added;
                if (_db.SaveChanges() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool AddPatientData(Patient person)
        {
            using (_db = new TrackerContext())
            {
                _db.Entry<Patient>(person).State = System.Data.Entity.EntityState.Added;
                if (_db.SaveChanges() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                } 

            }
        }
        public bool AddMedData(Meds _meds)
        {
            using (_db = new TrackerContext())
            {
                _db.Entry<Meds>(_meds).State = System.Data.Entity.EntityState.Added;
                if (_db.SaveChanges() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}