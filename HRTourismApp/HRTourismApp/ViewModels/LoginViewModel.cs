using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Views;

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
                App.Current.MainPage = new NavigationPage(new MainMenu());

            }
        }
        // public async Task GotoPage2()
        // {
        /////
        //await Application.Current.MainPage.Navigation.PushAsync(new MainMenu());
        //}
    }
}