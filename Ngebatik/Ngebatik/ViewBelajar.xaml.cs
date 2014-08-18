using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Ngebatik.View_Model;

namespace Ngebatik
{
    public partial class ViewBelajar : PhoneApplicationPage
    {
            //getFilosofiViewModel DataContext;
        private getFilosofiViewModel BindingData;
        private int index;
        MediaElement backsoundButton = new MediaElement(); 

            public ViewBelajar()
            {
                InitializeComponent();
                //DataContext = new getFilosofiViewModel();
                BindingData = new getFilosofiViewModel();
                BindingData.PropertyChanged += BindingData_PropertyChanged;

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

            void BindingData_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                TextLoading.Visibility = Visibility.Collapsed;
                if (e.PropertyName == "GetFilosofiCollection")
                {

                    index = 0;
                    BindingNamaBatik.Text = BindingData.GetFilosofiCollection[index].NamaBatik;
                    BindingFilosofi.Text = BindingData.GetFilosofiCollection[index].Filosofi;
                    BindingGambarBatik.Source =
                        new BitmapImage(
                            new Uri(BindingData.GetFilosofiCollection[index].GambarBatik));
                }

            }

           

          
            private void Grid_Tap_Next(object sender, System.Windows.Input.GestureEventArgs e)
            {
                int maxindex = BindingData.GetFilosofiCollection.Count-1;
                if (index < maxindex)
                {
                    index = index + 1;
                    BindingNamaBatik.Text = BindingData.GetFilosofiCollection[index].NamaBatik;
                    BindingFilosofi.Text = BindingData.GetFilosofiCollection[index].Filosofi;
                    BindingGambarBatik.Source =
                        new BitmapImage(
                            new Uri(BindingData.GetFilosofiCollection[index].GambarBatik));
                }
            }

            private void Grid_Tap_Back(object sender, System.Windows.Input.GestureEventArgs e)
            {
              if (index > 0)
                {
                    index = index -1;
                    BindingNamaBatik.Text = BindingData.GetFilosofiCollection[index].NamaBatik;
                    BindingFilosofi.Text = BindingData.GetFilosofiCollection[index].Filosofi;
                    BindingGambarBatik.Source =
                        new BitmapImage(
                            new Uri(BindingData.GetFilosofiCollection[index].GambarBatik));
                }
            }

            
            

       
    }
}