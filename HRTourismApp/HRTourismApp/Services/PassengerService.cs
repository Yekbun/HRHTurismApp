using HRTourismApp.Models.HRTourismApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRTourismApp.LocalDatabase;

namespace HRTourismApp.Services
{
    public class PassengerService : IBaseCrud<PassengerModel>
    {
        public List<PassengerModel> MockJourneyData()
        {
            List<PassengerModel> journeys = new List<PassengerModel>()
            {
                new PassengerModel { Id = 1,JourneyId=1, FirstName="Feryat",LastName="Olcay", DocumentNo="435353453",HesKodu ="sdfsdfsdf", Phone="0538964222", CountryCode="TR"},
                new PassengerModel { Id = 2,JourneyId=1, FirstName="Patrick",LastName="Pater", DocumentNo="5455",HesKodu ="454rfgdfg", Phone="05389455342", CountryCode="PL"}
            };
            return journeys;
        }
        public Task<int> DeleteAsync(PassengerModel item)
        {
            throw new NotImplementedException();
        }

        public Task<List<PassengerModel>> GetAllAsync()
        {
            var Data = MockJourneyData();
            return Task.FromResult(Data);
        }

        public Task<PassengerModel> GetItemAsync(string id)
        {
            var passenger = new PassengerModel { Id = 2, FirstName = "Patrick", LastName = "Pater", DocumentNo = "5455", HesKodu = "454rfgdfg", Phone = "05389455342", CountryCode = "PL" };
            return Task.FromResult(passenger);
        }

        public Task<int> SaveAsync(PassengerModel item)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(PassengerModel item)
        {
            throw new NotImplementedException();
        }
    }
}
