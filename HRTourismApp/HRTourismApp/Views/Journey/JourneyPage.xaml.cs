﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HRTourismApp.ViewModels.Journey;
using HRTourismApp.Models.Core;
using HRTourismApp.Models;

namespace HRTourismApp.Views.Journey
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JourneyPage : ContentPage
    {
        private JourneyViewModel _journeyViewModel;        

        public JourneyPage()
        {
            InitializeComponent();

            _journeyViewModel = new JourneyViewModel();

            // Set default text
            Title = "Yeni Yolculuk";
            btnSave.IsVisible = true;
            btnCancel.IsVisible = false;
            btnUpdate.IsVisible = false;
            _journeyViewModel.Journey.StartDate = DateTime.Now;
            _journeyViewModel.Journey.FinishDate = DateTime.Now;            

            BindingContext = _journeyViewModel;
        }

        public JourneyPage(JourneyDTO journey)
        {
            if (journey == null)
                return;

            InitializeComponent();           

            _journeyViewModel = new JourneyViewModel();
            _journeyViewModel.Journey = journey;

            // Set default text
            Title = "Yolculuk Güncelleme";
            btnSave.IsVisible = false;
            btnCancel.IsVisible = true;
            btnUpdate.IsVisible = true;
            BindingContext = _journeyViewModel;           
        }

        private void pickerDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            if (picker.SelectedIndex > -1)
            {
                _journeyViewModel.Journey.DriverId = ((UserDTO)picker.SelectedItem).Id;
                _journeyViewModel.Journey.DriverName = ((UserDTO)picker.SelectedItem).NameSurname;
            }
        }

        private void pickerVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            if (picker.SelectedIndex > -1)
            {
                _journeyViewModel.Journey.VehicleId = ((VehicleDTO)picker.SelectedItem).Id;
                _journeyViewModel.Journey.VehiclePlaque = ((VehicleDTO)picker.SelectedItem).Plaque;
            }
        }
    }
}