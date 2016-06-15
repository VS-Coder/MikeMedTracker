using System.Windows;
using TabbedMedTracker.ViewModel;

namespace TabbedMedTracker.Views
{
    public partial class MainWindow : Window
    {
        private ViewModelLocator _vm;
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
            _vm = (ViewModelLocator)this.FindResource("vmLocator");
        }

        private void listView_Initialized(object sender, System.EventArgs e)
        {
        }
    }
}