using NewTrackerforMike.Model;
using System;
using System.Collections.ObjectModel;

namespace NewTrackerforMike.Services
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
        void GetLogMainViewerTitle(Action<DataItem, Exception> callback);
        void GetLogAddViewerTitle(Action<DataItem, Exception> callback);
        void GetLogEditorTitle(Action<DataItem, Exception> callback);
        void GetMedAddTitle(Action<DataItem, Exception> callback);
        void GetMedViewerTitle(Action<DataItem, Exception> callback);
        void GetMedEditorTitle(Action<DataItem, Exception> callback);

        void GetTotalLogCount(Action<int, Exception> callback);
        bool LogAdd(Logs _log);
        bool EditLog(Logs _log);
        void GetLastLogSnapshot(Action<ObservableCollection<Logs>, Exception> callback);
        void LogsAll(Action<ObservableCollection<Logs>, Exception> callback);
        bool DeleteLog(Logs _log);
        bool LogsExport(ObservableCollection<Logs> _logList);
        
        bool MedsAdd(Meds _med);
        bool EditMeds(Meds _med);
        bool DeleteMedication(Meds _med);
        void MedsAllActive(Action<ObservableCollection<Meds>, Exception> callback);
        void MedsAll(Action<ObservableCollection<Meds>, Exception> callback);
        bool MedsExport(ObservableCollection<Meds> _meds);

        void GetPillCountTotals(Action<ObservableCollection<Meds>, Exception> callback);
    }
}
