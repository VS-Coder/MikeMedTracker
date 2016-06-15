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
            _vm = (ViewModelLocator)this.FindResource("vmLocator");
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        protected override void OnInitialized(EventArgs e)
        {
            listView.SelectedItem = null;
            listView.UnselectAll();
            this.dtaList.Items.Refresh();
            base.OnInitialized(e);
        }
        
        protected override void OnActivated(EventArgs e)
        {
            listView.SelectedItem = null;
            listView.UnselectAll();
            dtaList.Items.Refresh();
            base.OnActivated(e);
        }

        private void dtaList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }
    }
}