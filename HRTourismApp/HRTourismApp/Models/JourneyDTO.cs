﻿using HRTourismApp.Models.Core;
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
        public string DriverName { get; set; }
        public int VehicleId { get; set; }
        public string VehiclePlaque { get; set; }
        public int CompanyId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public decimal Fees { get; set; }
        public long SeferReferansNo { get; set; }
        public string Description { get; set; }
        public int RecordStatus { get; set; }
        public int UserId { get; set; }

        public List<UserDTO> DriverList { get; set; }

        public List<VehicleDTO> VehicleList { get; set; }

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