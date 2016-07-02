using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NewTrackerforMike.Model;
using NewTrackerforMike.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace NewTrackerforMike.ViewModel
{
    public class LogAddViewModel : ViewModelBase
    {
        private IDataService _dataService;
        public LogAddViewModel(IDataService dataService)
        {
            SaveNewChanges = new RelayCommand(() => NewChangesSave(NewLog));

            _dataService = dataService;
            _dataService.GetLogAddViewerTitle(
                (title, error) =>
                {
                    Title = title.Title;
                });
            _dataService.MedsAllActive(
                (items, error) =>
                {
                    MedList = items;
                });
        }


        private string _title = default(string);
        public string Title
        {
            get { return _title; }
            set
            {
                Set("Title", ref _title, value);
            }
        }

        private Logs _newLog = default(Logs);

        public Logs NewLog
        {
            get { return _newLog; }
            set
            {
                Set("NewLog", ref _newLog, value);
            }
        }

        private string _success = default(string);

        public string Success
        {
            get { return _success; }
            set
            {
                Set("Success", ref _success, value);
            }
        }

        //private ObservableCollection<Logs> _logList = default(ObservableCollection<Logs>);

        //public ObservableCollection<Logs> LogList
        //{
        //    get { return _logList; }
        //    set
        //    {
        //        Set("LogList", ref _logList, value);
        //    }
        //}

        private ObservableCollection<Meds> _medList = default(ObservableCollection<Meds>);

        public ObservableCollection<Meds> MedList
        {
            get { return _medList; }
            set
            {
                if (_medList == value)
                { return; }
                Set("Medlist", ref _medList, value);
            }
        }

        private Meds _selectedMed = default(Meds);

        public Meds SelectedMed
        {
            get { return _selectedMed; }
            set
            {
                Set("SelectedMed", ref _selectedMed, value);
                NewLog.MedName = SelectedMed.MedName;
                NewLog.QtyTaken = SelectedMed.QtyPerDose;
                NewLog.MedID = SelectedMed.MedsID;
            }
        
        }

        public RelayCommand SaveNewChanges
        {
            get; set;
        }
        public object NewChangesSave(Logs _logs)
        {
            try
            {
                //_logS = NewLog;
                if (String.IsNullOrWhiteSpace(NewLog.LogNotes))
                {
                    // Default value when no user notes are entered. //
                    NewLog.LogNotes = "Taken as prescribed.";
                    // This is to set the MedStrength
                    NewLog.Strength = SelectedMed.MedStrength;
                    // Passing this ID into method to take inventory on.
                    var tro = SelectedMed.MedsID;
                    //
                    var t = _dataService.LogAdd(NewLog, tro);
                    if (t == true)
                    {
                        Success = "Saved Data";
                        //_dataService.CalculateTotalPillUsage("LogAdd", NewLog.QtyTaken, tro, NewLog.LogsID);
                    }
                    else
                    {
                        Success = "Unable to save data!";
                    }
                }
                else if(!String.IsNullOrWhiteSpace(NewLog.LogNotes))
                {
                    NewLog.Strength = SelectedMed.MedStrength;
                    var tro = SelectedMed.MedsID;

                    var t = _dataService.LogAdd(NewLog, tro);
                    if (t == true)
                    {
                        Success = "Saved Data";
                        //_dataService.CalculateTotalPillUsage("LogAdd", NewLog.QtyTaken, tro, NewLog.LogsID);
                    }
                    else
                    {
                        Success = "Unable to save data!";
                    }
                }

                return null;
            }
            catch(Exception e)
            {
                Success = "Unable to save data";
                SelectedMed = null;
                base.Cleanup();
                return e.InnerException;
            }


        }

        // Inventory Methods.
        //
        public async Task InvAddLog(int id)
        {

            await Task.FromResult<object>(null);
        }
    }
}