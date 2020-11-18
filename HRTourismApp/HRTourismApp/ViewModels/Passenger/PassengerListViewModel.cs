
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Helpers;
using HRTourismApp.Services;
using HRTourismApp.Views.Passenger;
using HRTourismApp.Models;

namespace HRTourismApp.ViewModels.Passenger
{
    public class PassengerListViewModel:BaseViewModel
    {
        private IEnumerable<PassengerDTO> _passengerList;
        private PassengerService _passengerService;
        private long _journeyId;

        public IEnumerable<PassengerDTO> PassengerList
        {
            get { return _passengerList; }
            set { OnPropertyChanged(); }
        }
        public ICommand AddCommand
        {
            get { return new Command(ShowPassengerPage); }            
        }
        public PassengerListViewModel(long journeyId)
        {
            _passengerService = new PassengerService();
            _journeyId = journeyId;
        }
        
        private async void ShowPassengerPage()
        {            
            await NavigationHelper.PushAsyncSingle(new PassengerPage(_journeyId));
        }
        public async Task<IEnumerable<PassengerDTO>> GetAllPassenger()
        {
            _passengerList = await _passengerService.GetAllPassengerAsync(_journeyId);
            return _passengerList;
        }

        public async void GetSelectedPassenger(PassengerDTO passenger)
        {
            await NavigationHelper.PushAsyncSingle(new PassengerPage(passenger));
        }

    }
}
