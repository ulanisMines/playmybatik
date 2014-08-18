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
using System.Windows.Media.Imaging;

namespace Ngebatik
{
    public partial class PageNyorek : PhoneApplicationPage
    {
        System.Windows.Media.Imaging.BitmapImage bmp;
        private string gambar;
        MediaElement backsoundButton = new MediaElement();
        MediaElement backsoundgame = new MediaElement();


        public PageNyorek()
        {
            InitializeComponent();
            //GenerateSoalBatik();
            this.LayoutRoot.Children.Add(backsoundButton);

            backsoundButton.CurrentStateChanged += BacksoundButtonCurrentStateChanged;
            backsoundButton.MediaEnded += BacksoundButton_MediaEnded;
        }

       // private void GenerateSoalBatik()
        //{
          //  bmp = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Soal/batik soal 1.jpg", UriKind.RelativeOrAbsolute));
            //this.imageBatik.Source = bmp;
       // }

        private void BacksoundButtonCurrentStateChanged(object sender, RoutedEventArgs e)
        {
            switch (backsoundButton.CurrentState)
            {
                case System.Windows.Media.MediaElementState.AcquiringLicense:
                    break;
                case System.Windows.Media.MediaElementState.Buffering:
                    break;
                case System.Windows.Media.MediaElementState.Closed:
                    break;
                case System.Windows.Media.MediaElementState.Individualizing:
                    break;
                case System.Windows.Media.MediaElementState.Opening:
                    break;
                case System.Windows.Media.MediaElementState.Paused:
                    break;
                case System.Windows.Media.MediaElementState.Playing:
                    break;
                case System.Windows.Media.MediaElementState.Stopped:
                    break;
                default:
                    break;
            }
            System.Diagnostics.Debug.WriteLine("CurrentState event " + backsoundButton.CurrentState.ToString());
        }

        private void BacksoundButton_MediaEnded(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ended event " + backsoundButton.CurrentState.ToString());
            // Set the source to null, force a Close event in current state
            backsoundButton.Source = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string x = gambar.Substring(gambar.LastIndexOf('/')+1);
            MessageBox.Show(x);
            Helper.GambarBatik = x;
            Helper.TrueGambarBatik = (BitmapImage)imageBatik.Source;
            NavigationService.Navigate(new Uri("/NyorekPage.xaml?gambar=" + x, UriKind.Relative));
                      
        }
      
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            backsoundButton.Source = new Uri("Audio/backsound.mp3", UriKind.RelativeOrAbsolute);
            backsoundButton.Play();

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