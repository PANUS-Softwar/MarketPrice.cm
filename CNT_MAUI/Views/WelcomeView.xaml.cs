using System;
using Microsoft.Maui.Controls;

namespace CNT_MAUI.Views
{
    public partial class WelcomeView : ContentPage
    {
        public WelcomeView()
        {
            InitializeComponent();
        }

        private void GetStartedClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//HomeView");
        }
    }
}