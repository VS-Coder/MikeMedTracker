﻿using NewTrackerforMike.ViewModel;
using System.Windows;

namespace NewTrackerforMike.View
{
    public partial class LogMainView : Window
    {
        private ViewModelLocator _vm;
        public LogMainView()
        {
            InitializeComponent();
            _vm = (ViewModelLocator)this.FindResource("vmLocator");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}