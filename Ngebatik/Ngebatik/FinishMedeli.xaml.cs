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
    public partial class FinishMedeli: PhoneApplicationPage
    {
        int score;
        public FinishMedeli()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            base.OnNavigatedTo(e);

            string msg = "null";
            if (NavigationContext.QueryString.TryGetValue("score", out msg))
            {
                score = Convert.ToInt32(msg);
                ScoreNgelowongText.Text = score.ToString();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           

            NavigationService.Navigate(new Uri("/NgelorodPage.xaml", UriKind.Relative));
        }
    }
}