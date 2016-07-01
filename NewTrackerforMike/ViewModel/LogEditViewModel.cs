using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NewTrackerforMike.Model;
using NewTrackerforMike.Services;
using System;
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
                Set("Success", ref _success, value);
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                Set("Title", ref title, value);
            }
        }

        private Logs editlog;

        public Logs EditLog
        {
            get { return editlog; }
            set
            {
                Set("EditLog", ref editlog, value);
            }
        }

        private DateTime _tod;

        public DateTime TOD
        {
            get { return _tod; }
            set
            {
                Set("Tod", ref _tod, value);
            }
        }



        private ObservableCollection<Logs> _editorList;

        public ObservableCollection<Logs> EditorList
        {
            get { return _editorList; }
            set
            {
                Set("EditorList", ref _editorList, value);                
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