using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRTourismApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using HRTourismApp.Models.Core;

namespace HRTourismApp.Services.Tests
{
    [TestClass()]
    public class JourneyServiceTests
    {
        private JourneyService _journeyService;
        public JourneyServiceTests()
        {
            _journeyService = new JourneyService();
        }
        [TestMethod()]
        public async void SaveAsyncTest()
        {
            _journeyService = new JourneyService();
            JourneyDTO journey = new JourneyDTO();

            journey.CompanyId = 8;
            journey.UserId = 55;
            journey.DriverId = 129;
            journey.VehicleId = 35;
            journey.Fees = 250;
            journey.FinishDate = DateTime.Now.AddHours(2);
            journey.StartDate = DateTime.Now.AddHours(1);
            journey.From = "SDFSDFFFSDF";
            journey.To = "sdfsfsfssdf";
            
            int createdId = await _journeyService.SaveAsync(journey);
            Assert.AreEqual(createdId, 1);
        }
    }
}