using HRTourismApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Helpers;
using HRTourismApp.Services;
using HRTourismApp.Views.Journey;
using HRTourismApp.APIServices;
using HRTourismApp.Models.Core;

namespace HRTourismApp.ViewModels.Journey
{
    public class JourneyListViewModel : BaseViewModel
    {
        private List<JourneyDTO> journeyList;
        public List<JourneyDTO> JourneyList
        {
            get { return journeyList; }
            set { OnPropertyChanged(); }
        }

        // Commands
        public ICommand AddCommand
        {
            get{return new Command(addJourney);}
        }
        
        // Local services
        JourneyService journeyService;

        public JourneyListViewModel()
        {
            journeyService = new JourneyService();
        }

        private async void addJourney()
        {
            await NavigationHelper.PushAsyncSingle(new JourneyPage());
        }       
        public async Task<List<JourneyDTO>> GetAllJourney()
        {
            journeyList = await journeyService.GetAllJourney();
            return journeyList;

            /*
            HRTourismApp.APIServices.APIResponse apiResponse = await BookingService.DeleteBooking(0);
            if (apiResponse != null && apiResponse.Success)
            {
                MessageNotificationHelper.ShowMessageSuccess("Booking has been deleted");
            }
            else
            {
                if (apiResponse.Messages != null)
                {
                    string message = apiResponse.Messages.FirstOrDefault();

                    MessageNotificationHelper.ShowMessageFail(message);
                }
            }*/
        }
        public async void GetSelectedJourney(JourneyDTO journey)
        {
            await NavigationHelper.PushAsyncSingle(new JourneyDetailPage(journey));
        }        
    }
}