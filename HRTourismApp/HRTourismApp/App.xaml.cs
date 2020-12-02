using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HRTourismApp.Services;
using HRTourismApp.Views;
using HRTourismApp.Helpers;
using HRTourismApp.Views.Journey;
using HRTourismApp.Models;
using HRTourismApp.Services.GoogleMaps;

namespace HRTourismApp
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static UserDTO User { get; set; }

        public App()
        {
            InitializeComponent();
            GoogleMapsApiService.Initialize(Services.GoogleMaps.Constants.GoogleMapsApiKey);

            if (App.IsUserLoggedIn == true)
                MainPage = new NavigationPage(new MainMenu());
            else
                MainPage = new NavigationPage(new LoginPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
