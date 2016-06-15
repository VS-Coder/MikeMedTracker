using NewTrackerforMike.ViewModel;
using System.Windows;

namespace NewTrackerforMike.View
{
    public partial class MedEditorView : Window
    {
        private ViewModelLocator _vm;
        public MedEditorView()
        {
            InitializeComponent();
            _vm = (ViewModelLocator)this.FindResource("vmLocator");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.dataGrid.SelectedItem = null;
            this.lblSuccess.Text = "Form Cleared";
        }

        private void dataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.lblSuccess.Text = "";
        }
    }
}