using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NewTrackerforMike.Model;
using NewTrackerforMike.Services;
using System.Collections.ObjectModel;

namespace NewTrackerforMike.ViewModel
{
    public class MedEditViewModel : ViewModelBase
    {
        private IDataService _dataService;
        public MedEditViewModel(IDataService dataService)
        {
            SaveEdits = new RelayCommand(() => EditorSave(EditMed));

            _dataService = dataService;
            _dataService.GetMedEditorTitle(
                (item, error) =>
                {
                    Title = item.Title;
                });
            _dataService.MedsAll(
                (items, error) =>
                {
                    EditorList = items;
                });
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        private string _success;

        public string Success
        {
            get { return _success; }
            set
            {
                _success = value;
                RaisePropertyChanged("Success");
            }
        }

        private ObservableCollection<Meds> _EditorList;

        public ObservableCollection<Meds> EditorList
        {
            get { return _EditorList; }
            set
            {
                _EditorList = value;
                RaisePropertyChanged("EditorList");
            }
        }

        private Meds _EditMed;

        public Meds EditMed
        {
            get { return _EditMed; }
            set
            {
                _EditMed = value;
                RaisePropertyChanged("EditMed");
            }
        }

        public RelayCommand SaveEdits
        {
            get;
            set;
        }
        public object EditorSave(Meds _med)
        {
            var success = _dataService.EditMeds(_med);
            if (success == true)
            {
                Success = "Data Saved";
            }
            else if (success == false)
            {
                Success = "Unable to save changes";
            }
            return null;
        }

        public RelayCommand ClearForm
        {
            get; set;
        }
        public object FormClear()
        {
            EditMed = new Meds();
            Success = "Cleared Form";
            return null;
        }
    }
}