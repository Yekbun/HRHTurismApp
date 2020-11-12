using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HRTourismApp.ViewModels.Passenger;
using HRTourismApp.Models;

namespace HRTourismApp.Views.Passenger
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengerListPage : ContentPage
    {
        private PassengerListViewModel passengerListViewModel;

        public PassengerListPage()
        {
            InitializeComponent();
            passengerListViewModel = new PassengerListViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            passengerListViewModel.PassengerList = await passengerListViewModel.GetAllPassenger();
            BindingContext = passengerListViewModel;
        }

        private void ListViewPassenger_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            PassengerDTO item = (PassengerDTO)e.Item;
            if (item == null)
                return;

            passengerListViewModel.GetSelectedPassenger(item);
        }
    }
}