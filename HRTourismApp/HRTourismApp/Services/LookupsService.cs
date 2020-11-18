using HRTourismApp.APIServices;
using HRTourismApp.Helpers;
using HRTourismApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;

namespace HRTourismApp.Services
{

    public class LookupsService
    {
        private string endpoint = Constants.BASE_API_URL;
        private static CancellationToken _cancellationToken;
        private const string _countryFileName= "Country.json";
        private const string _vehicleFileName = "Vehicle.json";
        private const string _driversFileName = "Driver.json";

        public List<VehicleDTO> GetVehicles()
        {
            if (FileIOHelper.FileExists(_vehicleFileName) == false)
                UpdateVehicles();
            try
            {
                var taskResponse = Helpers.FileIOHelper.ReadData(_vehicleFileName);
                return (List<VehicleDTO>)JsonConvert.DeserializeObject<List<VehicleDTO>>(taskResponse.Result);
            }
            catch (StackOverflowException ex)
            {
                throw (ex);
            }
        }

        public List<CountryDTO> GetCountry()
        {
            if (FileIOHelper.FileExists(_countryFileName) == false)
                UpdateCountries();
            try
            {
                var taskResponse = Helpers.FileIOHelper.ReadData(_countryFileName);
                return JsonConvert.DeserializeObject<List<CountryDTO>>(taskResponse.Result);                
            }
            catch (StackOverflowException ex)
            {
                throw (ex);
            }
        }
        public List<UserDTO> GetDrivers()
        {
            if (FileIOHelper.FileExists(_driversFileName) == false)
                UpdateDrivers();

            try
            {                
                var taskResponse = Helpers.FileIOHelper.ReadData(_driversFileName);
                return JsonConvert.DeserializeObject<List<UserDTO>>(taskResponse.Result);
            }
            catch (StackOverflowException ex)
            {
                throw (ex);
            }
        }

        public async void UpdateVehicles()
        {
            try
            {
                endpoint = Constants.BASE_API_URL + "api/Company/" + App.User.CompanyId.ToString() + "/Vehicles";
                _cancellationToken = new CancellationToken();
                var taskResponse = BaseAPIService.Get<List<VehicleDTO>>(endpoint, _cancellationToken);

                var data = JsonConvert.SerializeObject(taskResponse.Result);
                if (data != null)
                {
                    FileIOHelper.DeleteFile(_vehicleFileName);
                    await FileIOHelper.SaveData(data.ToString(), _vehicleFileName);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async void UpdateDrivers()
        {
            try
            {
                endpoint += "api/Company/" + App.User.CompanyId.ToString() + "/Drivers";
                _cancellationToken = new CancellationToken();
                var taskResponse = BaseAPIService.Get<List<UserDTO>>(endpoint, _cancellationToken);

                var data = JsonConvert.SerializeObject(taskResponse.Result);
                if (data != null)
                {
                    FileIOHelper.DeleteFile(_driversFileName);
                    await FileIOHelper.SaveData(data.ToString(), _driversFileName);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async void UpdateCountries()
        {
            try
            {
                endpoint += "api/Country";
                _cancellationToken = new CancellationToken();
                var taskResponse = BaseAPIService.Get<List<CountryDTO>>(endpoint, _cancellationToken);               

                var data = JsonConvert.SerializeObject(taskResponse.Result);
                if (data != null)
                {
                    FileIOHelper.DeleteFile(_countryFileName);
                    await FileIOHelper.SaveData(data.ToString(), _countryFileName);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

}
