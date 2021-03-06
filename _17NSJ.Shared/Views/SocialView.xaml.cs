﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using _17NSJ.Constants;
using _17NSJ.Models;
using Microsoft.AppCenter.Analytics;
using Xamarin.Forms;

namespace _17NSJ.Views
{
    public partial class SocialView : ContentPage
    {
        public SocialView()
        {
            // トラッキングコード
            Analytics.TrackEvent("View", new Dictionary<string, string> { { "View", "SocialView" } });

            InitializeComponent();
            this.socialList.ItemsSource = SocialList.List;
        }

        void ItemSelected(object sender, ItemTappedEventArgs e)
        {
            this.socialList.SelectedItem = null;
            var item = e.Item as SocialModel;

            if(item != null)
            {
                Device.OpenUri(new Uri(item.Url));
            }
        }

        protected override bool OnBackButtonPressed()
        {
            var p = this.Parent.Parent as MasterDetailView;

            if (p != null)
            {
                p.Detail = new TopView();
            }

            return true;
        }
    }
}
