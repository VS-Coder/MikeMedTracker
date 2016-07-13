using NewTrackerforMike.Model;
using NewTrackerforMike.ViewModel;
using System;
using System.Windows;

namespace NewTrackerforMike.View
{
    public partial class LogAddView : Window
    {
        private ViewModelLocator _vm;
        public LogAddView()
        {
            InitializeComponent();
            _vm = (ViewModelLocator)this.FindResource("vmLocator");
            _vm.LogAddVM.NewLog = new Logs();
            _vm.LogAddVM.NewLog.TimeStamp = DateTime.Now;
            this.timeStampDatePicker.Text = DateTime.Now.ToShortDateString();

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public void samRefresh()
        {
            return;
        }
            private void btnClose_Click(object sender, RoutedEventArgs e)
        {           
            this.dataGrid.Items.Refresh();
            Close();
        }

        private void medNameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (tblSuccess.Text != String.Empty)
            {
                tblSuccess.Text = String.Empty;
            }

            _vm.LogAddVM.NewLog = new Logs();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            this.dataGrid.Items.Refresh();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            this.dataGrid.Items.Refresh();
        }

        private void dataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.timeStampDatePicker.SelectedDate = DateTime.Now;
        }
    }
}