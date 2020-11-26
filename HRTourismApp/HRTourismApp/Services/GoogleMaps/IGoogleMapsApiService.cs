using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRTourismApp.Services.GoogleMaps
{
    public interface IGoogleMapsApiService
    {
        Task<GooglePlaceAutoCompleteResult> GetPlaces(string text);
    }
}
