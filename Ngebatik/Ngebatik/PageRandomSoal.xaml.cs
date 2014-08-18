
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Ngebatik.View_Model;
using Newtonsoft.Json.Linq;
using Ngebatik.Kelas;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Ngebatik
{
    public partial class PageRandomSoal : PhoneApplicationPage
    {
        MediaElement backsoundButton = new MediaElement();
        MediaElement backsoundgame = new MediaElement();

        //getsoalViewModel DataContext;
        private getsoalViewModel Soal;
        public PageRandomSoal()
        {
            InitializeComponent();

            Soal = new getsoalViewModel();
            DataContext = Soal;
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            backsoundButton.Source = new Uri("Audio/backsound.mp3", UriKind.RelativeOrAbsolute);
            backsoundButton.Play();
            base.OnNavigatedTo(e);

            string msg = "null";
            if (NavigationContext.QueryString.TryGetValue("Level", out msg))
            {
                //MessageBox.Show(msg);
                //LoadURL(msg);
            }
        }


        private void BindingOpsiBOnClick(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Image gambar = (Image)sender;
            if (Soal.GetSoalCollection[0].OpsiB == Soal.GetSoalCollection[0].Jawaban)
            {
                NavigationService.Navigate(new Uri("/PageSoal.xaml?gambar=" + gambar.Tag.ToString(), UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Jawaban anda salah, silahkan ulangi”");
            }
        }

        private void BindingOpsiAOnClick(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Image gambar = (Image)sender;
            if (Soal.GetSoalCollection[0].OpsiA == Soal.GetSoalCollection[0].Jawaban)
            {
                NavigationService.Navigate(new Uri("/pagesoal.xaml?gambar=" + gambar.Tag.ToString(), UriKind.Relative));
            }
            else
            {

                MessageBox.Show("Jawaban anda salah, silahkan ulangi”");
            }
        }

    }
}