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
    public partial class KontenAlatBatik : PhoneApplicationPage
    {
        public int index;
        public KontenAlatBatik()
        {
            InitializeComponent();
           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string msg = null;
            if (NavigationContext.QueryString.TryGetValue("index", out msg))
            {
               int index = Convert.ToInt32(msg);
                if (index == 1)
                {
                    BitmapImage bm = new BitmapImage(new Uri(@"PeralatanBatik/gawangan.png", UriKind.RelativeOrAbsolute));
                    ImageBatik.Source = bm;
                    KontentBatik.TextWrapping = TextWrapping.Wrap;
                    KontentBatik.Text = "Gawangan adalah perkakas untuk menyangkutkan dan membentangkan mori sewaktu dibatik. Gawangan terbuat dari kayu atau bambu. Gawangan harus dibuat sedemikian rupa hingga kuat, ringan, dan mudah  dipindah-pindah";
                   
                }
                if (index == 2)
                {
                    BitmapImage bm = new BitmapImage(new Uri(@"PeralatanBatik/wajan.png", UriKind.RelativeOrAbsolute));
                    ImageBatik.Source = bm;
                    KontentBatik.TextWrapping = TextWrapping.Wrap;
                    KontentBatik.Text = "Wajan adalah perkakas untuk mencairkan malam, dibuat dari logam baja atau tanah liat. Wajan sebaiknya bertangkai supaya mudah diangkat dan diturunkan dari perapian tanpa menggunakan alat lain.  ";
                }
                if (index == 3)
                {
                    BitmapImage bm = new BitmapImage(new Uri(@"PeralatanBatik/dhingklik.png", UriKind.RelativeOrAbsolute));
                    ImageBatik.Source = bm;
                    KontentBatik.TextWrapping = TextWrapping.Wrap;
                    KontentBatik.Text = "Dhingklik (Tempat Duduk) adalah tempat duduk pembatik. Biasanya terbuat dari bambu, kayu, plastik atau besi.";
                }
                if (index == 4)
                {
                    BitmapImage bm = new BitmapImage(new Uri(@"PeralatanBatik/Canting.png", UriKind.RelativeOrAbsolute));
                    ImageBatik.Source = bm;

                    KontentBatik.Text = "Canting adalah alat yang dipakai untuk memindahkan atau mengambil cairan, terbuat dari tembaga dan bambu sebagai pegangannya.  Canting digunakan untuk menuliskan pola batik dengan cairan malam. ";
                }
                if (index == 5)
                {
                    BitmapImage bm = new BitmapImage(new Uri(@"PeralatanBatik/Kompor.png", UriKind.RelativeOrAbsolute));
                    ImageBatik.Source = bm;
                    KontentBatik.TextWrapping = TextWrapping.Wrap;
                    KontentBatik.Text = "Kompor adalah alat yang digunakan untuk mencairkan malam. Biasanya kompor yang digunakan kompor berbahan minyak , dengan intensitas gas kecil";
                }
                if (index == 6)
                {
                    BitmapImage bm = new BitmapImage(new Uri(@"PeralatanBatik", UriKind.RelativeOrAbsolute));
                    ImageBatik.Source = bm;
                    KontentBatik.TextWrapping = TextWrapping.Wrap;
                    KontentBatik.Text = "Taplak adalah kain untuk menutup paha si pembatik agar tidak terkena tetesan malam panas sewaktu canting ditiup atau waktu membatik";
                }
                if (index == 7)
                { 
                     BitmapImage bm = new BitmapImage(new Uri(@"PeralatanBatik/mori.png", UriKind.RelativeOrAbsolute));
                    ImageBatik.Source = bm;
                    KontentBatik.TextWrapping = TextWrapping.Wrap;
                    KontentBatik.Text = "Mori adalah bahan baku yang terbuat dari katun. Kualitas mori bermacam-macam dan jenisnya sangat mennetukan baik buruknya kain batik yang dihasilkan. Mori yang dibutuhkan disesuaikan dengan panjang pendeknya kainyang diinginkan";
                }
                if (index == 8)
                {
                    BitmapImage bm = new BitmapImage(new Uri(@"PeralatanBatik/bandul.png", UriKind.RelativeOrAbsolute));
                    ImageBatik.Source = bm;
                    KontentBatik.TextWrapping = TextWrapping.Wrap;
                    KontentBatik.Text = "Bandul adalah alat yang digunakan untuk menahan kain mori yang dibatik agar tidak muudah tergeser saat tertiup angin atau tertarik oleh pembatik secara tidak sengaja. Bandul biasanya terbuat dari timah, kayu atau batu yang dimasukan kedalam kantong";
                }
                if (index == 9)
                {
                    BitmapImage bm = new BitmapImage(new Uri(@"PeralatanBatik/Pewarnaalami.png", UriKind.RelativeOrAbsolute));
                    ImageBatik.Source = bm;
                    KontentBatik.TextWrapping = TextWrapping.Wrap;
                    KontentBatik.Text = "Pewarna Alami adalah pewarna yang digunakan untuk membatik. Dengan mnggunakna pewarna alami hasil warna lebih khas dibandingkan dengan pewarna buatan";
                }
                if (index == 10)
                {
                    BitmapImage bm = new BitmapImage(new Uri(@"Soal/batik soal 1.jpg", UriKind.RelativeOrAbsolute));
                    ImageBatik.Source = bm;
                    KontentBatik.TextWrapping = TextWrapping.Wrap;
                    KontentBatik.Text = "Saringan Malam adalah alat untuk menyaring malam panas yang memiliki banyak kotoran. Jika malam tidak disaring, kotoran dapat mengganggu aliran malam pada ujung canting.";
                }
                if (index == 11)
                {
                    BitmapImage bm = new BitmapImage(new Uri(@"PeralatanBatik/lilin.png", UriKind.RelativeOrAbsolute));
                    ImageBatik.Source = bm;
                    KontentBatik.TextWrapping = TextWrapping.Wrap;
                    KontentBatik.Text = " Malam (Lilin) adalah bahan yang digunakan untuk  membatik. Malam yang digunakan bersifat cepat diserap kain, tetapi dapat dengan mudah lepas ketika proses pelorodan";
                }
             
            }

            base.OnNavigatedTo(e);
        }

        
    }
}