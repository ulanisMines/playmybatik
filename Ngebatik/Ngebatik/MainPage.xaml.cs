using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.BackgroundAudio;

namespace Ngebatik
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool isOpen;

        MediaElement backsoundButton = new MediaElement();
        MediaElement backsoundgame = new MediaElement();

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            isOpen = false;
            Idle.Begin();
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
       
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
          
            if (isOpen)
                CloseSetting.Begin();
            else
            {
                OpenSetting.Begin();
            }
            isOpen = !isOpen;
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
          
            NavigationService.Navigate(new Uri("/ViewHelp.xaml", UriKind.Relative));
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/ViewMenuBelajar.xaml", UriKind.Relative));
            
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
          
            NavigationService.Navigate(new Uri("/ViewInfo.xaml", UriKind.Relative));
            
        }

         private void ButtonPlayOnClick(object sender, RoutedEventArgs e)
        {
           
            NavigationService.Navigate(new Uri("/SetLevel.xaml", UriKind.Relative));
            
            
        }
    }
}