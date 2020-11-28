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

        private Task<List<PassengerDTO>> getMockData()
        {
            List<PassengerDTO> list = new List<PassengerDTO>();

            list.Add(new PassengerDTO
            {
                Id = 41, JourneyId = 69, LastName = "Olcay", FirstName = "Feryat", HesKodu="HES-1", Phone = "0212535345", CountryCode = "TUR", DocumentNo="U15523125", Gender = "F" ,SeatNumber=1    
            });
            list.Add(new PassengerDTO
            {
                Id = 42,
                JourneyId = 69,
                LastName = "Pater",
                FirstName = "Patrick",
                HesKodu = "HES-2",
                Phone = "0212535345",
                CountryCode = "POL",
                DocumentNo = "I55523125",
                Gender = "M",
                SeatNumber = 2
            });
            list.Add(new PassengerDTO
            {
                Id = 42,
                JourneyId = 69,
                LastName = "Umut",
                FirstName = "Sapan",
                HesKodu = "HES-3",
                Phone = "02125465645",
                CountryCode = "AFG",
                DocumentNo = "I54565125",
                Gender = "M",
                SeatNumber = 3
            });
            list.Add(new PassengerDTO
            {
                Id = 42,
                JourneyId = 69,
                LastName = "Helin",
                FirstName = "Sapan",
                HesKodu = "HES-4",
                Phone = "0213453535",
                CountryCode = "KAT",
                DocumentNo = "K54565125",
                Gender = "F",
                SeatNumber = 4
            });

            return Task.FromResult(list);
        }

        public PassengerService()
        {            
            _cancellationToken = new CancellationToken();
        }
        public Task<List<PassengerDTO>> GetAllPassengerAsync(long journeyId)
        {
#if DEBUG
            return getMockData();
#else
            endpoint = Constants.BASE_API_URL + "api/Journey/" + journeyId + "/Passengers";
            var responseTask = BaseAPIService.Get<List<PassengerDTO>>(endpoint, _cancellationToken);
            return Task.FromResult(responseTask.Result);
#endif
        }

        public Task<PassengerDTO> GetPassengerAsync(long id)
        {
            try
            {
                endpoint += "Passenger/" + id.ToString();
                var responseTask = BaseAPIService.Get<PassengerDTO>(endpoint, _cancellationToken);
                return Task.FromResult(responseTask.Result);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
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
