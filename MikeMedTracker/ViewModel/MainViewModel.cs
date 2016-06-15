using GalaSoft.MvvmLight;
using MikeMedTracker.Model;
using MikeMedTracker.Services;
using System.Collections.ObjectModel;

namespace MikeMedTracker.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        #region WelcomeTitle
        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }
        #endregion

        #region Properties

        private ObservableCollection<Logs> _logs = default(ObservableCollection<Logs>);

        public ObservableCollection<Logs> LogList
        {
            get { return _logs; }
            set
            {
                if (_logs != value)
                {
                    _logs = value;
                    RaisePropertyChanged("LogList");
                }
            }
        }

        private Logs _log;

        public Logs Log
        {
            get { return _log; }
            set
            {
                _log = value;
                RaisePropertyChanged("Log");
            }
        }



        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        private readonly IDataService _dataService;
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;

            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });


            _dataService.GetAllLogData
                (
                (items, error) => 
                {
                    LogList = items;
                });
        }


        public override void Cleanup()
        {
            // Clean up if needed

            base.Cleanup();
        }
    }
}