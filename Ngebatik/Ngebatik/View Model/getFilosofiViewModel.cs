using Newtonsoft.Json.Linq;
using Ngebatik.Kelas;
using PlayMyBatik.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ngebatik.View_Model
{
     public class getFilosofiViewModel : ViewModelBase
    {
        private ObservableCollection<getfilosofi> getFilosofiCollection = new ObservableCollection<getfilosofi>();

        public ObservableCollection<getfilosofi> GetFilosofiCollection
        {
            get { return getFilosofiCollection; }
            set { getFilosofiCollection = value;
            RaisePropertyChanged("GetFilosofiCollection");
            }

        }

        public getFilosofiViewModel()
        {
           
            LoadURL();

        }

        public void LoadURL()
        {
            WebClient wcFilosofiBatik = new WebClient();
            wcFilosofiBatik.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadFilosofiBatik);
            wcFilosofiBatik.DownloadStringAsync(new Uri(Helper.BASE+"getfilosofi.php"));
            
        }

        private void DownloadFilosofiBatik(object sender, DownloadStringCompletedEventArgs e)
        {
            JObject jRoot = JObject.Parse(e.Result);
            JArray jItem = JArray.Parse(jRoot.SelectToken("result").ToString());

            var data = new ObservableCollection<getfilosofi>();

            foreach (JObject item in jItem)
            {
                getfilosofi gf = new getfilosofi();
                gf.idBatik = item.SelectToken("idBatik").ToString();
                gf.NamaBatik = item.SelectToken("NamaBatik").ToString();
                gf.GambarBatik = Helper.img_BASE + item.SelectToken("GambarBatik").ToString();
                gf.Filosofi = item.SelectToken("Filosofi").ToString();
                gf.idDaerah = item.SelectToken("idDaerah").ToString();
                gf.idJenis = item.SelectToken("idJenis").ToString();
                gf.Warna1 = item.SelectToken("Warna1").ToString();
                gf.Warna2 = item.SelectToken("Warna2").ToString();
                gf.Warna3 = item.SelectToken("Warna3").ToString();
                gf.Warna4 = item.SelectToken("Warna4").ToString();
                data.Add(gf);
            }

            GetFilosofiCollection = data;
        }

       /* public void LoadUrlItem2()
        {
            WebClient wcFilosofiBatik2 = new WebClient();
            wcFilosofiBatik2.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadFilosofiBatik2);
            wcFilosofiBatik2.DownloadStringAsync(new Uri(Helper.BASE + "getfilosofi.php"));
        }

        public void DownloadFilosofiBatik2()
        {
            MessageBox.Show(e.Result);
            JObject jRoot = JObject.Parse(e.Result);
            JArray jItem = JArray.Parse(jRoot.SelectToken("result").ToString());
            foreach (JObject item in jItem)
            {
                getfilosofi gf = new getfilosofi();
                gf.idBatik = item.SelectToken("idBatik").ToString();
                gf.NamaBatik = item.SelectToken("NamaBatik").ToString();
                gf.GambarBatik = Helper.img_BASE + item.SelectToken("GambarBatik").ToString();
                gf.Filosofi = item.SelectToken("Filosofi").ToString();
                gf.idDaerah = item.SelectToken("idDaerah").ToString();
                gf.idJenis = item.SelectToken("idJenis").ToString();
                gf.Warna1 = item.SelectToken("Warna1").ToString();
                gf.Warna2 = item.SelectToken("Warna2").ToString();
                gf.Warna3 = item.SelectToken("Warna3").ToString();
                gf.Warna4 = item.SelectToken("Warna4").ToString();
                GetFilosofiCollection.Add(gf);
            }
        }
        * */

        }
    }

