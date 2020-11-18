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
                btnSave.IsVisible = true;
                btnCancel.IsVisible = false;

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

                Title = "Yolcu Görüntüle";
                btnSave.IsVisible = false;
                btnCancel.IsVisible = true;
                BindingContext = _passengerViewModel;

                if (passenger.Gender == "K")
                {
                    pickerGender.SelectedIndex = 0;
                }
                else
                {
                    pickerGender.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageNotificationHelper.ShowMessageError(ex.Message);
            }
        }

        private void pickerGender_SelectedIndexChanged(object sender, System.EventArgs e)
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