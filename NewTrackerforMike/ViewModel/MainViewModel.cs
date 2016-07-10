using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using NewTrackerforMike.Model;
using NewTrackerforMike.Services;
using NewTrackerforMike.View;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NewTrackerforMike.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region DataService IDataService
        private readonly IDataService _dataService;
        #endregion

        #region Welcome Title
        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }
        #endregion

        #region Ctor
        public MainViewModel(IDataService dataService)
        {
            AddNewLog = new RelayCommand(() => LogAddNew());
            EditLogData = new RelayCommand(() => LogDataEdit());
            ViewAllLogs = new RelayCommand(() => AllLogView());

            AddNewMed = new RelayCommand(() => NewMedAdd());
            EditMed = new RelayCommand(() => MedEdit());
            ViewAllMeds = new RelayCommand(() => AllMedsView());

            GetWarnings = new RelayCommand(() => ViewWarning());

            _dataService = dataService;
            _dataService.MedWarnings(
                (items, error) =>
                {
                    LowMed = items;
                });
            Experiences = GetExperiences();
            _dataService.GetLastLogSnapshot(
                (items,error) =>
                {
                    LogLastSnapshot = items;
                });
            _dataService.GetData(
                (item, error) =>
                {
                    WelcomeTitle = item.Title;
                });
             GetCount();
       }


        #endregion Ctor

        #region Main Commanding
        //
        //
        //
        #region Log Commands
        public RelayCommand AddNewLog
        {
            get;
            set;
        }   

        public object LogAddNew()
        {
            SimpleIoc.Default.Register<LogAddViewModel>();
            LogAddView _view = new LogAddView();
            _view.ShowDialog();
            SimpleIoc.Default.Unregister<LogAddViewModel>();
            _dataService.GetLastLogSnapshot(
                (items, error) =>
                {
                    LogLastSnapshot = items;
                });
            _dataService.GetTotalLogCount(
                (count, error) => {
                    LogCount = count;
                });

            return null;
        }

        public RelayCommand EditLogData
        {
            get; set;
        }

        public object LogDataEdit()
        {
            SimpleIoc.Default.Register<LogEditViewModel>();
            LogEditView _view = new LogEditView();
            _view.ShowDialog();
            SimpleIoc.Default.Unregister<LogEditViewModel>();
            _dataService.GetLastLogSnapshot(
                (items, error) =>
                {
                    LogLastSnapshot = items;
                });
            return null;
        }

        public RelayCommand ViewAllLogs
        {
            get; set;
        }

        public object AllLogView()
        {
            SimpleIoc.Default.Register<LogMainViewModel>();
            LogMainView _mv = new LogMainView();
            _mv.ShowDialog();
            SimpleIoc.Default.Unregister<LogMainViewModel>();
            _dataService.GetLastLogSnapshot(
                (items, error) =>
                {
                    LogLastSnapshot = items;
                });

            return null;
        }

        public object ViewWarning()
        {
            SimpleIoc.Default.Register<WarningViewModel>();
            WarningView _wv = new WarningView();
            _wv.ShowDialog();
            SimpleIoc.Default.Unregister<WarningViewModel>();
            return null;
        }

        #endregion Log Commands
        //
        //
        #region Meds Commands

        public RelayCommand GetWarnings
        {
            get;
            set;
        }

        public RelayCommand AddNewMed
        {
            get; set;
        }

        public object NewMedAdd()
        {
            SimpleIoc.Default.Register<MedAddViewModel>();
            MedAddView _maView = new MedAddView(new Meds());
            _maView.ShowDialog();
            SimpleIoc.Default.Unregister<MedAddViewModel>();
            return null;
        }

        public RelayCommand EditMed
        { get; set; }

        public object MedEdit()
        {
            SimpleIoc.Default.Register<MedEditViewModel>();
            MedEditorView _view = new MedEditorView();
            _view.ShowDialog();
            SimpleIoc.Default.Unregister<MedEditViewModel>();
            return null;
        }

        public RelayCommand ViewAllMeds
        {
            get;
            set;
        }

        public object AllMedsView()
        {
            SimpleIoc.Default.Register<MedMainViewModel>();
            MedMainView _view = new MedMainView();
            _view.ShowDialog();
            SimpleIoc.Default.Unregister<MedMainViewModel>();
            return null;
        }

        public RelayCommand GetAllActiveMeds
        {
            get;
            set;            
        }

        public object ListAllActiveMeds()
        {

            return null;
        }
        #endregion Med Commands


        #endregion Main Commanding

        #region Properties

        private ObservableCollection<Meds> _medList;

        public ObservableCollection<Meds> MedList
        {
            get { return _medList; }
            set
            {
                Set("MedList", ref _medList, value);
            }
        }

        private ObservableCollection<Meds> _lowMed = default(ObservableCollection<Meds>);

        public ObservableCollection<Meds> LowMed
        {
            get { return _lowMed; }
            set { Set("LowMed", ref _lowMed, value); }
        }



        private ObservableCollection<Logs> _logLastSnapshot;

        public ObservableCollection<Logs> LogLastSnapshot
        {
            get { return _logLastSnapshot; }
            set
            {
                if (_logLastSnapshot == value)
                {
                    return;
                }

                Set("LogLastSnapshot", ref _logLastSnapshot, value);
            }
        }

        private Logs _SelectedLog;

        public Logs SelectedLog
        {
            get { return _SelectedLog; }
            set
            {
                if (_SelectedLog == value)
                {
                    return;
                }
                Set("SelectedLog", ref _SelectedLog, value);
            }
        }

        private  Experience _selectedExp;

        public Experience SelectedExp
        {
            get { return _selectedExp; }
            set
            {
                Set("SelectedExp", ref _selectedExp, value);
                EvalSelectedExpAsync(SelectedExp);
            }
        }


        private int _logCount;

        public int LogCount
        {
            get { return _logCount; }
            set
            {
                Set("LogCount", ref _logCount, value);
            }
        }

        private ObservableCollection<Experience> _experiences;

        public ObservableCollection<Experience> Experiences
        {
            get { return _experiences; }
            set
            {
                Set("Experiences", ref _experiences, value);
            }
        }


        #endregion

        #region Methods

        

        

        public void GetCount()
        {
            //LogCount = GetLogTotal();
            _dataService.GetTotalLogCount(
                (count, error) =>
                {
                    LogCount = count;
                });
        }

        public async Task EvalSelectedExpAsync(Experience exp)
        {
            switch (exp.Name)
            {
                case "Add Log":
                    LogAddNew();
                    break;
                case "View Logs":
                    AllLogView();
                    break;
                case "Edit Log":
                    LogDataEdit();
                    break;
                case "Add Med":
                    NewMedAdd();
                    break;
                case "Edit Med":
                    MedEdit();
                    break;
                case "View All Meds":
                    AllMedsView();
                    break;
                default:
                    App.Current.Shutdown();
                    break;
            }
            await Task.FromResult(exp);
        }

        public ObservableCollection<Experience> GetExperiences()
        {
            ObservableCollection<Experience> tmp = new ObservableCollection<Experience>();
            Experience exp;
            //var exp = new Experience("Main Page");
            //tmp.Add(exp);
            exp = new Experience("Add Log");
            tmp.Add(exp);
            exp = new Experience("View Logs");
            tmp.Add(exp);
            exp = new Experience("Edit Log");
            tmp.Add(exp);
            exp = new Experience("View All Meds");
            tmp.Add(exp);
            exp = new Experience("Add Med");
            tmp.Add(exp);
            exp = new Experience("Edit Med");
            tmp.Add(exp);
            exp = new Experience("Close App");
            tmp.Add(exp);
            return tmp;
        }

        public void RefreshLowMeds()
        {
            _dataService.MedWarnings(
            (items, error) =>
            {
                LowMed = items;
            });

            return;
        }

        #endregion

        
        public override void Cleanup()
        {
            // Clean up if needed

            base.Cleanup();
        }
    }
}