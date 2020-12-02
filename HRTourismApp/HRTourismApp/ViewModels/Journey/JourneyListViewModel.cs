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
using HRTourismApp.Views.Passenger;

namespace HRTourismApp.ViewModels.Journey
{
    public class JourneyListViewModel : BaseViewModel
    {
        private List<JourneyDTO> _journeyList;
        public List<JourneyDTO> JourneyList
        {
            get { return _journeyList; }
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
            try { 
            journeyService = new JourneyService();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private async void addJourney()
        {
            try
            {
                await NavigationHelper.PushAsyncSingle(new JourneyPage());
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<List<JourneyDTO>> GetAllJourney()
        {
            try
            {
                if (App.User.RoleId == 3)
                    _journeyList = await journeyService.GetAllJourney(null,App.User.Id);
                else
                    _journeyList = await journeyService.GetAllJourney();

                foreach (var item in _journeyList)
                {
                    if (item.RecordStatus == 0)
                        item.RecordStatusStr = "Basarili";
                    else if (item.RecordStatus == -1)
                        item.RecordStatusStr = "Basarisiz";
                    else if (item.RecordStatus == 1)
                        item.RecordStatusStr = "Yeni Bekliyor";
                    else if (item.RecordStatus == 2)
                        item.RecordStatusStr = "Guncelleme Bekliyor";
                    else if (item.RecordStatus == 3)
                        item.RecordStatusStr = "Iptal Bekliyor";
                    else if (item.RecordStatus == 4)
                        item.RecordStatusStr = "Iptal Edilmis";
                    else
                        item.RecordStatusStr = "";
                }
                return _journeyList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async void GetSelectedJourney(JourneyDTO journey)
        {
            try
            {                
                await NavigationHelper.PushAsyncSingle(new JourneyPage(journey));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}