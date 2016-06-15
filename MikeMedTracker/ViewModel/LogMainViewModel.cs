using GalaSoft.MvvmLight;
using MikeMedTracker.Model;
using MikeMedTracker.Services;
using System.Collections.ObjectModel;

namespace MikeMedTracker.ViewModel
{
    public class LogMainViewModel : ViewModelBase
    {
        private IDataService _dataService;
        public LogMainViewModel(IDataService dataService)
        {
            _dataService = dataService;

        }

        #region Properties

        private Logs _log = default(Logs);

        public Logs Log
        {
            get { return _log; }
            set
            {
                if (_log == value)
                {
                    return;
                }
                _log = value;
                RaisePropertyChanged("Log");
            }
        }

        private ObservableCollection<Logs> _logList = default(ObservableCollection<Logs>);

        public ObservableCollection<Logs> LogList
        {
            get { return _logList; }
            set
            {
                if (_logList == value)
                { return; }
                _logList = value;
                RaisePropertyChanged("LogList");
            }
        }


        #endregion
    }
}