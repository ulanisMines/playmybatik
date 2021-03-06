﻿using System;
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
    public partial class FinishNembok: PhoneApplicationPage
    {
        public FinishNembok()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string msg = "null";
            if (NavigationContext.QueryString.TryGetValue("score", out msg))
            {
                int score = Convert.ToInt32(msg);
                ScoreNgelowongText.Text = score.ToString();
            }

            base.OnNavigatedTo(e);
        }

       

        private void TapNextMedeli_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MedeliPage.xaml", UriKind.Relative));
        }
    }
}