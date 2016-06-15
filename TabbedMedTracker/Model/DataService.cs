using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace TabbedMedTracker.Model
{
    public class DataService : IDataService
    {

        private TabbedTrackerContext _db;
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }
        public void GetExperiences(Action<ObservableCollection<Experiences>, Exception> callback)
        {
            var tmp = new[]
            {
                Experiences.Main,
                Experiences.AddLog,
                Experiences.AddMed,
                Experiences.EditLog,
                Experiences.EditMed,
                Experiences.ViewAllLogs,
                Experiences.ViewAllMeds
            };
            var exps = new ObservableCollection<Experiences>(tmp);
            callback(exps, null);
        }

        public void GetLogList(Action<ObservableCollection<Logs>, Exception> callback)
        {
            try
            {
                using (_db = new TabbedTrackerContext())
                {
                    var listItems = _db.LogData.ToList();
                    callback(new ObservableCollection<Logs>(listItems), null);
                }
            }
            catch(Exception e)
            {
                callback(null, e.InnerException);
            }
        }
    }
}