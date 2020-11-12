using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Helpers;
using HRTourismApp.Services;
using HRTourismApp.Models;

namespace HRTourismApp.ViewModels.Passenger
{  
   public class PassengerCreateViewModel : BaseViewModel
    {
        private LookupsService _lookService;
        public PassengerDTO Passenger { get; set; }        
        public IList<CountryDTO> CountryList { get { return _lookService.GetCountry(); } }     

        public ICommand AddPassengerCommand
        {
            get { return new Command(AddPassenger); }
        }

        private PassengerService _passengerService;
        
        public PassengerCreateViewModel()
        {
            _passengerService = new PassengerService();
            _lookService = new LookupsService();

            Passenger = new PassengerDTO();
           
        }
        private CountryDTO _selectedCountry;        
        public CountryDTO SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                if (_selectedCountry != value)
                {
                    _selectedCountry = value;
                    OnPropertyChanged();
                }
            }
        }       

        private async void AddPassenger()
        {
            try
            {
                Passenger.Id = 1;                

                int createdId = await _passengerService.SaveAsync(Passenger);

                if (createdId > 0)
                {
                    MessageNotificationHelper.ShowMessageSuccess("Booking has been created");
                    await NavigationHelper.PopAsyncSingle();
                }
                else
                {
                    MessageNotificationHelper.ShowMessageFail("Unable to create booking");
                }

                //APIResponse apiResponse = await BookingService.CreateBooking(Booking);
                //if (apiResponse != null && apiResponse.Success)
                //{
                //    MessageNotificationHelper.ShowMessageSuccess("Booking has been created");
                //    await Navigation.PopAsync();
                //}
                //else
                //{
                //    if (apiResponse.Messages != null)
                //    {
                //        string message = apiResponse.Messages.FirstOrDefault();
                //        MessageNotificationHelper.ShowMessageFail(message);
                //    }
                //}
            }
            catch (MobileException exception)
            {
                MessageNotificationHelper.ShowMessageFail(exception.Message);
            }
            catch (Exception exception)
            {
                MessageNotificationHelper.ShowMessageError(exception.GetBaseException().Message);
            }
        }
    }
}