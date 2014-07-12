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
        private ObservableCollection<getsoal> getSoalCollection = new ObservableCollection<getsoal>();

        internal ObservableCollection<getsoal> GetSoalCollection
        {
            get { return getSoalCollection; }
            set
            {
                getSoalCollection = value;
            }
        }

        public PageRandomSoal()
        {
            InitializeComponent();
            DataContext = new getsoalViewModel();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //PhoneApplicationService.Current.State["imageBatik"] = bmp;
            // NavigationService.Navigate(new Uri("/PageSoal.xaml", UriKind.Relative));
        }

        private void Ellipse_GotFocus_1(object sender, RoutedEventArgs e)
        {

        }

        private void Ellipse_DoubleTap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Nyorek.xaml", UriKind.Relative));
        }

        private void ContentPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PageSoal.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string msg = "null";
            if (NavigationContext.QueryString.TryGetValue("Level", out msg))
            {
                //MessageBox.Show(msg);
                LoadURL(msg);
            }
        }

        public void LoadURL(String level)
        {
            //MessageBox.Show(level);
            WebClient wcSoalBatik = new WebClient();
            wcSoalBatik.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadSoalBatik);
            wcSoalBatik.DownloadStringAsync(new Uri(Helper.BASE + "getsoal.php?Level=" + level));
        }

        private void DownloadSoalBatik(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                JObject jRoot = JObject.Parse(e.Result);
                //MessageBox.Show(e.Result);
                JArray jItem = JArray.Parse(jRoot.SelectToken("result").ToString());
                foreach (JObject item in jItem)
                {
                    getsoal gs = new getsoal();
                    gs.idSoal = item.SelectToken("idSoal").ToString();
                    gs.Pertanyaan = item.SelectToken("Pertanyaan").ToString();
                    gs.Level = item.SelectToken("Level").ToString();
                    gs.OpsiA = Helper.img_BASE + item.SelectToken("OpsiA").ToString();
                    gs.OpsiB = Helper.img_BASE + item.SelectToken("OpsiB").ToString();
                    gs.Jawaban = item.SelectToken("Jawaban").ToString();

                    GetSoalCollection.Add(gs);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Image_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void OpsiB(object sender, System.Windows.Input.GestureEventArgs e)
        {

            MessageBoxResult result =
                MessageBox.Show("Maaf jawaban yang anda pilih salah, Silahkan memilih level permainan kembali",
                "Pengetahuan Batik", MessageBoxButton.OK);

            if (result == MessageBoxResult.OK)
            {
                NavigationService.Navigate(new Uri("/SetLevel.xaml", UriKind.Relative));
            }

        }

        private void Opsi_A(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Image gambar = (Image)sender;

            NavigationService.Navigate(new Uri("/PageSoal.xaml?gambar=" + gambar.Tag.ToString(), UriKind.Relative));
        }





    }
}