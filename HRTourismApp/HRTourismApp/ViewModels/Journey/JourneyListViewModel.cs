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

namespace HRTourismApp.ViewModels.Journey
{
    public class JourneyListViewModel : BaseViewModel
    {
        private List<Models.JourneyModal> journeyList;
        public List<Models.JourneyModal> JourneyList
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
        public async Task<List<Models.JourneyModal>> GetAllJourney()
        {
            journeyList = await journeyService.GetAllAsync();
            return journeyList;
        }
        public async void GetSelectedJourney(Models.JourneyModal journey)
        {
            await NavigationHelper.PushAsyncSingle(new JourneyDetailPage(journey));
        }        
    }
}