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
   public class PassengerUpdateViewModel
    {
        public PassengerModel Passenger { get; set; }

        // Commands
        public ICommand CancelPassengerCommand
        {
            get{return new Command(CancelPassenger);}
        }

        // Local services
        PassengerService _passengerService;

        public PassengerUpdateViewModel()
        {
            Passenger = new PassengerModel();
            _passengerService = new PassengerService();
        }

        public async void CancelPassenger()
        {
            try
            {
                int updatedId = await _passengerService.UpdateAsync(Passenger);
                if (updatedId > 0)
                {
                    MessageNotificationHelper.ShowMessageSuccess("Booking has been updated");

                    NavigationHelper.GoToMainPage();
                }
                else
                {
                    MessageNotificationHelper.ShowMessageFail("Unable to update booking");
                }

                //APIResponse apiResponse = await BookingService.UpdateBooking(1, booking);
                //if (apiResponse != null && apiResponse.Success)
                //{
                //    MessageNotificationHelper.ShowMessageSuccess("Booking has been updated");

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