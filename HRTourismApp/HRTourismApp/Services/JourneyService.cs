using HRTourismApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRTourismApp.APIServices;
using System.Threading;
using HRTourismApp.Helpers;
using HRTourismApp.Models.Core;

namespace HRTourismApp.Services
{
    public class JourneyService 
    {
        private string endpoint = Constants.BASE_API_URL + "api/Journey";
        private static CancellationToken _cancellationToken; // TODO: online ortamda static ozelligini kaldirip dene

        private Task<List<JourneyDTO>> getMockData()
        {
            List<JourneyDTO> list = new List<JourneyDTO>();

            list.Add(new JourneyDTO
            {
                Id = 69,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 TX1258",
                CompanyId = 8,
                From = "Şirinevler, Bahçelievler/İstanbul",
                To = "Mecidiyeköy, Şişli/İstanbul",
                StartDate = Convert.ToDateTime("2020-11-11 17:00:00"),
                FinishDate = Convert.ToDateTime("2020-11-11 17:30:00"),
                Fees = 250
            });
            list.Add(new JourneyDTO
            {
                Id = 70,
                DriverId = 129,
                DriverName = "Surucu 1",
                VehicleId = 35,
                VehiclePlaque = "34 KL23",
                CompanyId = 8,
                From = "Şirinevler, Bahçelievler/İstanbul",
                To = "Mecidiyeköy, Şişli/İstanbul",
                StartDate = Convert.ToDateTime("2020-11-13 10:30:30"),
                FinishDate = Convert.ToDateTime("2020-11-13 11:30:50"),
                Fees = 250
            });
            return Task.FromResult(list);
        }

        public JourneyService()
        {
            _cancellationToken = new CancellationToken();
        }

        public Task<List<JourneyDTO>> GetAllJourney(/*Pagination pagination = null,*/)
        {
#if DEBUG
            return getMockData();
#else
            try
            {
                endpoint = Constants.BASE_API_URL + "api/company/" + App.User.CompanyId + "/Journeys";
                /*
                if (pagination != null)
                   endpoint = EndpointHelper.Pagination(endpoint, pagination);
                */

                var responseTask = BaseAPIService.Get<List<JourneyDTO>>(endpoint, _cancellationToken);
                return Task.FromResult(responseTask.Result);
            }
            catch (Exception ex)
            {
                throw (ex);
            } 
#endif
        }

        public Task<int> DeleteAsync(long id, string cancelDesc)
        {
            try
            {
                endpoint += "?id=" + id + " & userId = " + App.User.Id.ToString() + " & cancelDesc = '" + cancelDesc + "'";
                var responseTask = BaseAPIService.Delete<APIResponse>(endpoint, _cancellationToken);
                return Task.FromResult(1);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Task<JourneyDTO> GetJourney(long id)
        {
            try
            {
                endpoint += "/" + id;
                var responseTask = BaseAPIService.Get<JourneyDTO>(endpoint, _cancellationToken);
                return Task.FromResult(responseTask.Result);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Task<int> SaveAsync(JourneyDTO journey)
        {
            try
            {
                journey.UserId = App.User.Id;
                var response = BaseAPIService.Post<APIResponse>(endpoint, journey, _cancellationToken);
                response.Wait();
                if (response.Result != null)
                    return Task.FromResult(1);
                else
                    return Task.FromResult(0);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Task<int> UpdateAsync(JourneyDTO journey)
        {
            try
            {
                journey.UserId = App.User.Id;
                endpoint += "/" + journey.Id;
                var response = BaseAPIService.Put<APIResponse>(endpoint, journey, _cancellationToken);
                response.Wait();
                if (response.Result != null)
                    return Task.FromResult(1);
                else
                    return Task.FromResult(0);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
