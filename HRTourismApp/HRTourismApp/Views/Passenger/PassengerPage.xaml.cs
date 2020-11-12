using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HRTourismApp.ViewModels.Passenger;
using HRTourismApp.Models;

namespace HRTourismApp.Views.Passenger
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengerPage : ContentPage
    {

        private PassengerCreateViewModel _journeyCreateViewModel;
        private PassengerUpdateViewModel _journeyUpdateViewModel;
        public PassengerPage()
        {
            InitializeComponent();
            _journeyCreateViewModel = new PassengerCreateViewModel();

            Title = "Yolcu Ekle";
            btnPassenger.Text = "Ekle";
            btnPassenger.IsVisible = true;
            BindingContext = _journeyCreateViewModel;
        }
        public PassengerPage(PassengerDTO passenger)
        {
            InitializeComponent();
            _journeyUpdateViewModel = new PassengerUpdateViewModel();
            _journeyUpdateViewModel.Passenger = passenger;

            Title = "Yolcu Goruntule";
            btnPassenger.IsVisible = false;

            BindingContext = _journeyUpdateViewModel;
        }

        private void pickerStaticData_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var picker = (Picker)sender;            
            if(picker.SelectedIndex==0)
                _journeyCreateViewModel.Passenger.Gender = "K";
            else
                _journeyCreateViewModel.Passenger.Gender = "E";
        }
    }
}