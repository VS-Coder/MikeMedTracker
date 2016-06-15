using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabbedMedTracker.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
        void GetExperiences(Action<ObservableCollection<Experiences>, Exception> callback);
        void GetLogList(Action<ObservableCollection<Logs>, Exception> callback);
    }
}
