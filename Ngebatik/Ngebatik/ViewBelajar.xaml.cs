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
        

            public ViewBelajar()
            {
                InitializeComponent();
                //DataContext = new getFilosofiViewModel();
                BindingData = new getFilosofiViewModel();
                BindingData.PropertyChanged += BindingData_PropertyChanged;

                
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