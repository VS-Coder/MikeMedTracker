﻿using NewTrackerforMike.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NewTrackerforMike.Services
{
    public class DataService : IDataService
    {

        #region PageTitles
        public void GetData(Action<DataItem, Exception> callback)
        {
            var item = new DataItem("Medication Summary");
            callback(item, null);
        }

        public void GetLogMainViewerTitle(Action<DataItem, Exception> callback)
        {
            var title = new DataItem("Main Log Viewer");
            callback(title, null);
        }

        public void GetLogAddViewerTitle(Action<DataItem, Exception> callback)
        {
            var title = new DataItem("Log Add View");
            callback(title, null);
        }

        public void GetLogEditorTitle(Action<DataItem, Exception> callback)
        {
            var title = new DataItem("Log Editor");
            callback(title, null);
        }

        public void GetMedEditorTitle(Action<DataItem, Exception> callback)
        {
            var title = new DataItem("Med Editor");
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
        //
        //

        #endregion

        #region Main Functions

        private TrackerContext _db;

        public void GetLastLogSnapshot(Action<ObservableCollection<Logs>, Exception> callback)
        {
            using (_db = new TrackerContext())
            {
                try
                {
                    var tmp = _db.LogData.OrderByDescending(t => t.TimeStamp).ToList();
                    var dateoflastlog = tmp.Select(r => r.TimeStamp).First().ToShortDateString();
                    var snapshotlist = tmp.Where(g => g.TimeStamp.ToShortDateString() == dateoflastlog).ToList();
                    var list = new ObservableCollection<Logs>(snapshotlist);
                    callback(list, null);
                }
                catch
                {
                    callback(new ObservableCollection<Logs>(), null);
                }

            }
        }


        public bool LogAdd(Logs _log)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    var qtyLoginfo = _log.QtyTaken;
                    //var qtyMedInfo = _db.Medications.SingleOrDefault(t => t.MedCount);
                    _log.TimeStamp = DateTime.Now;
                    _db.Entry<Logs>(_log).State = System.Data.Entity.EntityState.Added;
                    _db.SaveChanges();
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        //public int GetCurrentPillTotals(int LogDose, int CountperDate)
        //{

        //    return 0;
        //}
        public bool EditLog(Logs _log)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    _db.Entry<Logs>(_log).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public void LogsAll(Action<ObservableCollection<Logs>, Exception> callback)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    var items = _db.LogData.OrderByDescending(c => c.LogsID).ToList() ;
                    callback(new ObservableCollection<Logs>(items), null);
                    return;
                }
            }
            catch(Exception e)
            {
                callback(null, e.InnerException);
                return;
            }
        }

        public bool MedsAdd(Meds _med)
        {
            try
            {
                using (_db = new TrackerContext())
                {

                    _db.Entry<Meds>(_med).State = System.Data.Entity.EntityState.Modified;
                    _db.Entry<Meds>(_med).State = System.Data.Entity.EntityState.Added;
                    _db.SaveChanges();

                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool EditMeds(Meds _med)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    _db.Entry<Meds>(_med).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public void MedsAllActive(Action<ObservableCollection<Meds>, Exception> callback)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    var _col = _db.Medications.Where(c => c.ActiveStatus == true).OrderBy(r => r.MedName).ToList();
                    callback(new ObservableCollection<Meds>(_col), null);
                    return;
                }
            }
            catch(Exception e)
            {
                callback(null, e.InnerException);
                return;
            }
        }

        public void MedsAll(Action<ObservableCollection<Meds>, Exception> callback)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    var tmp = _db.Medications.OrderBy(v => v.MedName).ToList();
                    callback(new ObservableCollection<Meds>(tmp), null);
                }
            }
            catch(Exception e)
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
                    // Add Qty taken from the log back into Pill Count.
                    //

                    var selectedMed = _db.Medications.Where(e => e.MedName == _log.MedName);
                    //var currentcount = _log.QtyTaken;
                    //var newCount = currentcount;
                    //var resultCount = (currentcount + _log.QtyTaken);
                    //_log.QtyTaken = resultCount;


                    //

                    _db.Entry<Logs>(_log).State = System.Data.Entity.EntityState.Modified;
                    var item = _db.LogData.Remove(_log);
                    _db.Entry<Logs>(_log).State = System.Data.Entity.EntityState.Deleted;
                    _db.SaveChanges();
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// LogsExport is a function that allows the user to 
        ///  export the database information easily. Then the user
        ///   can attach this file to an email or print out for 
        ///   review by the medical team. This method returns 
        ///   a bool to signify success either True or False.
        ///   This method expects to receive the export listing
        ///   from the calling method to be added to the export file.
        /// </summary>
        /// <returns>bool</returns>

        public bool LogsExport(ObservableCollection<Logs> _logList)
        {
            try
            {
                FileStream _fs = null;
                //var _list = _db.LogData.ToList();
                var _fileLocation = "D:\\New Documents\\MDFileExports\\LogExport" + Guid.NewGuid() + ".csv";
                if (!File.Exists(_fileLocation))
                {
                    using (_fs = File.Create(_fileLocation.ToString()))
                    {
                    }
                }
                using (StreamWriter _stWriter = new StreamWriter(_fileLocation))
                {
                    _stWriter.Write(
                        "LogsID,TimeStamp,Log Notes,Med Name,Qty Taken" + Environment.NewLine
                        );
                    foreach (var item in _logList)
                    {
                        if (item.LogsID != 0 || item.TimeStamp != null || item.LogNotes != null || item.MedName!= null || item.QtyTaken != 0)
                        {
                            _stWriter.Write(
                                item.LogsID + "," + item.TimeStamp + "," +
                                item.LogNotes + "," + item.MedName + "," +
                                item.QtyTaken + Environment.NewLine
                                );
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                //
                // Reaching here means that there was a failure in making or saving the file export.
                //
                return false;
            }
        }

        public bool MedsExport(ObservableCollection<Meds> _meds)
        {
            try
            {
                FileStream _fstr = null;
                var _fileLocation = "D:\\New Documents\\MDFileExports\\MedExport" + Guid.NewGuid() + ".csv";
                if (!File.Exists(_fileLocation))
                {
                    using (_fstr = File.Create(_fileLocation.ToString()))
                    {
                    }
                }
                using (StreamWriter _stWriter = new StreamWriter(_fileLocation))
                {
                    _stWriter.Write(
                        "MedId,Med Name,Med Strength,Rx Number,Refill Qty,Refill DateTime," + 
                        "Qty Per Dose,Active Status" + Environment.NewLine
                        );
                    foreach (var item in _meds)
                    {
                        if (item.MedsID != 0 || item.MedName != null || item.MedStrength != null || item.RxNumber != null ||
                            item.RefillQty != 0 || item.RefillDateTime != null || item.QtyPerDose != 0 ||
                            item.ActiveStatus != false)
                        {
                            _stWriter.Write(
                                item.MedsID + "," + item.MedName + "," +
                                item.MedStrength + "," + item.RxNumber + "," +
                                item.RefillQty + "," + item.RefillDateTime + "," +
                                + item.QtyPerDose + "," + item.ActiveStatus
                                + Environment.NewLine
                                );
                            //return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteMedication(Meds _med)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    _db.Entry<Meds>(_med).State = System.Data.Entity.EntityState.Modified;
                    _db.Medications.Remove(_med);
                    _db.Entry<Meds>(_med).State = System.Data.Entity.EntityState.Deleted;
                    _db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void GetTotalLogCount(Action<int, Exception> callback)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    var total = _db.LogData.Count();
                    callback(total, null);
                }
            }
            catch(Exception e)
            {
                callback(0, e.InnerException);
            }
        }

        public int CalculateTotalPillUsage(string callingFunc, int qtyUsed, int currentCount)
        {
            try
            {
                switch (callingFunc)
                {
                    case "LogAdd":
                        var cnt = currentCount - qtyUsed;
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

        public void GetPillCountTotals(Action<ObservableCollection<Meds>, Exception> callback)
        {
            try
            {
                using (_db = new TrackerContext())
                {
                    //var tmp = _db.Medications.Count();
                    //callback(tmp, null);
                }
            }
            catch(Exception e)
            {
                //callback(0, e.InnerException);
            }
        }
        #endregion
    }
}