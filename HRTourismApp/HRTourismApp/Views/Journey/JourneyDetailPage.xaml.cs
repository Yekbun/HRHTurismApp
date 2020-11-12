using HRTourismApp.Models;
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
    public partial class JourneyDetailPage : ContentPage
    {
        private JourneyDetailViewModel _journeyDetailViewModel;
        public JourneyDetailPage()
        {
            InitializeComponent();
        }

        public JourneyDetailPage(JourneyDTO journey)
        {
            InitializeComponent();

            _journeyDetailViewModel = new JourneyDetailViewModel();

           if (journey != null)
                _journeyDetailViewModel.Journey = journey;

            BindingContext = _journeyDetailViewModel;
        }
    }
}