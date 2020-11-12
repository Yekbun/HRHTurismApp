using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Helpers;
using HRTourismApp.Services;
using HRTourismApp.Views.Passenger;
using HRTourismApp.Models;

namespace HRTourismApp.ViewModels.Passenger
{
    public class PassengerDetailViewModel
    {
        // Data
        public PassengerDTO Passenger { get; set; }

        // Commands
      
        public ICommand CancelPassengerCommand
        {
            get
            {
                return new Command(CancelPassenger);
            }
        }

        // Local services
        PassengerService passengerService;

        public PassengerDetailViewModel()
        {
            passengerService = new PassengerService();
        }
       
        public async void CancelPassenger()
        {
            try
            {
                bool isDeleted = await Application.Current.MainPage.DisplayAlert("Warning", "Are you sure want to delete this item?", "OK", "Cancel");
                if (isDeleted)
                {
                    int deletedId = await passengerService.DeleteAsync(Passenger);
                    if (deletedId > 0)
                    {
                        MessageNotificationHelper.ShowMessageSuccess("Booking has been deleted");
                        await NavigationHelper.PopAsyncSingle();
                    }
                    else
                    {
                        MessageNotificationHelper.ShowMessageFail("Unable to delete booking");
                    }

                    //APIResponse apiResponse = await BookingService.DeleteBooking(0);
                    //if (apiResponse != null && apiResponse.Success)
                    //{
                    //    MessageNotificationHelper.ShowMessageSuccess("Booking has been deleted");
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