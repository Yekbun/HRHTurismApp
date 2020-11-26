using HRTourismApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace HRTourismApp.Helpers
{
    public class TokenHelper
    {
        private static string GetRefreshToken()
        {
            string refreshToken = string.Empty;

            if (Preferences.ContainsKey("RefreshToken"))
                refreshToken = Preferences.Get("RefreshToken", null);

            return refreshToken;
        }

        public static async Task<string> GetAccessToken()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            string expiresIn = string.Empty;
            if (Preferences.ContainsKey("ExpiresIn"))
                expiresIn = Preferences.Get("ExpiresIn", null);

            if (!string.IsNullOrEmpty(expiresIn))
            {
                int currentExpirySeconds = int.Parse(expiresIn);
                int currentSeconds = DateTime.Now.Second;
                int substractSeconds = currentExpirySeconds - currentSeconds;

                // Refresh token
                string refreshToken = GetRefreshToken();
                if (substractSeconds <= 0 && !string.IsNullOrEmpty(refreshToken))
                {
                    try
                    {
                        string endpoint = Constants.BASE_API_URL + "/token";

                        Dictionary<string, string> refreshTokenParams = new Dictionary<string, string>
                        {
                            { "refresh_token", refreshToken },
                            { "grant_type", "refresh_token" },
                            { "client_id", "TripceteraMobile" },
                            { "client_secret", "secret" }
                        };

                        using (var httpClient = new HttpClient())
                        {
                            HttpContent httpContent = new FormUrlEncodedContent(refreshTokenParams);

                            HttpResponseMessage httpResponse = await httpClient.PostAsync(endpoint, httpContent, cancellationTokenSource.Token);
                            httpResponse.EnsureSuccessStatusCode();

                            Stream stream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                            TokenDTO tokenDTO = NetworkHelper.DeserializeJsonFromStream<TokenDTO>(stream);
                            if (tokenDTO != null)
                            {
                                // Overide old values
                                Preferences.Set("AccessToken", tokenDTO.access_token);
                                Preferences.Set("RefreshToken", tokenDTO.refresh_token);
                                Preferences.Set("ExpiresIn", tokenDTO.expires_in);
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        LogHelper.WriteLog(exception);
                    }
                }
            }

            return Preferences.Get("AccessToken", null);
        }
    }
}
