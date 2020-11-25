using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using HRTourismApp.Views;
using HRTourismApp.Models;
using HRTourismApp.Services;

namespace HRTourismApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string _userName;
        private string _password;
        private LoginService _loginService;
        public string Email
        {
            get { return _userName; }
            set
            {
                _userName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            _loginService = new LoginService();
            SubmitCommand = new Command(OnSubmit);
        }
        public void OnSubmit()
        {
            if (string.IsNullOrEmpty(_userName) || string.IsNullOrEmpty(_password))
            {
                DisplayInvalidLoginPrompt();
            }
            else
            {
                UserDTO loginedUser = null;
                LoginDTO login = new LoginDTO { UserName = _userName, Password = _password };
                loginedUser = _loginService.Login(login);
                if (loginedUser != null)
                {
                    App.IsUserLoggedIn = true;
                    App.User = loginedUser;
                    //App.User = new UserDTO { Id = 55, CompanyId = 8, CompanyName = "Firma 4 Yolcu Tasimacili", Email = "olcayyf @hotmail.com", NameSurname = "Feryat Olcay", Phone = "05378217440", RoleId = 1 };

                    App.Current.MainPage = new NavigationPage(new MainMenu());
                }
            }

        }
    }

}
