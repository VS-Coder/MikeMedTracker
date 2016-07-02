using GalaSoft.MvvmLight;
using NewTrackerforMike.Model;
using NewTrackerforMike.Services;
using System.Collections.ObjectModel;

namespace NewTrackerforMike.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class WarningViewModel : ViewModelBase
    {
        private IDataService _dataService;
        public WarningViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.MedWarnings(
                (items, error) =>
                {
                    LowMedList = items;
                });

        }

        private ObservableCollection<Meds> _lowMedList = default(ObservableCollection<Meds>);

        public ObservableCollection<Meds> LowMedList
        {
            get { return _lowMedList; }
            set { Set("LowMedList", ref _lowMedList, value); }
        }

    }
}