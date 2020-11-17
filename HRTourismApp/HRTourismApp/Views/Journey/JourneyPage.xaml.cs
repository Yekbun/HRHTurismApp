using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HRTourismApp.ViewModels.Journey;
using HRTourismApp.Models.Core;

namespace HRTourismApp.Views.Journey
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JourneyPage : ContentPage
    {
        private JourneyViewModel journeyCreateViewModel;
        private JourneyUpdateViewModel journeyUpdateViewModel;

        public JourneyPage()
        {
            InitializeComponent();

            journeyCreateViewModel = new JourneyViewModel();

            // Set default text
            Title = "Create Journey";
            btnJourney.Text = "Create";

            BindingContext = journeyCreateViewModel;
        }

        public JourneyPage(JourneyDTO journey = null)
        {
            if (journey == null)
                return;

            InitializeComponent();

            journeyUpdateViewModel = new JourneyUpdateViewModel();
            journeyUpdateViewModel.Journey = journey;

            // Set default text
            Title = "Update Journey";
            btnJourney.Text = "Update";

            BindingContext = journeyUpdateViewModel;
        }
    }
}