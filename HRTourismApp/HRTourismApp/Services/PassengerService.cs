using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HRTourismApp.APIServices;
using HRTourismApp.Helpers;
using HRTourismApp.Models;

namespace HRTourismApp.Services
{
    public class PassengerService
    {
        private string endpoint = Constants.BASE_API_URL;
        private static CancellationToken _cancellationToken;        

        public PassengerService()
        {            
            _cancellationToken = new CancellationToken();
        }
        public Task<List<PassengerDTO>> GetAllPassengerAsync(long journeyId)
        {
            endpoint = Constants.BASE_API_URL + "api/Journey/" + journeyId + "/Passengers";
            var responseTask = BaseAPIService.Get<List<PassengerDTO>>(endpoint, _cancellationToken);
            return Task.FromResult(responseTask.Result);
        }

        public Task<PassengerDTO> GetPassengerAsync(long id)
        {
            endpoint += "Passenger/" + id.ToString();
            var responseTask = BaseAPIService.Get<PassengerDTO>(endpoint, _cancellationToken);
            return Task.FromResult(responseTask.Result);
        }

        public Task<int> SaveAsync(PassengerDTO passenger)
        {
            try
            {
                _cancellationToken = new CancellationToken();
                endpoint += "api/Passenger";
                passenger.UserId = App.User.Id;
                var responseTask = BaseAPIService.Post<APIResponse>(endpoint, passenger, _cancellationToken);
                responseTask.Wait();              
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            return Task.FromResult(1);
        }

        public Task<int> DeleteAsync(long id)
        {            
            endpoint += "api/Passenger?id=" + id.ToString() + "&userId=" + App.User.Id;
            var responseTask = BaseAPIService.Delete<APIResponse>(endpoint, _cancellationToken);
            return Task.FromResult(1);
        }
    }
}
