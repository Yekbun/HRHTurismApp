using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HRTourismApp.Services;
using HRTourismApp.Views;
using HRTourismApp.Helpers;
using HRTourismApp.Views.Journey;
using HRTourismApp.Models;

namespace HRTourismApp
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static UserDTO User { get; set; }

        public App()
        {
            InitializeComponent();
            // MainPage = new NavigationPage(new LoginPage());

            App.User = new UserDTO { Id = 55, CompanyId = 8, CompanyName = "Firma 4 Yolcu Tasimacili", Email = "olcayyf @hotmail.com", NameSurname = "Feryat Olcay", Phone = "05378217440", RoleId = 1 };
            App.IsUserLoggedIn = true;
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
