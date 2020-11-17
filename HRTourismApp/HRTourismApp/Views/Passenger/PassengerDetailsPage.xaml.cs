using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HRTourismApp.ViewModels.Passenger;
using HRTourismApp.Models;

namespace HRTourismApp.Views.Passenger
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengerDetailsPage : ContentPage
    {
        private PassengerViewModel _passengerViewModel;
        public PassengerDetailsPage()
        {
            InitializeComponent();
        }
        public PassengerDetailsPage(PassengerDTO passenger)
        {
            InitializeComponent();

            _passengerViewModel = new PassengerViewModel();

            if (passenger != null)
                _passengerViewModel.Passenger = passenger;

            BindingContext = _passengerViewModel;
            if (passenger.Gender == "K")
            {
                pickerGender.SelectedIndex = 0;
            }
            else
            {
                pickerGender.SelectedIndex = 1;
            }
        }

    }
}

