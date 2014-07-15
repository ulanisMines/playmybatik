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
    public partial class FinishNgelowong : PhoneApplicationPage
    {
        int score;
        public FinishNgelowong()
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
            //var rootFrame = (App.Current as App).RootFrame;
            //rootFrame.Navigate(new System.Uri("/NembokPage.xaml", UriKind.Relative));

            NavigationService.Navigate(new Uri("/NembokPage.xaml", UriKind.Relative));
        }
    }
}