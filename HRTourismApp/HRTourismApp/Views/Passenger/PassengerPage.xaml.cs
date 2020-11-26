using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HRTourismApp.ViewModels.Passenger;
using HRTourismApp.Models;
using HRTourismApp.Helpers;
using System;
using Plugin.Media;

using HRTourismApp.Helpers.OCR;
using HRTourismApp.Services;
using Plugin.Media.Abstractions;
using HRTourismApp.Helper.OCR;

namespace HRTourismApp.Views.Passenger
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengerPage : ContentPage
    {
        private PassengerViewModel _passengerViewModel;
        public PassengerPage(long journeyId)
        {
            InitializeComponent();
            try
            {
                _passengerViewModel = new PassengerViewModel();

                Title = "Yolcu Ekle";
                btnSave.IsVisible = true;
                btnCancel.IsVisible = false;

                _passengerViewModel.Passenger.JourneyId = journeyId;
                BindingContext = _passengerViewModel;
            }
            catch (Exception ex)
            {
                MessageNotificationHelper.ShowMessageError(ex.Message);
            }
        }
        public PassengerPage(PassengerDTO passenger)
        {
            try
            {
                InitializeComponent();

                _passengerViewModel = new PassengerViewModel();
                _passengerViewModel.Passenger = passenger;

                Title = "Yolcu Görüntüle";
                btnSave.IsVisible = false;
                btnCancel.IsVisible = true;
                if (passenger.Gender == "K")
                    pickerGender.SelectedIndex = 0;
                else
                    pickerGender.SelectedIndex = 1;

                BindingContext = _passengerViewModel;

                for (int x = 0; x < _passengerViewModel.CountryList.Count; x++)
                {
                    if (_passengerViewModel.CountryList[x].Id == _passengerViewModel.Passenger.CountryId)
                    {
                        pickerCountry.SelectedIndex = x;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageNotificationHelper.ShowMessageError(ex.Message);
            }
        }

        private void pickerGender_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var picker = (Picker)sender;
            if (picker.SelectedIndex == 0)
                _passengerViewModel.Passenger.Gender = "K";
            else
                _passengerViewModel.Passenger.Gender = "E";
        }

        private void pickerCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            if (picker.SelectedIndex > 0)
            {
                _passengerViewModel.Passenger.CountryId = ((CountryDTO)picker.SelectedItem).Id;
                _passengerViewModel.Passenger.CountryName = ((CountryDTO)picker.SelectedItem).Name;
            }

        }

        public async void TakePicture()
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Front
            });

            if (file == null)
                return;
            string filePath = file.Path;
            await DisplayAlert("File Location", file.Path, "OK");
            /*
            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
            */
            ILocalFileProvider service = DependencyService.Get<ILocalFileProvider>(DependencyFetchTarget.NewInstance);
            byte[] byteArray = null;
            using (service as IDisposable)
            {
                byteArray = service.GetFileBytes(filePath);
            }

            MRZParser mrzParser = new MRZParser();
#if DEBUG
            string retVal = "P<RUSMALBORSKYI<<KOVBOJ<<<<<<<<<<<<<<<<<<<<<7553279419RUS8712242M2104131<<<<<<<<<<<<<<02";
            var Return = mrzParser.Parse(retVal);

            retVal = "P<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<<<<<<<<<L898902C<3UTO6908061F9406236ZE184226B<<<<<14";
            Return = mrzParser.Parse(retVal);
#else
            FreeOCR free = new FreeOCR();
            string retVal = await free.SendImageAsync(byteArray);            
            IDeleteFromFile deleteService = DependencyService.Get<IDeleteFromFile>(DependencyFetchTarget.NewInstance);
            using (deleteService as IDisposable)
            {
                deleteService.DeleteFile(filePath);
            }         
#endif
        }

        private void btnTakePicture_Clicked(object sender, EventArgs e)
        {
            TakePicture();
        }

    }
}