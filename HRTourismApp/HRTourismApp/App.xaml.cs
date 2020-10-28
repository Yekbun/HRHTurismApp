using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HRTourismApp.Services;
using HRTourismApp.Views;
using HRTourismApp.Helpers;
using HRTourismApp.Views.Journey;

namespace HRTourismApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
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
