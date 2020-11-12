using HRTourismApp.APIServices;
using HRTourismApp.Helpers;
using HRTourismApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HRTourismApp.Services
{
    
    public class LookupsService
    {
        private string endpoint = Constants.BASE_API_URL ;
        private static CancellationToken cancellationToken;

        public List<VehicleDTO> GetVehicles(int companyId)
        {
            endpoint = Constants.BASE_API_URL + "api/Company/" + companyId + "/Vehicle";

            cancellationToken = new CancellationToken();
            var responseTask = BaseAPIService.Get<List<VehicleDTO>>(endpoint, cancellationToken);
            return responseTask.Result;
        }

        public List<CountryDTO> GetCountry()
        {
            endpoint += "api/Country";
            cancellationToken = new CancellationToken();
            var taskResponse = BaseAPIService.Get<List<CountryDTO>>(endpoint, cancellationToken);
            return taskResponse.Result;           
            
        }
        public List<UserDTO> GetDrivers(int companyId)
        {
            endpoint += "api/Company/" + companyId + "/Drivers";
            cancellationToken = new CancellationToken();
            var taskResponse = BaseAPIService.Get<List<UserDTO>>(endpoint, cancellationToken);
            return taskResponse.Result;
        }
       
    }

}
