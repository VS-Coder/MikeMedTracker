using GalaSoft.MvvmLight;
using NewTrackerforMike.Model;
using NewTrackerforMike.Services;
using System.Collections.ObjectModel;

namespace NewTrackerforMike.ViewModel
{
    public class PillCountViewModel : ViewModelBase
    {
        private IDataService _dataService;
        public PillCountViewModel(IDataService dataService)
        {
            _dataService = dataService;
            //_dataService.GetPillCountTotals(
            //    (count, error) =>
            //    {
            //        if (error != null)
            //        {
            //            return;
            //        }
            //        else
            //        {
            //            CountTotal = count;
            //        }
            //    });
        }

        #region Properties
        private Meds _SelectedMed;

        public Meds SelectedMed
        {
            get { return _SelectedMed; }
            set
            {
                Set("SelectedMed", ref _SelectedMed, value, true);
            }
        }
        private ObservableCollection<Meds> _countList = default(ObservableCollection<Meds>);

        public ObservableCollection<Meds> CountList
        {
            get { return _countList; }
            set
            {
                Set("CountList", ref _countList, value, true);
            }
        }
        private PillCount _CountObj;

        public PillCount CountObj
        {
            get { return _CountObj; }
            set
            {
                Set("CountObj", ref _CountObj, value, true);
            }
        }

        private int _countTotal;

        public int CountTotal
        {
            get { return _countTotal; }
            set
            {
                Set("CountTotal", ref _countTotal, value, true);
            }
        }


        #endregion

        #region Commanding



        #endregion

    }
}