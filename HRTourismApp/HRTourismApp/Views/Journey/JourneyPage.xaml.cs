using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HRTourismApp.ViewModels.Journey;
using HRTourismApp.Models.Core;
using HRTourismApp.Models;
using HRTourismApp.Services.GoogleMaps;

namespace HRTourismApp.Views.Journey
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JourneyPage : ContentPage
    {
        private JourneyViewModel _journeyViewModel;        

        public JourneyPage()
        {
            InitializeComponent();

            _journeyViewModel = new JourneyViewModel();

            // Set default text
            Title = "Yeni Yolculuk";
            btnSave.IsVisible = true;
            btnCancel.IsVisible = false;
            btnUpdate.IsVisible = false;       
            entDescription.IsVisible = false;            

            _journeyViewModel.Journey.StartDate = DateTime.Now;
            _journeyViewModel.Journey.FinishDate = DateTime.Now;
            _journeyViewModel.Journey.StartDateTime = DateTime.Now.AddHours(2).TimeOfDay;
            _journeyViewModel.Journey.FinishDateTime = DateTime.Now.AddHours(3).TimeOfDay;

            BindingContext = _journeyViewModel;
            if (App.User.RoleId == 3)
                pickerDriver.IsVisible = false;
            else
                pickerDriver.IsVisible = true;
        }

        public JourneyPage(JourneyDTO journey)
        {
            if (journey == null)
                return;
            
            InitializeComponent();

            _journeyViewModel = new JourneyViewModel();
            _journeyViewModel.Journey = journey;

            // Set default text
            Title = "Yolculuk Güncelleme";
            btnSave.IsVisible = false;
            btnCancel.IsVisible = true;
            btnUpdate.IsVisible = true;
            entDescription.IsVisible = true;

            tpStartDate.Time = _journeyViewModel.Journey.StartDate.TimeOfDay;
            tpFinishDate.Time = _journeyViewModel.Journey.FinishDate.TimeOfDay;
           
            BindingContext = _journeyViewModel;

            if (App.User.RoleId == 3)
                pickerDriver.IsVisible = false;
            else
            {
                pickerDriver.IsVisible = true;

                for (int x = 0; x < _journeyViewModel.DriverList.Count; x++)
                {
                    if (_journeyViewModel.DriverList[x].Id == _journeyViewModel.Journey.DriverId)
                    {
                        pickerDriver.SelectedIndex = x;
                    }
                }
            }
            for (int x = 0; x < _journeyViewModel.VehicleList.Count; x++)
            {
                if (_journeyViewModel.VehicleList[x].Id == _journeyViewModel.Journey.VehicleId)
                {
                    pickerVehicle.SelectedIndex = x;
                }
            }
            txtFrom.Text = _journeyViewModel.Journey.From;
            txtTo.Text = _journeyViewModel.Journey.To;

            _journeyViewModel.ShowListView = false;
            _journeyViewModel.ShowOthers = true;            
        }

        private void pickerDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            if (picker.SelectedIndex > -1)
            {
                _journeyViewModel.Journey.DriverId = ((UserDTO)picker.SelectedItem).Id;
                _journeyViewModel.Journey.DriverName = ((UserDTO)picker.SelectedItem).NameSurname;
            }
        }

        private void pickerVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            if (picker.SelectedIndex > -1)
            {
                _journeyViewModel.Journey.VehicleId = ((VehicleDTO)picker.SelectedItem).Id;
                _journeyViewModel.Journey.VehiclePlaque = ((VehicleDTO)picker.SelectedItem).Plaque;
            }
        }
        private void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem;
            if (_journeyViewModel.IsPickupFocused == true)
            {
                _journeyViewModel.FromLocation = ((GooglePlaceAutoCompletePrediction)item).Description;
                txtFrom.Text = _journeyViewModel.FromLocation;
                _journeyViewModel.Journey.From = _journeyViewModel.FromLocation;
            }
            else
            {
                _journeyViewModel.ToLocation = ((GooglePlaceAutoCompletePrediction)item).Description;
                txtTo.Text = _journeyViewModel.ToLocation;
                _journeyViewModel.Journey.To = _journeyViewModel.ToLocation;
            }
            _journeyViewModel.ShowListView = false;
            _journeyViewModel.ShowOthers = true;
        }
    }
}