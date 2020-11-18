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

        public ICommand CreateCommand
        {
            get { return new Command(addPassenger); }
        }

        public ICommand DeleteCommand
        {
            get { return new Command(cancelPassenger); }
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
                Passenger = new PassengerDTO();
                _passengerService = new PassengerService();
                _countryList = new List<CountryDTO>();
                _lookService = new LookupsService();

                _countryList = _lookService.GetCountry();
                

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        private async void addPassenger()
        {
            try
            {            
                if (Passenger.FirstName == "")
                {
                    MessageNotificationHelper.ShowMessageFail("Yolcu adı boş olamaz.");
                }
                if (Passenger.FirstName == "")
                {
                    MessageNotificationHelper.ShowMessageFail("Yolcu soyadı boş olamaz.");
                }
                if (Passenger.JourneyId == 0)
                {
                    MessageNotificationHelper.ShowMessageFail("JourneyId bulunamadı.");
                }
                if (Passenger.CountryId == 0)
                {
                    MessageNotificationHelper.ShowMessageFail("Ülke bilgisi boş olamaz.");
                }
                if (Passenger.CountryId == 0)
                {
                    MessageNotificationHelper.ShowMessageFail("Pasaport/Id bilgisi boş olamaz.");
                }
                if (Passenger.Gender == "")
                {
                    MessageNotificationHelper.ShowMessageFail("Cinsiyet bilgisi boş olamaz.");
                }

                int createdId = await _passengerService.SaveAsync(Passenger);
                if (createdId > 0)
                {
                    MessageNotificationHelper.ShowMessageSuccess("İşlem başarıyla gercekleşti");
                    await NavigationHelper.PopAsyncSingle();
                }
                else
                {
                    MessageNotificationHelper.ShowMessageFail("Beklenmedik bir hata oluştu.");
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

        private async void cancelPassenger()
        {
            try
            {
                bool isDeleted = await Application.Current.MainPage.DisplayAlert("Dikkat", "Yolcuyu iptal etmek istediğinize emin misiniz?", "OK", "Vazgeç");
                if (isDeleted)
                {
                    Passenger.UserId = App.User.Id;
                    int updatedId = await _passengerService.DeleteAsync(Passenger.Id);
                    if (updatedId > 0)
                    {
                        MessageNotificationHelper.ShowMessageSuccess("Yolcu iptal etme başariyla gerçekleşti.");
                        await NavigationHelper.PopAsyncSingle();
                        
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
