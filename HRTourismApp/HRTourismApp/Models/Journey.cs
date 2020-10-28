using HRTourismApp.Models.Core;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Helpers;
using HRTourismApp.Views.Journey;
using HRTourismApp.Views.Passenger;

namespace HRTourismApp.Models.Core
{
    public partial class Journey
    {
        public long Id { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public int CompanyId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public decimal Fees { get; set; }
        public long SeferReferansNo { get; set; }
        public int UetdsStatus { get; set; }
        public string UetdsMessage { get; set; }
        public bool IsActive { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual Company Company { get; set; }
        public virtual User CreateUser { get; set; }
        public virtual User Driver { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual List<Passenger> Passengers { get; set; }
        public virtual List<Group> Groups { get; set; }
        public string Description { get; set; }
        public int FromCityId { get; set; }
        public int FromDistrictId { get; set; }
        public int ToCityId { get; set; }
        public int ToDistrictId { get; set; }

    }
}
namespace HRTourismApp.Models
{
    public class JourneyModal:Journey    
    {
        public string StartDateTime { get; set; }
        public string FinishDateTime { get; set; }

        public ICommand ShowPassengers
        {
            get { return new Command(() => showPassengers()); }
        }
        
        private async void showPassengers()
        {
            await NavigationHelper.PushAsyncSingle(new PassengerListPage());
        }
    }
}
