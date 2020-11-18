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
    public partial class JourneyDTO
    {
        public long Id { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; } //TODO:Silinecek
        public int VehicleId { get; set; }
        public string VehiclePlaque { get; set; }//TODO:Silinecek
        public int CompanyId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime FinishDateTime { get; set; }
        public decimal Fees { get; set; }
        public long SeferReferansNo { get; set; }
        public string Description { get; set; }
        public int RecordStatus { get; set; }
        public int UserId { get; set; }

      

        public ICommand ShowPassengers
        {
            get { return new Command(() => showPassengers(Id)); }
        }
        
        private async void showPassengers(long journeyId)
        {
            if (journeyId != 0)
            {
                await NavigationHelper.PushAsyncSingle(new PassengerListPage(journeyId));
            }else
            {
                throw (new ArgumentNullException("Yolculuk tanimlanmadan yolcu girilemez."));
            }
        }
    }
}
