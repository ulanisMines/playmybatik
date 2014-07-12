using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Ngebatik.Kelas;

namespace Ngebatik
{
    public partial class PageNyorek : PhoneApplicationPage
    {
        System.Windows.Media.Imaging.BitmapImage bmp;
        private string gambar;


        public PageNyorek()
        {
            InitializeComponent();
            //GenerateSoalBatik();
        }

        private void GenerateSoalBatik()
        {
            bmp = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Soal/batik soal 1.jpg", UriKind.RelativeOrAbsolute));
            this.imageBatik.Source = bmp;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            
            NavigationService.Navigate(new Uri("/NyorekPage.xaml?gambar="+gambar, UriKind.Relative));
        }
      
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string msg = "null";
            if (NavigationContext.QueryString.TryGetValue("gambar", out msg))
            {
                gambar = msg;
                bmp = new System.Windows.Media.Imaging.BitmapImage(new Uri(msg, UriKind.RelativeOrAbsolute)); 
                imageBatik.Source = bmp;
                Navigation.Bmp = bmp;
                //PhoneApplicationService.Current.State["imageBatik"] = bmp;
            }
        }

       

    }
}