using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Helpers;
using HRTourismApp.Services;
using HRTourismApp.Views.Journey;
using HRTourismApp.Models.Core;

namespace HRTourismApp.ViewModels.Journey
{
    public class JourneyDetailViewModel
    {
        // Data
        public JourneyDTO Journey { get; set; }

        // Commands
        public ICommand UpdateJourneyCommand
        {
            get
            {
                return new Command(UpdateJourney);
            }
        }
        public ICommand DeleteJourneyCommand
        {
            get
            {
                return new Command(DeleteJourney);
            }
        }

        // Local services
        JourneyService journeyService;

        public JourneyDetailViewModel()
        {
            journeyService = new JourneyService();
        }

        public async void UpdateJourney()
        {
            await NavigationHelper.PushAsyncSingle(new JourneyPage(Journey));
        }

        public async void DeleteJourney()
        {
            try
            {
                bool isDeleted = await Application.Current.MainPage.DisplayAlert("Warning", "Are you sure want to delete this item?", "OK", "Cancel");
                if (isDeleted)
                {
                    int deletedId = await journeyService.DeleteAsync(Journey.Id,Journey.Description);
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