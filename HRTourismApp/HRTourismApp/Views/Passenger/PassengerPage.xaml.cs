using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HRTourismApp.ViewModels.Passenger;
using HRTourismApp.Models;
using HRTourismApp.Helpers;
using System;

namespace HRTourismApp.Views.Passenger
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengerPage : ContentPage
    {
        private PassengerViewModel _passengerViewModel;        
        public PassengerPage(long journeyId)
        {
            InitializeComponent();
            try
            {
                _passengerViewModel = new PassengerViewModel();

                Title = "Yolcu Ekle";
                btnPassenger.Text = "Ekle";
                btnPassenger.IsVisible = true;
                _passengerViewModel.Passenger.JourneyId = journeyId;
                BindingContext = _passengerViewModel;
            }
            catch(Exception ex)
            {
                MessageNotificationHelper.ShowMessageError(ex.Message);
            }
        }
        public PassengerPage(PassengerDTO passenger)
        {
            try
            {
                InitializeComponent();

                _passengerViewModel = new PassengerViewModel();
                _passengerViewModel.Passenger = passenger;

                Title = "Yolcu Goruntule";
                btnPassenger.IsVisible = false;

                BindingContext = _passengerViewModel;
            }
            catch (Exception ex)
            {
                MessageNotificationHelper.ShowMessageError(ex.Message);
            }
        }

        private void pickerStaticData_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var picker = (Picker)sender;            
            if(picker.SelectedIndex==0)
                _passengerViewModel.Passenger.Gender = "K";
            else
                _passengerViewModel.Passenger.Gender = "E";
        }

        private void CountryEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            if (picker.SelectedIndex > 0)
            {
                _passengerViewModel.Passenger.CountryId= ((CountryDTO)picker.SelectedItem).Id;
                _passengerViewModel.Passenger.CountryName = ((CountryDTO)picker.SelectedItem).Name;
            }

        }
    }
}