using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using HRTourismApp.Views.Journey;
using HRTourismApp.Views.TakePicture;
using HRTourismApp.Views.Settings;
using HRTourismApp.Helpers;

namespace HRTourismApp.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string RoleName { get; set; }
        public async void btnBooking_clicked(object sender, EventArgs e)
        {
           await NavigationHelper.PushAsyncSingle(new MediaPage());
        }

        public async void btnJourney_clicked(object sender, EventArgs e)
        {
            await NavigationHelper.PushAsyncSingle(new JourneyListPage());
        }
        
        public async void btnSettings_clicked(object sender, EventArgs e)
        {
            await NavigationHelper.PushAsyncSingle(new UploadLookupsPage());
        }

    }
}