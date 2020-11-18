using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Views;
using HRTourismApp.Models;

namespace HRTourismApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public void OnSubmit()
        {
            if (email != "1" || password != "1")
            {
                DisplayInvalidLoginPrompt();
            }
            else
            {
                //await Navigation.PushAsync(new MainMenu());

                //new NavigationPage(new MainMenu());
                //Application.Current.MainPage.Navigation.PushAsync(new MainMenu());

                App.IsUserLoggedIn = true;
                
                App.User = new UserDTO { Id = 55, CompanyId = 8, CompanyName = "Firma 4 Yolcu Tasimacili", Email = "olcayyf @hotmail.com", NameSurname = "Feryat Olcay", Phone = "05378217440", RoleId = 1 };
                //TODO:Login 
                App.Current.MainPage = new NavigationPage(new MainMenu());

            }
        }
       
    }
}