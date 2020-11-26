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

#if DEBUG           

            App.User = new UserDTO { Id = 55, CompanyId = 8, CompanyName = "Firma 4 Yolcu Tasimacili", Email = "olcayyf @hotmail.com", NameSurname = "Feryat Olcay", Phone = "05378217440", RoleId = 1 };
            App.IsUserLoggedIn = true;
#else
            MainPage = new NavigationPage(new LoginPage());

#endif
            MainPage = new NavigationPage(new MainMenu());

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
