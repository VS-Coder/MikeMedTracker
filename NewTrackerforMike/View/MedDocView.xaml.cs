using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NewTrackerforMike.View
{
    /// <summary>
    /// Description for MedDocView.
    /// </summary>
    public partial class MedDocView : Window
    {
        /// <summary>
        /// Initializes a new instance of the MedDocView class.
        /// </summary>
        public MedDocView(string _path)
        {
            InitializeComponent();
            //this.imagebox.Source = new Uri("C:\\Users\\Hansen\\Pictures\\2016-01-02\\001.jpg");
            Image myImage3 = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(_path, UriKind.RelativeOrAbsolute);
            bi3.EndInit();
            myImage3.Stretch = Stretch.Fill;
            myImage3.Source = bi3;
            this.imagebox.Source = bi3;
        }
    }
}