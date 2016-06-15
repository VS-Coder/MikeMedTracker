using System;
using System.Collections.ObjectModel;
using TabbedMedTracker.Model;

namespace TabbedMedTracker.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }
        public void GetExperiences(Action<ObservableCollection<Experiences>, Exception> callback)
        {

        }
        public void GetLogList(Action<ObservableCollection<Logs>, Exception> callback)
        {

        }
    }
}