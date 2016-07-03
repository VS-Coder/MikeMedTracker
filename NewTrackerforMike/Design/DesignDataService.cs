using System;
using NewTrackerforMike.Model;
using NewTrackerforMike.Services;
using System.Linq;
using System.Collections.ObjectModel;

namespace NewTrackerforMike.Design
{
    public class DesignDataService : IDataService
    {
        public DesignDataService()
        {
            GetData(
                (title, error) =>
                {
                    Title = title.Title;
                });
        }

        public string Title { get; set; }

        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MedTracker [design]");
            callback(item, null);
        }

        public void GetLogMainViewerTitle(Action<DataItem, Exception> callback)
        {
            var title = new DataItem("Main Log Viewer");
            callback(title, null);
        }

        public void GetLogAddViewerTitle(Action<DataItem, Exception> callback)
        {
            var title = new DataItem("LogAddView");
            callback(title, null);
        }

        public void GetLogEditorTitle(Action<DataItem, Exception> callback)
        {
            var title = new DataItem("Log Editor");
            callback(title, null);
        }

        public void GetMedAddTitle(Action<DataItem, Exception> callback)
        {
            var title = new DataItem("Add Medication");
            callback(title, null);
        }

        public void GetMedViewerTitle(Action<DataItem, Exception> callback)
        {
            var title = new DataItem("Medication Viewer");
            callback(title, null);
        }

        public void GetMedEditorTitle(Action<DataItem, Exception> callback)
        {

        }


        private TrackerContext _db;
        public void GetLastLogSnapshot(Action<ObservableCollection<Logs>, Exception> callback)
        {
            using (_db = new TrackerContext())
            {
                var tmp = _db.LogData.OrderByDescending(f => f.LogsID);
                var dateoflastlog = tmp.Select(r => r.TimeStamp).FirstOrDefault();
                var snapshotlist = _db.LogData.Where(g => g.TimeStamp == dateoflastlog);
                var list = new ObservableCollection<Logs>(snapshotlist);
                callback(list, null);
            }
        }

        public bool LogAdd(Logs _log, int medId)
        {
            return false;
        }
        public void GetTotalLogCountForMainForm(Action<PillCount, Exception> callback)
        {
            using (_db = new TrackerContext())
            {
                //    var _count = _db.;
                //    callback(_count, null);
                return;
            }
        }
        public bool EditLog(Logs _log)
        {
            return false;
        }
        public void LogsAll(Action<ObservableCollection<Logs>, Exception> callback)
        {
            callback(null, null);
        }

        public bool MedsAdd(Meds _med)
        {
            return false;
        }
        public bool EditMeds(Meds _med)
        {
            return false;
        }
        public void MedsAllActive(Action<ObservableCollection<Meds>, Exception> callback)
        {
            callback(null, null);
        }

        public void MedsAll(Action<ObservableCollection<Meds>, Exception> callback)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    var tmp = _db.Medications.ToList();
                    callback(new ObservableCollection<Meds>(tmp), null);
                }
            }
            catch (Exception e)
            {
                callback(null, e.InnerException);
            }
        }


        public bool DeleteLog(Logs _log)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    var item = _db.LogData.Remove(_log);
                    _db.Entry<Logs>(_log).State = System.Data.Entity.EntityState.Deleted;
                    _db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool LogsExport(ObservableCollection<Logs> _logList)
        {
            try
            {
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteMedication(Meds _med)
        {
            return false;
        }
        public void GetTotalLogCount(Action<int, Exception> callback)
        {

        }

        public bool MedsExport(ObservableCollection<Meds> _meds)
        {
            return false;
        }
        public ObservableCollection<Experience> GetOptions()
        {
            Experience tmp;
            var option = new ObservableCollection<Experience>();

            tmp = new Experience("Add New Log");
            option.Add(tmp);
            tmp = new Experience("Edit Selection");
            option.Add(tmp);
            tmp = new Experience("Delete Selection");
            option.Add(tmp);
            //tmp = new Experience("Close Window");
            //option.Add(tmp);
            tmp = new Experience("Export Log Data");
            option.Add(tmp);

            return option;
        }

        //public void GetTotalLogCountForMainForm()
        //{
        //    return;
        //}

        public double CalculateTotalPillUsage(string callingFunc, double qtyUsed, int medId, int _logId)
        {
            try
            {
                switch (callingFunc)
                {
                    case "LogAdd":
                        //var cnt = currentCount - qtyUsed;
                        break;
                    case "EditLog":
                        //cnt = currentCount - qtyUsed;
                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }
            return 0;
        }

        public void MedWarnings(Action<ObservableCollection<Meds>, Exception> callback)
        {
            callback(null, null);
        }


    }
}