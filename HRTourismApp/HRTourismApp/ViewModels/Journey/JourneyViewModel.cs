using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Helpers;
using HRTourismApp.Services;
using HRTourismApp.Models.Core;
using HRTourismApp.Models;

namespace HRTourismApp.ViewModels.Journey
{
   public partial class JourneyViewModel: BaseViewModel
    {        
        private JourneyService _journeyService;
        private UserDTO _selectedDriver;
        private VehicleDTO _selectedVehicle;
        private List<UserDTO> _driverList ;
        private List<VehicleDTO> _vehicleList;
        private LookupsService _lookService;

        public JourneyDTO Journey { get; set; }
        public IList<UserDTO> DriverList { get { return _driverList; } }
        public IList<VehicleDTO> VehicleList { get { return _vehicleList; } }

        public UserDTO SelectedDriver
        {
            get { return _selectedDriver; }
            set
            {
                if (_selectedDriver != value)
                {
                    _selectedDriver = value;
                    OnPropertyChanged();
                }
            }
        }

        public VehicleDTO SelectedVehicle
        {
            get { return _selectedVehicle; }
            set
            {
                if(_selectedVehicle != null)
                {
                    _selectedVehicle = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand CreateCommand
        {
            get
            {
                return new Command(saveJourney);
            }
        }
        public ICommand UpdateCommand
        {
            get
            {
                return new Command(saveJourney);
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return new Command(cancelJourney);
            }
        }

        public JourneyViewModel()
        {
            Journey = new JourneyDTO();
            _journeyService = new JourneyService();
            _driverList = new List<UserDTO>();
            _vehicleList = new List<VehicleDTO>();
            _lookService = new LookupsService();

            _driverList = _lookService.GetDrivers();
            _vehicleList= _lookService.GetVehicles();

            GetPlacesCommand = new Command<string>(async (param) => await GetPlacesByName(param));
            ShowListView = false;
            ShowOthers = !ShowListView;            
        }

        private async void saveJourney()
        {
            try
            {
                Journey.StartDate = Journey.StartDate.Date + Journey.StartDateTime;
                Journey.FinishDate = Journey.FinishDate.Date + Journey.FinishDateTime;

                int createdId = 0;
                if (Journey.CompanyId == 0)                
                    Journey.CompanyId = App.User.CompanyId;

                if (Journey.From.Length <5)
                {
                    MessageNotificationHelper.ShowMessageSuccess("Lütfen başlangıç yeri bilgisini kontrol edin. Girdiginiz değer yetersiz.");
                    return;
                }
                if (Journey.To.Length < 5)
                {
                    MessageNotificationHelper.ShowMessageSuccess("Lütfen bitiş yeri bilgisini kontrol edin. Girdiginiz değer yetersiz.");
                    return;
                }
                if (Journey.StartDate < DateTime.Now)
                {
                    MessageNotificationHelper.ShowMessageSuccess("Başlangıç tarihi bugünden suandan en az 1 saat once olmalidir.");
                    return;
                }
                if (Journey.FinishDate < Journey.StartDate)
                {
                    MessageNotificationHelper.ShowMessageSuccess("Bitiş tarihi Başlangıç tarihinden once olamaz.");
                    return;
                }
                if (Journey.DriverId == 0)
                {
                    if (_driverList.Count == 1)
                        Journey.DriverId = _driverList[0].Id;
                    else
                    {
                        MessageNotificationHelper.ShowMessageSuccess("Sürücü bilgisi boş olamaz!!");
                        return;
                    }
                }
                if (Journey.VehicleId == 0)
                {
                    if (_vehicleList.Count == 1)
                        Journey.VehicleId = _vehicleList[0].Id;
                    else
                    {
                        MessageNotificationHelper.ShowMessageSuccess("Araç bilgisi boş olamaz!!");
                        return;
                    }
                }
                if (Journey.Fees <0)
                {
                    MessageNotificationHelper.ShowMessageSuccess("Ücert 0 olamaz.");
                    return;
                }

                if (Journey.Id==0)
                {
                    // Create a new journey
                    createdId = await _journeyService.SaveAsync(Journey);
                }
                else
                {                   
                    if (Journey.Description == "")
                    {
                        MessageNotificationHelper.ShowMessageSuccess("Açiklama bilgisi boş olamaz!!");
                        return;
                    }
                    // update a journey
                    createdId = await _journeyService.UpdateAsync(Journey);
                }              

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

        private async void cancelJourney()
        {
            try
            {
                if(Journey.Description==string.Empty)
                {
                    MessageNotificationHelper.ShowMessageFail("Lutfen bir aciklama giriniz.");
                }

                bool isDeleted = await Application.Current.MainPage.DisplayAlert("Dikkat", "Kaydi iptal etmek istediğinize emin misiniz?", "OK", "Vazgeç");
                if (isDeleted)
                {
                    Journey.UserId = App.User.Id;
                    int updatedId = await _journeyService.DeleteAsync(Journey.Id,Journey.Description);
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