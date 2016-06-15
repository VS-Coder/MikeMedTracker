using NewTrackerforMike.Model;
using NewTrackerforMike.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System;

namespace NewTrackerforMike.View
{
    public partial class MedMainView : Window
    {
        private ViewModelLocator _vm;
        public MedMainView()
        {
            InitializeComponent();
            _vm = (ViewModelLocator)this.FindResource("vmLocator");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //protected override void OnInitialized(EventArgs e)
        //{
        //    _vm.Main.GetCount();
        //    base.OnInitialized(e);
        //}

    }
}