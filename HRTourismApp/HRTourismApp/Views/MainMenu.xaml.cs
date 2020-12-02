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
            vm.CompanyName = App.User.CompanyName;
            vm.UserName = App.User.NameSurname;
            if (App.User.RoleId == 1)
            {
                vm.RoleName = "Admin";
            }
            else if (App.User.RoleId == 2)
            {
                vm.RoleName = "User";
            }
            else
            {
                vm.RoleName = "Sürücü";
            }

            this.BindingContext = vm;
            InitializeComponent();
                        
            btnJourney.Source = "journey.png";
            btnJourney.CornerRadius = 15;
            btnJourney.BackgroundColor = Color.White;
            btnJourney.Scale = 0.5;

            btnSettings.Source = "settings4.png";
            btnSettings.CornerRadius = 15;
            btnSettings.BackgroundColor = Color.White;
            btnSettings.Scale = 0.5;                        
           
           btnJourney.Clicked += vm.btnJourney_clicked;
            btnSettings.Clicked += vm.btnSettings_clicked;
           
        }
    }
}