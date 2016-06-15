using MikeMedTracker.ViewModel;
using System.Windows;

namespace MikeMedTracker.View
{
    /// <summary>
    /// Description for NewMainView.
    /// </summary>
    public partial class MainView : Window
    {
        private ViewModelLocator _vm;
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

    }
}