using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Helpers;
using HRTourismApp.Services;

namespace HRTourismApp.ViewModels.Journey
{
    public class JourneyUpdateViewModel
    {
        // Data
        public Models.JourneyModal Journey { get; set; }

        // Commands
        public ICommand JourneyCommand
        {
            get
            {
                return new Command(UpdateJourney);
            }
        }

        // Local services
        JourneyService journeyService;

        public JourneyUpdateViewModel()
        {
            Journey = new Models.JourneyModal();
            journeyService = new JourneyService();
        }

        public async void UpdateJourney()
        {
            try
            {
                int updatedId = await journeyService.UpdateAsync(Journey);
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