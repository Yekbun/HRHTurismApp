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

        private List<VehicleDTO> getVehicleMockData()
        {
            List<VehicleDTO> list = new List<VehicleDTO>();

            list.Add(new VehicleDTO { Id=35, Plaque="CR472569" });
            list.Add(new VehicleDTO { Id = 34, Plaque="34ABC14" });
            return list;
        }
        private List<UserDTO> getDriverMockData()
        {
            List<UserDTO> list = new List<UserDTO>();            
            list.Add(new UserDTO { Id = 129, NameSurname = "Surucu1", Phone = "05378217440", CompanyId = 8, Email = "olcayyf@hotmail.com" });
            return list;
        }
        private List<CountryDTO> getCountryMockData()
        {
            List<CountryDTO> list = new List<CountryDTO>();

            list.Add(new CountryDTO { Id = 226,  Name= "Türkiye", Code="TUR"});
            list.Add(new CountryDTO { Id = 242, Name = "Afghanistan", Code="AFG"});

             
            return list;
        }

        public List<VehicleDTO> GetVehicles()
        {
#if DEBUG
            return getVehicleMockData();
#else
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
#endif
        }
        //TODO:Singleton olacak
        public List<CountryDTO> GetCountry()
        {
#if DEBUG
            return getCountryMockData();
#else
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
#endif
        }
        public List<UserDTO> GetDrivers()
        {
#if DEBUG

            return getDriverMockData();
#else
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
#endif
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
