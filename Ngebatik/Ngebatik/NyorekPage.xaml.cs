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
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Threading;
using System.Threading;
using Ngebatik.Kelas;
using Newtonsoft.Json.Linq;
using System.Globalization;


namespace Ngebatik
{
    public partial class NyorekPage : PhoneApplicationPage
    {
        private const float PreMultiplyFactor = 1 / 255f;
        private bool isFirstTap;
        const int width = 400;
        const int height = 280;
        WriteableBitmap wbEdited, wbHasilSobel;
        BitmapImage bmpBatik;
        //Kelas.Sobel sobelOperator = new Kelas.Sobel();

        double[] preXArray = new double[10];
        double[] preYArray = new double[10];

        DispatcherTimer dt = new DispatcherTimer();
        DispatcherTimer ds = new DispatcherTimer();
        int detikCanting = 0;
        int detikBermain = 0;
        int waktuBasahKuas;
        int waktubermain=10;
        Boolean kuasBasah = false;
        Boolean lihatBatikAsli = false;
        int score=0;


        public NyorekPage()
        {
            isFirstTap = true;
            try
            {
                InitializeComponent();
                Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
                dt.Interval = TimeSpan.FromSeconds(1);
                ds.Interval = TimeSpan.FromSeconds(1);
                dt.Tick += dt_Tick;
                ds.Tick +=ds_Tick;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ds_Tick(object sender, EventArgs e)
        {
            detikBermain++;
            WaktuBermainText.Text = (waktubermain - detikBermain).ToString();
            ds.Start();
            
            if (waktubermain == detikBermain)
            {
                detikBermain = 0;
                ds.Stop();
                btnselesai.Visibility = Visibility.Visible;
            }

        }

        private void SetPanahKebawah()
        {
            BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Asset/panah bawah.png", UriKind.RelativeOrAbsolute));
            this.panahImage.Source = bmp;
        }

        private void SetPanahKeatas()
        {
            BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Asset/panah atas.png", UriKind.RelativeOrAbsolute));
            this.panahImage.Source = bmp;
        }

        
        private void dt_Tick(object sender, EventArgs e)
        {
            detikCanting++;  
                waktuBasahKuasText.Text = (waktuBasahKuas - detikCanting).ToString();
                if (detikCanting == waktuBasahKuas)
                {
                    detikCanting = 0;
                    kuasBasah = false;
                    dt.Stop();
                }

             
        }

        private void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
           
            int pointsNumber = e.GetTouchPoints(canvasGambarBatik).Count;
            TouchPointCollection pointCollection = e.GetTouchPoints(canvasGambarBatik);
            var imagePen = (CompositeTransform)penBatik.RenderTransform;

             if (kuasBasah)
            {
                for (int i = 0; i < pointsNumber; i++)
                {
                    score++;
                    if (pointCollection[i].Action == TouchAction.Down)
                    {
                        if ((pointCollection[i].Position.X > 29) && (pointCollection[i].Position.X < 555))
                        {
                            preXArray[i] = pointCollection[i].Position.X - 30;
                            preYArray[i] = pointCollection[i].Position.Y - 55;
                            imagePen.TranslateX = pointCollection[i].Position.X + 100;
                            imagePen.TranslateY = pointCollection[i].Position.Y - 290;
                        }
                    }
                    if (pointCollection[i].Action == TouchAction.Move)
                    {
                        if ((pointCollection[i].Position.X > 29) && (pointCollection[i].Position.X < 555))
                        {
                            Line line = new Line();

                            line.X1 = preXArray[i];
                            line.Y1 = preYArray[i];
                            line.X2 = pointCollection[i].Position.X - 30;
                            line.Y2 = pointCollection[i].Position.Y - 55;

                            imagePen.TranslateX = pointCollection[i].Position.X + 100;
                            imagePen.TranslateY = pointCollection[i].Position.Y - 290;

                            line.Stroke = new SolidColorBrush(Colors.Red);
                            line.Fill = new SolidColorBrush(Colors.Red);
                            line.StrokeThickness = 4.0;
                            canvasGambarBatik.Children.Add(line);

                            preXArray[i] = pointCollection[i].Position.X - 30;
                            preYArray[i] = pointCollection[i].Position.Y - 55;
                        }
                    }
                }
            }
             scoreNgelowongText.Text = score.ToString();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
          string msg;
          
            //if (NavigationContext.QueryString.TryGetValue("gambar", out msg))
            //{
            //    MessageBox.Show(msg);
            //   bitmapGet = new System.Windows.Media.Imaging.BitmapImage(new Uri(msg, UriKind.Absolute));
            //   imageBatik.Source =  bitmapGet;
            //   bmpBatik = (BitmapImage)imageBatik.Source;
               
            //}


            try
            {
                BitmapImage bitmapGet = Navigation.Bmp;
                    //PhoneApplicationService.Current.State["imageBatik"] as BitmapImage;
                System.Windows.Media.Imaging.WriteableBitmap wb = new System.Windows.Media.Imaging.WriteableBitmap(bitmapGet);
                wbEdited = new System.Windows.Media.Imaging.WriteableBitmap(width, height);
                wbHasilSobel = new System.Windows.Media.Imaging.WriteableBitmap(width, height);
                int[] rgb = wb.Pixels;
                int grayScale, a, r, g, b;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        a = rgb[(y * width) + x] >> 24;
                        r = (rgb[(y * width) + x] & 0x00ff0000) >> 16;
                        g = (rgb[(y * width) + x] & 0x0000ff00) >> 8;
                        b = (rgb[(y * width) + x] & 0x000000ff);

                        grayScale = (r + g + b) / 3;

                        SetPikselCitra(x, y, (byte)a, grayScale, grayScale, grayScale);
                    }
                }

                Kelas.Sobel sobelOperator = new Kelas.Sobel();
                wbHasilSobel = sobelOperator.CitraSobel(wbEdited);

                imagePolaBatik.Source = wbHasilSobel;
                this.imageBatik.Source = bitmapGet;

                LoadURL();
                
                   
            
            }
            catch (Exception ez)
            {
                MessageBox.Show("Nyorek"+ez.Message);
            }

            base.OnNavigatedTo(e);
        }

        private Color ConvertHexStringToColour(string hexString)
        {
            byte a = 0;
            byte r = 0;
            byte g = 0;
            byte b = 0;
            if (hexString.StartsWith("#"))
            {
                hexString = hexString.Substring(1, 8);
            }
            a = Convert.ToByte(Int32.Parse(hexString.Substring(0, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            r = Convert.ToByte(Int32.Parse(hexString.Substring(2, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            g = Convert.ToByte(Int32.Parse(hexString.Substring(4, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            b = Convert.ToByte(Int32.Parse(hexString.Substring(6, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
            return Color.FromArgb(a, r, g, b);
        }


        public void LoadURL()
        {
            MessageBox.Show("LoadURL"+Helper.BASE + "getfilosofi.php?GambarBatik=" + Helper.GambarBatik);

            WebClient wcSoalBatik = new WebClient();
            wcSoalBatik.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadFilosofiBatik);
            wcSoalBatik.DownloadStringAsync(new Uri(Helper.BASE + "getfilosofi.php?GambarBatik=" + Helper.GambarBatik));
        }
          private void DownloadFilosofiBatik(object sender, DownloadStringCompletedEventArgs e)
        {

            MessageBox.Show(e.Result);
            JObject jRoot = JObject.Parse(e.Result);
            JArray jItem = JArray.Parse(jRoot.SelectToken("result").ToString());
            getfilosofi gf = new getfilosofi();
            foreach (JObject item in jItem)
            {
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

                MessageBox.Show(item.ToString());
            }

             if (gf.Warna1 == null)
            {
                Warna1El.Visibility = Visibility.Collapsed;
                // Warna1.Visibility = Visibility.Collapsed;
            }
            else
            {
                String strColour =gf.Warna1;
                Color myColour = ConvertHexStringToColour(strColour);
                Warna1El.Fill = new SolidColorBrush(myColour);
             }

            if (gf.Warna2== null)
            {
                Warna2El.Visibility = Visibility.Collapsed;
            }
            else
            {
                String strColour = gf.Warna2;
                Color myColour = ConvertHexStringToColour(strColour);
                Warna2El.Fill = new SolidColorBrush(myColour);
            }
            if (gf.Warna3 == null)
            {
                Warna3El.Visibility = Visibility.Collapsed;
            }
            else
            {
                String strColour = gf.Warna3;
                Color myColour = ConvertHexStringToColour(strColour);
                Warna3El.Fill = new SolidColorBrush(myColour);
            }
            if (gf.Warna4 == null)
            {
                Warna4El.Visibility = Visibility.Collapsed;
            }
            else
            {
                String strColour = gf.Warna4;
                Color myColour = ConvertHexStringToColour(strColour);
                Warna4El.Fill = new SolidColorBrush(myColour);
            }
        }
        public void SetPikselCitra(int x, int y, byte alpha, int r, int g, int b)
        {
            float ai = alpha * PreMultiplyFactor;
            wbEdited.Pixels[(y * width) + x] = (alpha << 24) | ((byte)(r * ai) << 16) |
                ((byte)(g * ai) << 8) | (byte)(b * ai);
        }

        private void Pot_Tapped(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
        {
            //if (!kuasBasah)
            //{
            //    Random rand = new Random();
            //    waktuBasahKuas = rand.Next(7, 15);
            //    kuasBasah = true;
            //    dt.Start();
            //}
        }

        private void Pen_Drag(object sender, ManipulationDeltaEventArgs e)
        {
            
        }

        private void Panah_Tapped(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
        {
            //if (!lihatBatikAsli)
            //{
            //    SetPanahKeatas();
            //    SlideDownBatik_Animated.Begin();
            //    lihatBatikAsli = true;
            //}
            //else
            //{
            //    SetPanahKebawah();
            //    BatikSlideUp_Animated.Begin();
            //    lihatBatikAsli = false;
            //}
        }

        private void panahImage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
            if (!lihatBatikAsli)
            {
                SetPanahKeatas();
                SlideDownBatik_Animated.Begin();
                lihatBatikAsli = true;
            }
            else
            {
                SetPanahKebawah();
                BatikSlideUp_Animated.Begin();
                lihatBatikAsli = false;
            }
        }


        private void Image_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (isFirstTap)
            {
                ds.Start();
                isFirstTap = false;
            }

            if (!kuasBasah)
            {
                Random rand = new Random();
                waktuBasahKuas = rand.Next(7, 15);
                kuasBasah = true;
                dt.Start();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new Uri("/FinishNgelowong.xaml?score="+score, UriKind.Relative));
            btnselesai.Visibility = Visibility.Collapsed;
        }
    }
}