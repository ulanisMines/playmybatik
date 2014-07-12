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
    public partial class SetLevel : PhoneApplicationPage
    {
        public SetLevel()
        {
            InitializeComponent();
        }

       
        private void Button_Sedang(object sender, RoutedEventArgs e)
        {
            Helper.Level = "Medium";
            NavigationService.Navigate(new Uri("/PageRandomSoal.xaml?Level=Medium", UriKind.Relative));
        }

        private void Button_Mudah(object sender, RoutedEventArgs e)
        {
            Helper.Level = "Easy";
            NavigationService.Navigate(new Uri("/PageRandomSoal.xaml?Level=Easy", UriKind.Relative));
        }

        private void Button_Sulit(object sender, RoutedEventArgs e)
        {
            Helper.Level = "Hard";
            NavigationService.Navigate(new Uri("/PageRandomSoal.xaml?Level=Hard", UriKind.Relative));
        }

      

        public string Level { get; set; }
    }
}