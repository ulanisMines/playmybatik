using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Ngebatik
{
    public partial class ViewMenuBelajar : PhoneApplicationPage
    {

        MediaElement backsoundButton = new MediaElement();
        public ViewMenuBelajar()
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
        private void FilosofiBatik_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewBelajar.xaml", UriKind.Relative));
        }

        private void PeralatanBatik_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewPeralatanBatik.xaml", UriKind.Relative));
        }
    }
}