using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Ngebatik
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool isOpen;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            isOpen = false;
            Idle.Begin();
        }

        private void MainNgebatik(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SetLevel.xaml", UriKind.Relative));
        }

       
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            if (isOpen)
                CloseSetting.Begin();
            else
            {
                OpenSetting.Begin();
            }
            isOpen = !isOpen;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewHelp.xaml", UriKind.Relative));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewMenuBelajar.xaml", UriKind.Relative));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewInfo.xaml", UriKind.Relative));
        }
    }
}