using NewTrackerforMike.ViewModel;
using System.Windows;

namespace NewTrackerforMike.View
{
    /// <summary>
    /// Description for WarningView.
    /// </summary>
    public partial class WarningView : Window
    {
        private ViewModelLocator vm;
        public WarningView()
        {
            InitializeComponent();
            vm = (ViewModelLocator)this.FindResource("vmLocator");
        }
    }
}