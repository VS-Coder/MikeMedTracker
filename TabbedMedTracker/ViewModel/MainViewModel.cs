using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows;
using TabbedMedTracker.Model;

namespace TabbedMedTracker.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

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

        private ObservableCollection<Experiences> _exp = default(ObservableCollection<Experiences>);

        public ObservableCollection<Experiences> Exp
        {
            get
            {
                return _exp;
            }
            set
            {
                Set(ref _exp, value);
            }
        }

        private Logs _activeLog;

        public Logs ActiveLog
        {
            get { return _activeLog; }
            set
            {
                Set(ref _activeLog, value);
            }
        }

        private ObservableCollection<Logs> _logList = default(ObservableCollection<Logs>);

        public ObservableCollection<Logs> LogList
        {
            get { return _logList; }
            set { Set(ref _logList, value); }
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        MessageBox.Show(error.ToString());
                    }

                    WelcomeTitle = item.Title;
                });

            _dataService.GetExperiences(
                (items, error) =>
                {
                    Exp = items;
                });
            _dataService.GetLogList(
                (items, error) =>
                {
                    if (error != null)
                    {
                        MessageBox.Show(error.ToString());
                    }
                    LogList = items;
                });
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}