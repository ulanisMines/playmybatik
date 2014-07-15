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

        //getsoalViewModel DataContext;
        private getsoalViewModel Soal;
        public PageRandomSoal()
        {
            InitializeComponent();

            Soal = new getsoalViewModel();
            DataContext = Soal;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string msg = "null";
            if (NavigationContext.QueryString.TryGetValue("Level", out msg))
            {
                //MessageBox.Show(msg);
                //LoadURL(msg);
            }
        }

        //public void LoadURL(String level)
        //{
        //    //MessageBox.Show(level);
        //    WebClient wcSoalBatik = new WebClient();
        //    wcSoalBatik.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadSoalBatik);
        //    wcSoalBatik.DownloadStringAsync(new Uri(Helper.BASE + "getsoal.php?Level=" + level));
        //}

        //private void DownloadSoalBatik(object sender, DownloadStringCompletedEventArgs e)
        //{
        //    try
        //    {
        //        JObject jRoot = JObject.Parse(e.Result);
        //        //MessageBox.Show(e.Result);
        //        JArray jItem = JArray.Parse(jRoot.SelectToken("result").ToString());
        //        foreach (JObject item in jItem)
        //        {
        //            getsoal gs = new getsoal();
        //            gs.idSoal = item.SelectToken("idSoal").ToString();
        //            gs.Pertanyaan = item.SelectToken("Pertanyaan").ToString();
        //            gs.Level = item.SelectToken("Level").ToString();
        //            gs.OpsiA = Helper.img_BASE + item.SelectToken("OpsiA").ToString();
        //            gs.OpsiB = Helper.img_BASE + item.SelectToken("OpsiB").ToString();
        //            gs.Jawaban = item.SelectToken("Jawaban").ToString();

        //         //  GetSoalCollection.Add(gs);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void BindingOpsiBOnClick(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Image gambar = (Image) sender;
            if (Soal.GetSoalCollection[0].OpsiB == Soal.GetSoalCollection[0].Jawaban)
            {
                NavigationService.Navigate(new Uri("/PageSoal.xaml?gambar=" + gambar.Tag.ToString(), UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Maaf, jawaban salah.");
            }
        }

        private void BindingOpsiAOnClick(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Image gambar = (Image) sender;
//            if (Soal.GetSoalCollection[0].OpsiA == Soal.GetSoalCollection[0].Jawaban)
//            {
                NavigationService.Navigate(new Uri("/PageSoal.xaml?gambar=" + gambar.Tag.ToString(), UriKind.Relative));
//            }
//            else
//            {
//                MessageBox.Show("Maaf, jawaban salah.");
//            }
        }

    }
}