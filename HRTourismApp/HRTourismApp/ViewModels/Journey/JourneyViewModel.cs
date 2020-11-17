using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Helpers;
using HRTourismApp.Services;
using HRTourismApp.Models.Core;

namespace HRTourismApp.ViewModels.Journey
{
   public class JourneyCreateViewModel
    {
        public JourneyDTO Journey { get; set; }
        private JourneyService journeyService;

        // Commands
        public ICommand JourneyCommand
        {
            get
            {
                return new Command(CreateJourney);
            }
        }
                
        public JourneyCreateViewModel()
        {
            Journey = new JourneyDTO();

            journeyService = new JourneyService();
        }

        public async void CreateJourney()
        {
            try
            {
                int createdId = await journeyService.SaveAsync(Journey);

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