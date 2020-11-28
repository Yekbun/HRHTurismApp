using HRTourismApp.Helpers;
using HRTourismApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HRTourismApp.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadLookupsPage : ContentPage
    {
        private LookupsService _lookupsService;
        public UploadLookupsPage()
        {
            _lookupsService = new LookupsService();
            InitializeComponent();
        }
        private void btnVehicle_Clicked(object sender, EventArgs e)
        {
            _lookupsService.UpdateVehicles();
            MessageNotificationHelper.ShowMessageFail("Arac bilgileri basariyla guncellendi");
        }

        private void btnDriver_Clicked(object sender, EventArgs e)
        {
            _lookupsService.UpdateDrivers();
            MessageNotificationHelper.ShowMessageFail("Surucu bilgileri basariyla guncellendi");
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainMenu());
        }
    }
}