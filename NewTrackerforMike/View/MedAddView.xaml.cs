using NewTrackerforMike.Model;
using NewTrackerforMike.ViewModel;
using System;
using System.Windows;

namespace NewTrackerforMike.View
{
    public partial class MedAddView : Window
    {
        private ViewModelLocator _vm;
        public MedAddView(Meds _med)
        {
            InitializeComponent();
            _vm = (ViewModelLocator)this.FindResource("vmLocator");
            _vm.MedAddVM.ActiveMed = _med;
            _med.RefillDateTime = DateTime.Now;
            _med.CountDate = DateTime.Now;
        }
         
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //System.Windows.Data.CollectionViewSource medAddViewModelViewSource = 
            //((System.Windows.Data.CollectionViewSource)(this.FindResource("medAddViewModelViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // medAddViewModelViewSource.Source = [generic data source]
        }

      private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}