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

namespace Ngebatik
{
    public partial class ViewBelajar : PhoneApplicationPage
    {
      
            public ViewBelajar()
            {
                InitializeComponent();
                DataContext = new getFilosofiViewModel();
            }

            private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
            {

            }

            private void Button_Click_1(object sender, RoutedEventArgs e)
            {

            }
       
    }
}