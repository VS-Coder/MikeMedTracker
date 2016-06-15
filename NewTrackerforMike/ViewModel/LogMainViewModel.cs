using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using NewTrackerforMike.Model;
using NewTrackerforMike.Services;
using NewTrackerforMike.View;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NewTrackerforMike.ViewModel
{
    public class LogMainViewModel : ViewModelBase
    {
        private IDataService _dataService;

        public RelayCommand AddNewLog
        {
            get; set;
        }

        public object NewLogAdd()
        {
            SimpleIoc.Default.Register<LogAddViewModel>();
            LogAddView _view = new LogAddView();
            _view.ShowDialog();
            SimpleIoc.Default.Unregister<LogAddViewModel>();
            return null;
        }

        public RelayCommand EditLog
        {
            get; set;
        }

        public object LogEdit()
        {
            SimpleIoc.Default.Register<LogEditViewModel>();
            LogEditView _logEditor = new LogEditView();
            _logEditor.ShowDialog();
            SimpleIoc.Default.Unregister<LogEditViewModel>();
            return null;

        }

        public RelayCommand DeleteLog
        { get; set; }

        public object LogDelete(Logs _log)
        {
            var success = _dataService.DeleteLog(_log);
            if (success == true)
            {
                Success = "Log Deleted";
            }
            else if (success == false)
            {
                Success = "Unable to delete log";
            }
            return null;
        }

        public RelayCommand ExportLogData
        {
            get; set;
        }
        public object LogExport(ObservableCollection<Logs> _logs)
        {
            if (_dataService.LogsExport(_logs) == true)
            {
                Success = "Data Exported";
                return null;
            }
            else
            {
                Success = "Unable to export data";
            }
            return null;
        }

        public LogMainViewModel(IDataService dataService)
        {
            AddNewLog = new RelayCommand(() => NewLogAdd());
            EditLog = new RelayCommand(() => LogEdit());
            DeleteLog = new RelayCommand(() => LogDelete(SelelectedLog));
            ExportLogData = new RelayCommand(() => LogExport(LogList));

            _dataService = dataService;
            _dataService.LogsAll(
                (items, error) =>
                {
                    LogList = items;
                });

            _dataService.GetLogMainViewerTitle(
                (title, error) =>
                {
                    Title = title.Title;
                });

            _dataService.GetTotalLogCount(
                (num, error) =>
                {
                    LogCnt = num;

                });

            MainOptions = GetOptions();
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                Set("Title", ref _title, value);
            }
        }


        private ObservableCollection<Logs> _logList;

        public ObservableCollection<Logs> LogList
        {
            get { return _logList; }
            set
            {
                Set("LogList", ref _logList, value);
            }
        }

        private Logs _selectedLog;

        public Logs SelelectedLog
        {
            get { return _selectedLog; }
            set
            {
                Set("SelectedLog", ref _selectedLog, value);
            }
        }

        private ObservableCollection<Experience> _MainOptions;

        public ObservableCollection<Experience> MainOptions
        {
            get { return _MainOptions; }
            set
            {
                Set("MainOption", ref _MainOptions, value);
            }
        }

        private Experience _selectedOption;

        public Experience SelectedOption
        {
            get { return _selectedOption; }
            set
            {
                Set("SelectedOption", ref _selectedOption, value);
                // call task to evaluate user's selection.
                EvalOptions(_selectedOption);
            }
        }


        private string _success;

        public string Success
        {
            get { return _success; }
            set
            {
                Set("Success", ref _success, value);
            }
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

        public async Task EvalOptions(Experience str)
        {
            switch (str.Name)
            {
                case "Add New Log":
                    NewLogAdd();
                    break;
                case "Edit Selection":
                    LogEdit();
                    break;
                case "Delete Selection":
                    LogDelete(SelelectedLog);
                    break;
                case "Export Log Data":
                    LogExport(LogList);
                    break;
                //case "Close Window":
                //    //LogMainView lmv = new LogMainView();
                //    //lmv.Close();
                //    break;
                default:
                    break;
            }

            await Task.FromResult<object>(null);
        }

        private int _logCnt;

        public int LogCnt
        {
            get { return _logCnt; }
            set
            {
                Set("LogCnt", ref _logCnt, value);
            }
        }


    }
}