using HRTourismApp.Models.HRTourismApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Helpers;
using HRTourismApp.Services;

namespace HRTourismApp.ViewModels.Passenger
{  
   public class PassengerCreateViewModel
    {
        public PassengerModel Passenger { get; set; }
        public ICommand AddPassengerCommand
        {
            get { return new Command(AddPassenger); }
        }

        private PassengerService passengerService;
        public PassengerCreateViewModel()
        {
            passengerService = new PassengerService();
            Passenger = new PassengerModel();
        }
        private async void AddPassenger()
        {
            try
            {
                Passenger.Id = 1;

                int createdId = await passengerService.SaveAsync(Passenger);

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