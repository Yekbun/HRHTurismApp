using System;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Helpers;
using HRTourismApp.Views.Passenger;

namespace HRTourismApp.Models
{
    public partial class Passenger
    {
        public long Id { get; set; }
        public long JourneyId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }      
        public string DocumentNo { get; set; }
        public string Phone { get; set; } 
        public string CountryCode { get; set; }
        public string Gender { get; set; }
        public string HesKodu { get; set; }
        public int SeatNumber { get; set; }
        public long YolcuRefNo { get; set; }
        public int UetdsStatus { get; set; }
        public string UetdsMessage { get; set; }
        public long GrupReferensNo { get; set; }     
        public bool IsActive { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

    }

    namespace HRTourismApp.Models
    {
        public class PassengerModel : Passenger
        {            

            public ICommand AddPassenger
            {
                get { return new Command(() => addPassenger()); }
            }

            private async void addPassenger()
            {
                await NavigationHelper.PushAsyncSingle(new PassengerPage());
            }
        }


    }

}
