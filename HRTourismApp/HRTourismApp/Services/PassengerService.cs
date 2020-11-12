using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRTourismApp.Models;

namespace HRTourismApp.Services
{
    public class PassengerService
    {
        public List<PassengerDTO> MockJourneyData()
        {
            List<PassengerDTO> journeys = new List<PassengerDTO>()
            {
                new PassengerDTO { Id = 1,JourneyId=1, FirstName="Feryat",LastName="Olcay", DocumentNo="435353453",HesKodu ="sdfsdfsdf", Phone="0538964222"},
                new PassengerDTO { Id = 2,JourneyId=1, FirstName="Patrick",LastName="Pater", DocumentNo="5455",HesKodu ="454rfgdfg", Phone="05389455342"}
            };
            return journeys;
        }
        public Task<int> DeleteAsync(PassengerDTO item)
        {
            throw new NotImplementedException();
        }

        public Task<List<PassengerDTO>> GetAllAsync()
        {
            var Data = MockJourneyData();
            return Task.FromResult(Data);
        }

        public Task<PassengerDTO> GetItemAsync(string id)
        {
            var passenger = new PassengerDTO { Id = 2, FirstName = "Patrick", LastName = "Pater", DocumentNo = "5455", HesKodu = "454rfgdfg", Phone = "05389455342" };
            return Task.FromResult(passenger);
        }

        public Task<int> SaveAsync(PassengerDTO item)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(PassengerDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
