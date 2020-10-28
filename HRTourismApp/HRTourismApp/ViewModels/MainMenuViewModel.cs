using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using HRTourismApp.Views.Journey;
using HRTourismApp.Views.TakePicture;

namespace HRTourismApp.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        public void btnBooking_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MediaPage());
        }

        public void btnJourney_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new JourneyListPage());
        }
        /*
        public void launchsettings(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new ItemDetailPage());
        }

        public void launchshnotes(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new AboutPage());
        }*/
    }
}