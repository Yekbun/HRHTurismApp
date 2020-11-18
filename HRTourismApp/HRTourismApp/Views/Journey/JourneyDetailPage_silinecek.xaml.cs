using HRTourismApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HRTourismApp.ViewModels.Journey;
using HRTourismApp.Models.Core;

namespace HRTourismApp.Views.Journey
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JourneyDetailPage : ContentPage
    {
        private JourneyViewModel _journeyViewModel;
        public JourneyDetailPage()
        {
            InitializeComponent();
        }

        public JourneyDetailPage(JourneyDTO journey)
        {
            InitializeComponent();

            _journeyViewModel = new JourneyViewModel();

           if (journey != null)
                _journeyViewModel.Journey = journey;

            BindingContext = _journeyViewModel;
        }
        private void pickerDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            if (picker.SelectedIndex > 0)
            {
                _journeyViewModel.Journey.DriverId = ((UserDTO)picker.SelectedItem).Id;
                _journeyViewModel.Journey.DriverName = ((UserDTO)picker.SelectedItem).NameSurname;
            }
        }

        private void pickerVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            if (picker.SelectedIndex > 0)
            {
                _journeyViewModel.Journey.VehicleId = ((VehicleDTO)picker.SelectedItem).Id;
                _journeyViewModel.Journey.VehiclePlaque = ((VehicleDTO)picker.SelectedItem).Plaque;
            }
        }
    }
}