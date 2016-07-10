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
    public class ActiveListViewModel : ViewModelBase
    {
        private IDataService _dataService;
        public ActiveListViewModel(IDataService dataService)
        {
            _dataService = dataService;

            _dataService.MedsAllActive(
                (items, error) =>
                {
                    ActiveMedListing = items;
                });
        }

        private ObservableCollection<Meds> _activeMedListing;

        public ObservableCollection<Meds> ActiveMedListing
        {
            get { return _activeMedListing; }
            set
            {
                Set("ActiveMedListing", ref _activeMedListing, value);
            }
        }

        private Meds _selectedMed;

        public Meds SelectedMed
        {
            get { return _selectedMed; }
            set
            {
                Set("SelectedMed", ref _selectedMed, value);
            }
        }


    }
}