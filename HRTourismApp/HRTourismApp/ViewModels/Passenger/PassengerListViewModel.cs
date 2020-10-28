using HRTourismApp.Models.HRTourismApp.Models;
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

namespace HRTourismApp.ViewModels.Passenger
{
    public class PassengerListViewModel:BaseViewModel
    {
        private IEnumerable<PassengerModel> passengerList;
        private PassengerService passengerService;

        public IEnumerable<PassengerModel> PassengerList
        {
            get { return passengerList; }
            set { OnPropertyChanged(); }
        }
        public ICommand AddCommand
        {
            get { return new Command(ShowPassengerPage); }            
        }
        public PassengerListViewModel()
        {
            passengerService = new PassengerService();
        }
        
        private async void ShowPassengerPage()
        {
            await NavigationHelper.PushAsyncSingle(new PassengerPage());
        }
        public async Task<IEnumerable<PassengerModel>> GetAllPassenger()
        {
            passengerList = await passengerService.GetAllAsync();
            return passengerList;
        }

        public async void GetSelectedPassenger(PassengerModel passenger)
        {
            await NavigationHelper.PushAsyncSingle(new PassengerDetailsPage(passenger));
        }

    }
}
