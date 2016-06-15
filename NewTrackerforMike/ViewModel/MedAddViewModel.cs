using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NewTrackerforMike.Model;
using NewTrackerforMike.Services;
using System.Collections.ObjectModel;

namespace NewTrackerforMike.ViewModel
{
    public class MedAddViewModel : ViewModelBase
    {
        private IDataService _dataService;
        public MedAddViewModel(IDataService dataService)
        {
            SaveNewMed = new RelayCommand(() => NewMedSave(ActiveMed));
            FormClear = new RelayCommand(() => ClearForm());
            _dataService = dataService;
            _dataService.GetMedAddTitle(
                (item, error) =>
                {
                    Title = item.Title;
                });

            _dataService.MedsAll(
                (items, error) =>
                {
                    MedList = items;
                });

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


        private string _success;

        public string Success
        {
            get { return _success; }
            set
            {
                Set("Success", ref _success, value);
            }
        }


        private Meds _activeMed;

        public Meds ActiveMed
        {
            get { return _activeMed; }
            set
            {
                Set("ActiveMed", ref _activeMed, value);
            }
        }

        private ObservableCollection<Meds> _medList;

        public ObservableCollection<Meds> MedList
        {
            get { return _medList; }
            set
            {
                Set("MedList", ref _medList, value);
            }
        }

        public RelayCommand SaveNewMed
        {
            get; set;
        }
        public object NewMedSave(Meds _med)
        {
            var success = _dataService.MedsAdd(_med);
            if (success == true)
            {
                Success = "Data Saved";
                MedList.Add(ActiveMed);
                ClearForm();
            }
            else if(success == false)
            {
                Success = "Unable to save data.";
            }
            return null;
        }

        public RelayCommand FormClear
        {
            get;set;
        }
        public object ClearForm()
        {
            ActiveMed = new Meds();
            Success = "";
            return null;
        }
    }
}