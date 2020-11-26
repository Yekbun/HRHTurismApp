using HRTourismApp.APIServices;
using HRTourismApp.Helpers;
using HRTourismApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRTourismApp.Services
{
    public class LoginService
    {
        private string endpoint = Constants.BASE_API_URL;
        private CancellationToken _cancellationToken;
        public LoginService()
        {
            _cancellationToken = new CancellationToken();
        }
    
        public UserDTO Login(LoginDTO login)
        {
            UserDTO result = null;  
           try
            {
                login.Password = login.Password;
                _cancellationToken = new CancellationToken();
                endpoint += "api/Login";
                var postTask = BaseAPIService.Post<UserDTO>(endpoint, login, _cancellationToken);
                postTask.Wait();
                result = postTask.Result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return result;
        }
    }
}
