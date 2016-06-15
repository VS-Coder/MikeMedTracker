﻿using NewTrackerforMike.Model;
using NewTrackerforMike.ViewModel;
using System.Windows;

namespace NewTrackerforMike.View
{
    public partial class LogEditView : Window
    {
        private ViewModelLocator _vm;
        public LogEditView()
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
    }
}