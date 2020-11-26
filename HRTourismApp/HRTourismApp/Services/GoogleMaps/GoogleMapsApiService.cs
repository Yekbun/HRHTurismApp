using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using HRTourismApp.APIServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace HRTourismApp.Services.GoogleMaps
{
    public class GoogleMapsApiService : IGoogleMapsApiService
    {
        static string _googleMapsKey;

        private const string ApiBaseAddress = "https://maps.googleapis.com/maps/";
        private HttpClient CreateClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseAddress)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
        public static void Initialize(string googleMapsKey)
        {
            _googleMapsKey = googleMapsKey;
        }

        public async Task<GooglePlaceAutoCompleteResult> GetPlaces(string text)
        {
            CancellationToken cancellationToken = new CancellationToken();
            string endpoint = ApiBaseAddress + $"api/place/autocomplete/json?input={Uri.EscapeUriString(text)}&region=TR&language=tr&key=" + _googleMapsKey;
            var responseTask = BaseAPIService.Get<GooglePlaceAutoCompleteResult>(endpoint, cancellationToken);
            return await Task.FromResult(responseTask.Result);
        }      

    }
}
