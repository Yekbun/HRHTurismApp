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

            
            ImageButton btnJourney = new ImageButton
            {
                Source = "journey.png",
                CornerRadius = 15,
                BackgroundColor = Color.White,
                Scale = 0.5,
            };
            ImageButton btnSettings = new ImageButton
            {
                Source = "settings4.png",
                CornerRadius = 15,
                BackgroundColor = Color.White,
                Scale = 0.5,
            };
            ImageButton btnTakePicture = new ImageButton
            {
                Source = "book2.png",
                CornerRadius = 15,
                BackgroundColor = Color.White,
                Scale = 0.5,
            };
            ImageButton ShNotes = new ImageButton
            {
                Source = "www2.png",
                CornerRadius = 15,
                BackgroundColor = Color.White,
                Scale = 0.5,
            };
         

            grid.Children.Add(btnJourney, 0, 0);
            grid.Children.Add(btnSettings, 1, 0);
            grid.Children.Add(btnTakePicture, 0, 1);
            grid.Children.Add(ShNotes, 1, 1);
            grid.ColumnSpacing = 20;
            grid.RowSpacing = 20;
            this.Padding = new Thickness(20, 160, 20, 20);
            Content = grid;

            btnTakePicture.Clicked += vm.btnBooking_clicked;
            btnJourney.Clicked += vm.btnJourney_clicked;
            btnSettings.Clicked += vm.btnSettings_clicked;
            // ShNotes.Clicked += vm.launchshnotes;
        }
    }
}