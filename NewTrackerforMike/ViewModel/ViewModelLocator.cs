/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:NewTrackerforMike.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using NewTrackerforMike.Design;
using NewTrackerforMike.Model;
using NewTrackerforMike.Services;

namespace NewTrackerforMike.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
                SimpleIoc.Default.Register<IDocumentService, DocumentService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public LogMainViewModel LogMainVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LogMainViewModel>();
            }
        }

        public LogAddViewModel LogAddVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LogAddViewModel>();
            }
        }

        public LogEditViewModel LogEditVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LogEditViewModel>();
            }
        }

        public MedMainViewModel MedMainVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MedMainViewModel>();
            }
        }

        public MedAddViewModel MedAddVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MedAddViewModel>();
            }
        }

        public MedEditViewModel MedEditVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MedEditViewModel>();
            }
        }

        public MedDocViewModel MedDocVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MedDocViewModel>();
            }
        }

        public PillCountViewModel PillCountVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PillCountViewModel>();
            }
        }

        public WarningViewModel WarningVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WarningViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            SimpleIoc.Default.Unregister<MainViewModel>();
        }
    }
}