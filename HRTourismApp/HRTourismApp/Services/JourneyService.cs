using HRTourismApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRTourismApp.LocalDatabase;
using HRTourismApp.Models;

namespace HRTourismApp.Services
{
    public class JourneyService : IBaseCrud<JourneyModal>
    {
        public List<JourneyModal> MockJourneyData()
        {
            List<JourneyModal> journeys = new List<JourneyModal>()
            {
                new JourneyModal { Id = 1, From= "Sirinevler", To="bakirkoy", StartDate=DateTime.Today.AddDays(-1).AddHours(-2), FinishDate=DateTime.Today.AddDays(-1).AddHours(-1) ,VehicleId=1, DriverId=1, Fees=100},
                new JourneyModal { Id = 2, From= "Yenibosna", To="mecodoye", StartDate=DateTime.Today.AddDays(-1).AddHours(-1), FinishDate=DateTime.Today.AddDays(-1) ,VehicleId=1, DriverId=1, Fees=100},
                new JourneyModal { Id = 3, From= "Sirin dfssdfsevler", To="dfg", StartDate=DateTime.Today.AddHours(-5), FinishDate=DateTime.Today.AddHours(-4) ,VehicleId=1, DriverId=1, Fees=200},
                new JourneyModal { Id = 4, From= "Sirasdasdasdainevler", To="gdfg", StartDate=DateTime.Today.AddHours(-4), FinishDate=DateTime.Today.AddHours(-3) ,VehicleId=1, DriverId=1, Fees=400},
                new JourneyModal { Id = 5, From= "Si rinvsdfdfsdfsevler", To="sdasda", StartDate=DateTime.Today.AddHours(-3), FinishDate=DateTime.Today.AddHours(-2) ,VehicleId=1, DriverId=1, Fees=300},
                new JourneyModal { Id = 6, From= "asdasdasd", To="asdadada", StartDate=DateTime.Today.AddHours(-2), FinishDate=DateTime.Today.AddHours(-1) ,VehicleId=1, DriverId=1, Fees=150},
            };
            return journeys;
        }
        public Task<List<JourneyModal>> GetAllAsync()
        {
            var Data = MockJourneyData();
            return Task.FromResult(Data);
        }

        public Task<int> DeleteAsync(JourneyModal item)
        {
            return Task.FromResult(1);
        }

        public Task<JourneyModal> GetItemAsync(string id)
        {
            var journey = new JourneyModal { Id = 6, From = "asdasdasd", To = "asdadada", StartDate = DateTime.Today.AddHours(-2), FinishDate = DateTime.Today.AddHours(-1), VehicleId = 1, DriverId = 1, Fees = 150 };
            return Task.FromResult(journey);
        }

        public Task<int> SaveAsync(JourneyModal item)
        {
            return Task.FromResult(1);
        }

        public Task<int> UpdateAsync(JourneyModal item)
        {
            return Task.FromResult(1);
        }
    }
}
