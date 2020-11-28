using System;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Helpers;
using HRTourismApp.Views.Passenger;
using System.Collections.Generic;

namespace HRTourismApp.Models
{
    public partial class PassengerDTO
    {
        public long Id { get; set; }
        public long JourneyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Phone { get; set; }
        public string DocumentNo { get; set; }
        public string Gender { get; set; }
        public int SeatNumber { get; set; }
        public int RecordStatus { get; set; }
        public string HesKodu { get; set; }
        public int UserId { get; set; }
        public long YolcuRefNo { get; set; }

      
    }


}


