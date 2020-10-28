using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HRTourismApp.ViewModels;

namespace HRTourismApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            var vm = new MainMenuViewModel();
            this.BindingContext = vm;
            InitializeComponent();
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            ImageButton btnBooking = new ImageButton
            {
                Source = "book2.png",
                CornerRadius = 20,
                BackgroundColor = Color.White,
                Scale = 0.5,
            };
            ImageButton btnJourney = new ImageButton
            {
                Source = "calendar1.png",
                CornerRadius = 20,
                BackgroundColor = Color.White,
                Scale = 0.5,
            };
            
            ImageButton ShNotes = new ImageButton
            {
                Source = "www2.png",
                CornerRadius = 20,
                BackgroundColor = Color.White,
                Scale = 0.5,
            };
            ImageButton settings = new ImageButton
            {
                Source = "settings4.png",
                CornerRadius = 20,
                BackgroundColor = Color.White,
                Scale = 0.5,
            };
            
            grid.Children.Add(btnBooking, 0, 0);
            grid.Children.Add(btnJourney, 1, 0);
            grid.Children.Add(ShNotes, 0, 1);
           grid.Children.Add(settings, 1, 1);
            grid.ColumnSpacing = 20;
            grid.RowSpacing = 20;
            this.Padding = new Thickness(20, 160, 20, 20);
            Content = grid;

            btnBooking.Clicked += vm.btnBooking_clicked;
            btnJourney.Clicked += vm.btnJourney_clicked;
           // settings.Clicked += vm.launchsettings;
           // ShNotes.Clicked += vm.launchshnotes;
        }
    }
}