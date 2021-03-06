﻿using NewTrackerforMike.ViewModel;
using System.Windows;
using System;

namespace NewTrackerforMike.View
{
    public partial class MainPage_New : Window
    {
        private ViewModelLocator _vm;

        public MainPage_New()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
            _vm = (ViewModelLocator)this.FindResource("vmLocator");
        }

        protected override void OnInitialized(EventArgs e)
        {
            listView.SelectedItem = null;
            listView.UnselectAll();
            dtaList.Items.Refresh();
            base.OnInitialized(e);
            //_vm.Main.RefreshLowMeds();

            //if (_vm.Main.LowMed.Count != 0)
            //{
            //    warningButton.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    warningButton.Visibility = Visibility.Collapsed;
            //}
        }

        protected override void OnActivated(EventArgs e)
        {
            _vm.Main.RefreshLowMeds();
            if (_vm.Main.LowMed.Count != 0)
            {
                warningButton.Visibility = Visibility.Visible;
            }
            else
            {
                warningButton.Visibility = Visibility.Collapsed;
            }
            listView.SelectedItem = null;
            listView.UnselectAll();
            dtaList.Items.Refresh();
            _vm.Main.GetCount();
            base.OnActivated(e);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _vm.Main.RefreshLowMeds();
            if (_vm.Main.LowMed.Count != 0)
            {
                warningButton.Visibility = Visibility.Visible;
            }
            else
            {
                warningButton.Visibility = Visibility.Collapsed;
            }
        }
    }
}