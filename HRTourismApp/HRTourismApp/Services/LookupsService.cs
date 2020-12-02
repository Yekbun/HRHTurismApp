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
        private string _endpoint = Constants.BASE_API_URL;
        private static CancellationToken _cancellationToken;        
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
        //TODO:Singleton olacak
        public List<CountryDTO> GetCountry()
        {
            CountryService countries = new CountryService();
            try
            {
                return countries.GetAllCountries();
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
                _endpoint = Constants.BASE_API_URL + "api/Company/" + App.User.CompanyId.ToString() + "/Vehicles";
                _cancellationToken = new CancellationToken();
                var taskResponse = BaseAPIService.Get<List<VehicleDTO>>(_endpoint, _cancellationToken);

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
                _endpoint = Constants.BASE_API_URL + "api/Company/" + App.User.CompanyId.ToString() + "/Drivers";
                _cancellationToken = new CancellationToken();
                var taskResponse = BaseAPIService.Get<List<UserDTO>>(_endpoint, _cancellationToken);

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
    }
}
