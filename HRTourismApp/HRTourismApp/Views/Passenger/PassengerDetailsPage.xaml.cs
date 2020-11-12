﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HRTourismApp.ViewModels.Passenger;
using HRTourismApp.Models;

namespace HRTourismApp.Views.Passenger
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengerDetailsPage : ContentPage
    {
        private PassengerDetailViewModel passengerDetailViewModel;
        public PassengerDetailsPage()
        {
            InitializeComponent();
        }
        public PassengerDetailsPage(PassengerDTO passenger)
        {
            InitializeComponent();

            passengerDetailViewModel = new PassengerDetailViewModel();
            
            if (passenger != null)
                passengerDetailViewModel.Passenger = passenger;

            BindingContext = passengerDetailViewModel;
        }
    }
}