using HRTourismApp.Services.GoogleMaps;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HRTourismApp.ViewModels.Journey
{
    public partial class JourneyViewModel : BaseViewModel
    {
        private IGoogleMapsApiService googleMapsApi = new GoogleMapsApiService();

        public ICommand GetPlacesCommand { get; set; }

        private ObservableCollection<GooglePlaceAutoCompletePrediction> _googleLocations;
        public ObservableCollection<GooglePlaceAutoCompletePrediction> GoogleLocations
        {
            get { return _googleLocations; }            
            set
            {
                SetProperty(ref _googleLocations, value);
            }
        }
        public bool ShowRecentPlaces { get; set; }
        private bool _showListView;
        public bool ShowListView
        {
            get { return _showListView; }
            set
            {
                _showListView = value;
                OnPropertyChanged();
            }
        }

        private bool _showOthers;
        public bool ShowOthers
        {
            get { return _showOthers; }
            set
            {
                _showOthers = value;
                OnPropertyChanged();
            }
        }


        string _pickupText;
        public string PickupText
        {
            get
            {
                return _pickupText;
            }
            set
            {
                _pickupText = value;
                if (!string.IsNullOrEmpty(_pickupText) && _pickupText.Trim().Length > 3)
                {
                    IsPickupFocused = true;
                    ShowListView = true;
                    ShowOthers = !ShowListView;
                    GetPlacesCommand.Execute(_pickupText);
                }
            }
        }

        string _destinationText;
        public string DestinationText
        {
            get
            {
                return _destinationText;
            }
            set
            {
                _destinationText = value;
                if (!string.IsNullOrEmpty(_destinationText))
                {
                    IsPickupFocused = false;
                    ShowListView = true;
                    ShowOthers = !ShowListView;
                    GetPlacesCommand.Execute(_destinationText);
                }
            }
        }

        public bool IsPickupFocused { get; set; }

        public string FromLocation { get; set; }
        public string ToLocation { get; set; }

        public async Task GetPlacesByName(string placeText)
        {            
            var places = await googleMapsApi.GetPlaces(placeText);
            var placeResult = places.AutoCompletePlaces;
            if (placeResult != null && placeResult.Count > 0)
            {
                GoogleLocations = new ObservableCollection<GooglePlaceAutoCompletePrediction>(placeResult);
            }

            if (placeResult == null || placeResult.Count == 0)
                ShowRecentPlaces = false;
            else
                ShowRecentPlaces = true;

            PickupText = DestinationText = string.Empty;
            ShowRecentPlaces = true;

        }
    }
}

