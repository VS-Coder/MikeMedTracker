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
            //Closing += LogAddView_Closing;
            _vm = (ViewModelLocator)this.FindResource("vmLocator");
            _vm.LogAddVM.NewLog = new Logs();
            _vm.LogAddVM.NewLog.TimeStamp = DateTime.Now;
            _vm.LogAddVM.NewLog.TimeStamp = DateTime.Now;
            this.timeStampDatePicker.Text = DateTime.Now.ToShortDateString();

        }

        //private void LogAddView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    _vm.LogAddVM.Cleanup();
        //    //throw new NotImplementedException();
        //}

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
                tblSuccess.Text = "";
            }

            _vm.LogAddVM.NewLog = new Logs();
        }
    }
}