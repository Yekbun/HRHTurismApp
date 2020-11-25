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
    public class JourneyService //: IBaseCrud<JourneyModal> TODO: buna bir bak
    {
        private string endpoint = Constants.BASE_API_URL + "api/Journey";
        private static CancellationToken _cancellationToken;

        public JourneyService()
        {
            _cancellationToken = new CancellationToken();
        }

        public Task<List<JourneyDTO>> GetAllJourney(/*Pagination pagination = null,*/)
        {
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
                journey.From = "Şirinevler, Bahçelievler/İstanbul";
                journey.To = "Mecidiyeköy, Şişli/İstanbul";

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
