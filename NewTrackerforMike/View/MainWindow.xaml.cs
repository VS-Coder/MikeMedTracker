using System;
using System.Windows;
using NewTrackerforMike.ViewModel;

namespace NewTrackerforMike.View
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected override void OnActivated(EventArgs e)
        {
            this.dataGrid.Items.Refresh();
            _vm.Main.GetCount();
            base.OnActivated(e);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            MainPage_New _view = new MainPage_New();
            _view.ShowDialog();
        }
    }
}