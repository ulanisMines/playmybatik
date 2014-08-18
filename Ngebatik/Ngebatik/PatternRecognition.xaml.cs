using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;


namespace Ngebatik
{
    public partial class PatternRecognition: PhoneApplicationPage
    {
        System.Windows.Media.Imaging.BitmapImage bmp;
        string imbatik;
        int totalKesamaan = 0;
        double nilaiKesamaan;
        public PatternRecognition()
        {
            InitializeComponent();
        }

        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Rectangle rect = new Rectangle();
            rect.Height = 326;
            rect.Width = 521;
            rect.Fill = Helper.selectedColor;
            canvasGambarBatik.Children.Add(rect);

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

            WriteableBitmap wb = new WriteableBitmap(canvasGambarBatik, null);

            bmp = Helper.TrueGambarBatik;
            ImageSistem.Source = bmp;

            WriteableBitmap wp = new WriteableBitmap(bmp);

            for (int y = 0; y < wp.PixelHeight; y++)
            {
                for (int x = 0; x < wp.PixelWidth; x++)
                {
                    //dapetin nilai rgb dari gambarBatik1
                    byte[] colorArray1 = BitConverter.GetBytes(wp.Pixels[(x * y) + x]);
                    byte blue1 = colorArray1[0];
                    byte green1 = colorArray1[1];
                    byte red1 = colorArray1[2];

                    //dapetin nilai rgb dari gambarBatik2
                    byte[] colorArray2 = BitConverter.GetBytes(wb.Pixels[(x * y) + x]);
                    byte blue2 = colorArray2[0];
                    byte green2 = colorArray2[1];
                    byte red2 = colorArray2[2];

                    //Bandingkan rgb keduanya, jika sama maka totalkesamaan = totalkesamaan + 1
                    if ((blue1 == blue2) && (green1 == green2) && (red1 == red2))
                    {
                        totalKesamaan++;
                    }
                }
            }

            //itung persentase kesamaan caranya totalKesamaan dibagi ukuran resolusi gambar
            nilaiKesamaan = (double)totalKesamaan / (double)(wp.PixelHeight * wp.PixelWidth) * 100;

            //tampilkan persentase
            // hasilKesamaanStackPanel.Visibility = System.Windows.Visibility.Visible;
            HasilPattern.Text = nilaiKesamaan.ToString() + " persen";
            base.OnNavigatedTo(e);
        
        }

       
            

        private void TapNextNglorod_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}