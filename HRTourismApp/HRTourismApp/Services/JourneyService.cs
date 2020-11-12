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
    public class JourneyService //: IBaseCrud<JourneyModal>
    {
        private string endpoint = Constants.BASE_API_URL + "api/Journeys";
        private static CancellationToken cancellationToken;

        public List<JourneyDTO> MockJourneyData()
        {
            List<JourneyDTO> journeys = new List<JourneyDTO>()
            {
                new JourneyDTO { Id = 1, From= "Sirinevler", To="bakirkoy", StartDate=DateTime.Today.AddDays(-1).AddHours(-2), FinishDate=DateTime.Today.AddDays(-1).AddHours(-1) ,VehicleId=1, DriverId=1, Fees=100},
                new JourneyDTO { Id = 2, From= "Yenibosna", To="mecodoye", StartDate=DateTime.Today.AddDays(-1).AddHours(-1), FinishDate=DateTime.Today.AddDays(-1) ,VehicleId=1, DriverId=1, Fees=100},
                new JourneyDTO { Id = 3, From= "Sirin dfssdfsevler", To="dfg", StartDate=DateTime.Today.AddHours(-5), FinishDate=DateTime.Today.AddHours(-4) ,VehicleId=1, DriverId=1, Fees=200},
                new JourneyDTO { Id = 4, From= "Sirasdasdasdainevler", To="gdfg", StartDate=DateTime.Today.AddHours(-4), FinishDate=DateTime.Today.AddHours(-3) ,VehicleId=1, DriverId=1, Fees=400},
                new JourneyDTO { Id = 5, From= "Si rinvsdfdfsdfsevler", To="sdasda", StartDate=DateTime.Today.AddHours(-3), FinishDate=DateTime.Today.AddHours(-2) ,VehicleId=1, DriverId=1, Fees=300},
                new JourneyDTO { Id = 6, From= "asdasdasd", To="asdadada", StartDate=DateTime.Today.AddHours(-2), FinishDate=DateTime.Today.AddHours(-1) ,VehicleId=1, DriverId=1, Fees=150},
            };
            return journeys;
        }

        public JourneyService()
        {

        }
        
        public Task<List<JourneyDTO>> GetAllJourney(/*Pagination pagination = null,*/ int companyId)
        {
            endpoint = Constants.BASE_API_URL + "api/company/"+companyId+"/Journeys";
            /*
            if (pagination != null)
               endpoint = EndpointHelper.Pagination(endpoint, pagination);
            */
                       
            cancellationToken = new CancellationToken();
            var responseTask = BaseAPIService.Get<List<JourneyDTO>>(endpoint, cancellationToken);            
           return Task.FromResult(responseTask.Result);
        }


        public Task<int> DeleteAsync(long id, int userId, string cancelDesc)
        {
            endpoint += "?id=" + id + " & userId = " + userId+ " & cancelDesc = '"+cancelDesc+"'";

            cancellationToken = new CancellationToken();
            var responseTask =BaseAPIService.Delete<APIResponse>(endpoint, cancellationToken);

            return Task.FromResult(1);
        }

        public Task<JourneyDTO> GetJourney(long id)
        {
            endpoint += "/" + id;

            cancellationToken = new CancellationToken();
            var responseTask = BaseAPIService.Get<JourneyDTO>(endpoint, cancellationToken);
            return Task.FromResult(responseTask.Result);
        }

        public Task<int> SaveAsync(JourneyDTO journey)
        {         
            cancellationToken = new CancellationToken();
            var responseTask = BaseAPIService.Post<APIResponse>(endpoint, journey, cancellationToken);

            return Task.FromResult(1);
        }

        public Task<int> UpdateAsync(JourneyDTO journey)
        {
            endpoint += "/" + journey.Id;

            cancellationToken = new CancellationToken();
            var response= BaseAPIService.Put<APIResponse>(endpoint, journey, cancellationToken);

            return Task.FromResult(1);
        }
    }
}
