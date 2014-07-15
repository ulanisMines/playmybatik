using PlayMyBatik.Common;
using Newtonsoft.Json.Linq;
using Ngebatik.Kelas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace Ngebatik.View_Model
{
    public class getsoalViewModel : ViewModelBase
    {
        private ObservableCollection<getsoal> getSoalCollection = new ObservableCollection<getsoal>();
        private String opsiA;
        private String opsiB;
        private String pertanyaan;
        private string jawaban;

        public String Pertanyaan
        {
            get { return pertanyaan; }
            set
            {
                pertanyaan = value;
                RaisePropertyChanged("");
            }
        }

        public String OpsiB
        {
            get { return opsiB; }
            set
            {
                opsiB = value;
                RaisePropertyChanged("");
            }
        }
        private int listIndex = -1;

        public String OpsiA
        {
            get { return opsiA; }
            set
            {
                opsiA = value;
                RaisePropertyChanged("");
            }
        }

        public String Jawaban
        {
            get { return jawaban; }
            set
            {
                jawaban = value;
                RaisePropertyChanged("Jawaban");
            }
        }

        public ObservableCollection<getsoal> GetSoalCollection
        {
            get { return getSoalCollection; }
            set
            {
                getSoalCollection = value;
                RaisePropertyChanged("");
            }
        }

        

        public getsoalViewModel()
        {
            LoadURL();
        }

        public void LoadURL()
        {
            WebClient wcSoalBatik = new WebClient();
            wcSoalBatik.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadSoalBatik);
            wcSoalBatik.DownloadStringAsync(new Uri(Helper.BASE + "getsoal.php?Level=" + Helper.Level));
        }

        private void DownloadSoalBatik(object sender, DownloadStringCompletedEventArgs e)
        {
            JObject jRoot = JObject.Parse(e.Result);
            JArray jItem = JArray.Parse(jRoot.SelectToken("result").ToString());
            foreach (JObject item in jItem)
            {
                getsoal gs = new getsoal();
                gs.idSoal = item.SelectToken("idSoal").ToString();
                Pertanyaan = item.SelectToken("Pertanyaan").ToString();
                gs.Level = item.SelectToken("Level").ToString();
                OpsiA = Helper.img_BASE + item.SelectToken("OpsiA").ToString();
                OpsiB = Helper.img_BASE + item.SelectToken("OpsiB").ToString();
                gs.Jawaban = item.SelectToken("Jawaban").ToString();

                GetSoalCollection.Add(gs);
            }
        }
        #region soal

        public int ListIndex
        {
            get { return listIndex; }
            set
            {
                if (listIndex != value)
                    listIndex = value;
                RaisePropertyChanged("");
            }
        }

        public ICommand SetGetSoalCommand
        {
            get
            {
                return new DelegateCommand(SetSoalId, CanSetSoalId);
            }
        }

        private bool CanSetSoalId(object arg)
        {
            return true;
        }

        private void SetSoalId(object obj)
        {
            getsoal selectedItemData = obj as getsoal;

            if (selectedItemData != null)
                Navigation.Id = selectedItemData.idSoal;

            listIndex = -1;
        }

        #endregion soal
    }
}
