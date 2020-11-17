using HRTourismApp.Helpers;
using HRTourismApp.Models;
using HRTourismApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HRTourismApp.ViewModels.Passenger
{
    public class PassengerViewModel: BaseViewModel
    {
        private LookupsService _lookService;
        private PassengerService _passengerService;
        private CountryDTO _selectedCountry;

        private IList<CountryDTO> _countryList;
        public PassengerDTO Passenger { get; set; }
        public IList<CountryDTO> CountryList { get { return _countryList; } }

        public ICommand AddPassengerCommand
        {
            get { return new Command(AddPassenger); }
        }

        public ICommand CancelPassengerCommand
        {
            get { return new Command(CancelPassenger); }
        }

        public CountryDTO SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                if (_selectedCountry != value)
                {
                    _selectedCountry = value;
                    OnPropertyChanged();
                }
            }
        }

        public PassengerViewModel()
        {
            try
            {
                _passengerService = new PassengerService();
                _countryList = new List<CountryDTO>();
                _lookService = new LookupsService();
                _countryList = _lookService.GetCountry();
                Passenger = new PassengerDTO();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        private async void AddPassenger()
        {
            try
            {
                if(Passenger.CountryId == 0)
                {
                    MessageNotificationHelper.ShowMessageFail("Ülke bilgisi boş olamaz.");
                }

                if (Passenger.JourneyId == 0)
                {
                    MessageNotificationHelper.ShowMessageFail("JourneyId bulunamadi.");
                }

                int createdId = await _passengerService.SaveAsync(Passenger);
                if (createdId > 0)
                {
                    MessageNotificationHelper.ShowMessageSuccess("Yolcu oluşturuldu");
                    await NavigationHelper.PopAsyncSingle();
                }
                else
                {
                    MessageNotificationHelper.ShowMessageFail("Yolcu eklemede hata oluştu.");
                }               
            }
            catch (MobileException exception)
            {
                MessageNotificationHelper.ShowMessageFail(exception.Message);
            }
            catch (Exception exception)
            {
                MessageNotificationHelper.ShowMessageError(exception.GetBaseException().Message);
            }
        }

        public async void CancelPassenger()
        {
            try
            {
                bool isDeleted = await Application.Current.MainPage.DisplayAlert("Dikkat", "Yolcuyu iptal etmek istediğinize emin misiniz?", "OK", "Vazgeç");
                if (isDeleted)
                {
                    int updatedId = await _passengerService.DeleteAsync(Passenger.Id);
                    if (updatedId > 0)
                    {
                        MessageNotificationHelper.ShowMessageSuccess("Yolcu iptal etme başariyla gerçekleşti.");
                        await NavigationHelper.PopAsyncSingle();
                        //NavigationHelper.GoToMainPage();
                    }
                    else
                    {
                        MessageNotificationHelper.ShowMessageFail("Yolcu iptal etmede hata oluştu.");
                    }
                }

            }
            catch (MobileException exception)
            {
                MessageNotificationHelper.ShowMessageFail(exception.Message);
            }
            catch (Exception exception)
            {
                MessageNotificationHelper.ShowMessageError(exception.GetBaseException().Message);
            }
        }
    }
}
