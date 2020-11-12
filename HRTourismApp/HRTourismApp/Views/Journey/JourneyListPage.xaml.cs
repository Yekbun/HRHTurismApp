using HRTourismApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HRTourismApp.ViewModels.Journey;
using HRTourismApp.Models.Core;

namespace HRTourismApp.Views.Journey
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JourneyListPage : ContentPage
    {
        private JourneyListViewModel journeyListViewModel;

        public JourneyListPage()
        {
            InitializeComponent();
            journeyListViewModel = new JourneyListViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            journeyListViewModel.JourneyList = await journeyListViewModel.GetAllJourney();
            BindingContext = journeyListViewModel;
        }

        private void ListViewJourney_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            JourneyDTO item = (JourneyDTO)e.Item;
            if (item == null)
                return;

            journeyListViewModel.GetSelectedJourney(item);
        }
        

    }
}

