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
    public partial class FinishNgelorod: PhoneApplicationPage
    {
        public FinishNgelorod()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ScoreAllGameText.Text = (NyorekPage.scoreNyorek + NembokPage.scoreNembok + MedeliPage.scoreMedeli).ToString();
            base.OnNavigatedTo(e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/NgelorodPage.xaml", UriKind.Relative));
        }
    }
}