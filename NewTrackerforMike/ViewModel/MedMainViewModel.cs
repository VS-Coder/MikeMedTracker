using NewTrackerforMike.Model;
using System;
using GalaSoft.MvvmLight;
using NewTrackerforMike.Services;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using NewTrackerforMike.View;

namespace NewTrackerforMike.ViewModel
{
    public class MedMainViewModel : ViewModelBase
    {
        private IDataService _dataService;
        private IDocumentService _documentService;
        public MedMainViewModel(IDataService dataService, IDocumentService documentService)
        {
            ExportMedList = new RelayCommand(() => MedListExport(MedList));
            DeleteMed = new RelayCommand(() => MedDelete(Med));
            GetInfo = new RelayCommand(() => MedInfo(Med));

            _dataService = dataService;
            _documentService = documentService;

            _dataService.MedsAll(
                (items, error) =>
                {
                    MedList = items;
                });

            _dataService.GetMedViewerTitle(
                (title, error) =>
                {
                    Title = title.Title;
                });
        }

        private string _confirmation;

        public string Confirmation
        {
            get { return _confirmation; }
            set
            {
                Set("Confirmation", ref _confirmation, value);
            }
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


        private Meds _med;

        public Meds Med
        {
            get { return _med; }
            set
            {
                Set("Med", ref _med, value, true);
            }
        }
        private ObservableCollection<Meds> _medList = default(ObservableCollection<Meds>);

        public ObservableCollection<Meds> MedList
        {
            get { return _medList; }
            set
            {
                Set("MedList", ref _medList, value);
            }
        }

        #region Commands

        public RelayCommand DeleteMed
        {
            get; set;
        }

        public object MedDelete(Meds _med)
        {
            if (_dataService.DeleteMedication(_med) == true)
            {
                Confirmation = "Medication has been deleted.";
                MedList.Remove(_med);
                return true;
            }
            else
            {
                Confirmation = "Unable to delete the record at this time.";
                return false;
            }
        }

        public RelayCommand GetInfo
        {
            get;
            set;
        }
        public object MedInfo(Meds _med)
        {
            var _pth = _documentService.GetImagePath(_med);
            SimpleIoc.Default.Register<MedDocViewModel>();
            MedDocView _view = new MedDocView(_pth);
            _view.ShowDialog();
            SimpleIoc.Default.Unregister<MedDocViewModel>();

            return null;
        }

        public object MedListExport(ObservableCollection<Meds> _meds)
        {
            if (_dataService.MedsExport(_meds) == true)
            {
                Confirmation = "Meds Exported";
            }
            else
            {
                Confirmation = "Unable to Export";
            }
            return null;
        }
        public RelayCommand ExportMedList
        {
            get;
            set;
        }

        #endregion

    }
}