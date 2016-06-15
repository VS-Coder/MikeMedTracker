using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NewTrackerforMike.Model;
using NewTrackerforMike.Services;
using System.Collections.ObjectModel;

namespace NewTrackerforMike.ViewModel
{
    public class LogEditViewModel : ViewModelBase
    {
        private IDataService _dataService;
        public LogEditViewModel(IDataService dataService)
        {
            SaveChangesToEditor = new RelayCommand(() => ChangesSave(EditLog));


            _dataService = dataService;
            _dataService.GetLogEditorTitle(
                (title, error) =>
                {
                    Title = title.Title;
                });

            _dataService.LogsAll(
                (items, error) =>
                {
                    EditorList = items;
                });
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

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        private Logs editlog;

        public Logs EditLog
        {
            get { return editlog; }
            set
            {
                editlog = value;
                RaisePropertyChanged("EditLog");
            }
        }

        private ObservableCollection<Logs> _editorList;

        public ObservableCollection<Logs> EditorList
        {
            get { return _editorList; }
            set
            {
                _editorList = value;
                RaisePropertyChanged<ObservableCollection<Logs>>("EditorList", broadcast: true);
                //RaisePropertyChanged("EditorList");
                
            }
            
        }


        public RelayCommand SaveChangesToEditor
        {
            get; set;
        }
        public object ChangesSave(Logs _log)
        {
            var success = _dataService.EditLog(_log);
            if (success == true)
            {

                Success = "Changes Saved";
                return true;
            }
            Success = "Changes Unsaved";
            return false;
        }

    }
}