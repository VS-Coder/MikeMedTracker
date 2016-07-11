using NewTrackerforMike.ViewModel;
using System.Windows;

namespace NewTrackerforMike.View
{
    public partial class ActiveMedView : Window
    {
        private ViewModelLocator _vm;
        public ActiveMedView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = (ViewModelLocator)this.FindResource("vmLocator");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}