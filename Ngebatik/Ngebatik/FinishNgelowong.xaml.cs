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
        public FinishNgelowong()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string msg = null;
            if (NavigationContext.QueryString.TryGetValue("score", out msg))
            {
                int score = Convert.ToInt32(msg);
                ScoreNgelowongText.Text = score.ToString();
            }

            base.OnNavigatedTo(e);
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{

        //}

        private void TapNextNembok(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/NembokPage.xaml", UriKind.Relative));
        }
    }
}