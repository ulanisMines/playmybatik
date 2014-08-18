using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;

namespace Ngebatik
{
    public partial class ViewPeralatanBatik : PhoneApplicationPage
    {
        MediaElement backsoundButton = new MediaElement();
        public int index;
        public ViewPeralatanBatik()
        {
            InitializeComponent();
            this.LayoutRoot.Children.Add(backsoundButton);

            backsoundButton.CurrentStateChanged += BacksoundButtonCurrentStateChanged;
            backsoundButton.MediaEnded += BacksoundButton_MediaEnded;
        }

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

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            backsoundButton.Source = new Uri("Audio/backsound.mp3", UriKind.RelativeOrAbsolute);
            backsoundButton.Play();
        }
        private void PrGawangan_Click(object sender, RoutedEventArgs e)
        {
            index = 1;
         
            NavigationService.Navigate(new Uri("/KontenAlatBatik.xaml?index=" +index, UriKind.Relative));
        }

        private void Wajan_Clik(object sender, RoutedEventArgs e)
        {
            int index = 2;

            NavigationService.Navigate(new Uri("/KontenAlatBatik.xaml?index=" + index, UriKind.Relative));
        }

         private void Malam_Click(object sender, RoutedEventArgs e)
        {
            index = 11;

            NavigationService.Navigate(new Uri("/KontenAlatBatik.xaml?index=" + index, UriKind.Relative));
        }

        private void Dhingklik_Click(object sender, RoutedEventArgs e)
        {
            index = 3;

            NavigationService.Navigate(new Uri("/KontenAlatBatik.xaml?index=" + index, UriKind.Relative));
        }

        private void Kompor_Click(object sender, RoutedEventArgs e)
        {

             index = 5;

            NavigationService.Navigate(new Uri("/KontenAlatBatik.xaml?index=" + index, UriKind.Relative));
        }

        private void Taplak_Click(object sender, RoutedEventArgs e)
        {
            index = 6;

            NavigationService.Navigate(new Uri("/KontenAlatBatik.xaml?index=" + index, UriKind.Relative));
        }

        private void Mori_Click(object sender, RoutedEventArgs e)
        {
           index = 7;

            NavigationService.Navigate(new Uri("/KontenAlatBatik.xaml?index=" + index, UriKind.Relative));
        }

        private void Bandul_Click(object sender, RoutedEventArgs e)
        {
            index = 8;

            NavigationService.Navigate(new Uri("/KontenAlatBatik.xaml?index=" + index, UriKind.Relative));
        }

        private void PewarnaAlami_Click(object sender, RoutedEventArgs e)
        {
            index = 9;

            NavigationService.Navigate(new Uri("/KontenAlatBatik.xaml?index=" + index, UriKind.Relative));
        }

        private void SaringanMalam_Click(object sender, RoutedEventArgs e)
        {
             index = 10;

            NavigationService.Navigate(new Uri("/KontenAlatBatik.xaml?index=" + index, UriKind.Relative));
        }

        private void Canting_Click(object sender, RoutedEventArgs e)
        {
            index = 4;

            NavigationService.Navigate(new Uri("/KontenAlatBatik.xaml?index=" + index, UriKind.Relative));
        }
    }
}