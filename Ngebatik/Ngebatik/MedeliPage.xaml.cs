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
using GestureEventArgs = System.Windows.Input.GestureEventArgs;


namespace Ngebatik
{
    public partial class MedeliPage : PhoneApplicationPage
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
        int waktubermain = 60;
        Boolean kuasBasah = false;
        Boolean lihatBatikAsli = false;
        public static int scoreMedeli;
        private Random _rand = new Random();
        private Boolean selectedcolor1;

        private Brush selectedColor = new SolidColorBrush(Colors.Black);


        public MedeliPage()
        {
            isFirstTap = true;
            try
            {
                InitializeComponent();
                Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
                dt.Interval = TimeSpan.FromSeconds(1);
                ds.Interval = TimeSpan.FromSeconds(1);
                dt.Tick += dt_Tick;
                ds.Tick += ds_Tick;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ds_Tick(object sender, EventArgs e)
        {
            detikBermain++;
            //WaktuBermainText.Text = (waktubermain - detikBermain).ToString();
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
            //waktuBasahKuasText.Text = (waktuBasahKuas - detikCanting).ToString();
            if (detikCanting == waktuBasahKuas)
            {
                detikCanting = 0;
                kuasBasah = false;
                dt.Stop();
            }


        }

        private void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {

            if (kuasBasah && !selectedcolor1)
            {
                selectedcolor1 = true;
                canvasGambarBatik.Background = selectedColor;
            }

            scoreNgelowongText.Text = scoreMedeli.ToString();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string msg;



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

                        SetPikselCitra(x, y, (byte) a, grayScale, grayScale, grayScale);
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
                MessageBox.Show("Nyorek" + ez.Message);
            }

            foreach (Line oldLine in Helper.hasilNembok)
            {
                Line line = new Line();

                line.X1 = oldLine.X1;
                line.Y1 = oldLine.Y1;
                line.X2 = oldLine.X2;
                line.Y2 = oldLine.Y2;
                line.Stroke = oldLine.Stroke;
                line.Fill = oldLine.Fill;
                line.StrokeThickness = oldLine.StrokeThickness;

                canvasGambarBatik.Children.Add(line);
            }
            base.OnNavigatedTo(e);
        }

        private Color ConvertHexStringToColour(string hexString)
        {
            byte a = 0xff;
            byte r = 0;
            byte g = 0;
            byte b = 0;
            if (hexString.StartsWith("#"))
            {
                hexString = hexString.Substring(1);
            }
            r = Convert.ToByte(Int32.Parse(hexString.Substring(0, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            g = Convert.ToByte(Int32.Parse(hexString.Substring(2, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            b = Convert.ToByte(Int32.Parse(hexString.Substring(4, 2),
                System.Globalization.NumberStyles.AllowHexSpecifier));
            return Color.FromArgb(a, r, g, b);
        }


        public void LoadURL()
        {

            getfilosofi gf = Helper.hasilDownload;

            if (gf.Warna1 == null || !gf.Warna1.StartsWith("#"))
            {
                Warna1El.Visibility = Visibility.Collapsed;
                // Warna1.Visibility = Visibility.Collapsed;
            }
            else
            {
                String strColour = gf.Warna1;
                Color myColour = ConvertHexStringToColour(strColour);
                Warna1El.Fill = new SolidColorBrush(myColour);
            }

            if (gf.Warna2 == null || !gf.Warna2.StartsWith("#"))
            {
                Warna2El.Visibility = Visibility.Collapsed;
            }
            else
            {
                String strColour = gf.Warna2;
                Color myColour = ConvertHexStringToColour(strColour);
                Warna2El.Fill = new SolidColorBrush(myColour);
            }

            if (gf.Warna3 == null || !gf.Warna3.StartsWith("#"))
            {
                Warna3El.Visibility = Visibility.Collapsed;
            }
            else
            {
                String strColour = gf.Warna3;
                Color myColour = ConvertHexStringToColour(strColour);
                Warna3El.Fill = new SolidColorBrush(myColour);
            }

            if (gf.Warna4 == null || !gf.Warna4.StartsWith("#"))
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
        private void DownloadFilosofiBatik(object sender, DownloadStringCompletedEventArgs e)
        {


        }
        public void SetPikselCitra(int x, int y, byte alpha, int r, int g, int b)
        {
            float ai = alpha * PreMultiplyFactor;
            wbEdited.Pixels[(y * width) + x] = (alpha << 24) | ((byte) (r * ai) << 16) |
                ((byte) (g * ai) << 8) | (byte) (b * ai);
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

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/FinishMedeli.xaml?score=" + scoreMedeli, UriKind.Relative));
            btnselesai.Visibility = Visibility.Collapsed;
        }

        private void Warna1El_OnTap(object sender, GestureEventArgs e)
        {
            if (isFirstTap)
            {
                ds.Start();
                isFirstTap = false;
            }
            // var imagePen = (CompositeTransform) penBatik.RenderTransform;
            // imagePen.TranslateX = pointCollection[i].Position.X + 100;
            //imagePen.TranslateY = pointCollection[i].Position.Y - 290;
            selectedColor = ((Ellipse) sender).Fill;
            waktuBasahKuas = _rand.Next(7, 15);
            kuasBasah = true;

            detikCanting = 0;

            if (!dt.IsEnabled)
            {
                dt.Start();
            }

        }
    }
}