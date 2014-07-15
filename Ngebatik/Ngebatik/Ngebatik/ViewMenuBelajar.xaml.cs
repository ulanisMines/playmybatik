using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Ngebatik
{
    public partial class ViewMenuBelajar : PhoneApplicationPage
    {
        public ViewMenuBelajar()
        {
            InitializeComponent();
        }

        private void FilosofiBatik_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewBelajar.xaml", UriKind.Relative));
        }

        private void PeralatanBatik_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewPeralatanBatik.xaml", UriKind.Relative));
        }
    }
}