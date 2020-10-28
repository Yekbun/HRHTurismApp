using HRTourismApp.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace HRTourismApp.APIServices
{
    public class BookingService
    {
        /*
        private static string endpoint = Constanta.BASE_API_URL + "/company-booking";
        private static CancellationToken cancellationToken;

        public static Task<APIResponse> CreateBooking(object booking)
        {
            cancellationToken = new CancellationToken();
            return BaseAPIService.Post<APIResponse>(endpoint, booking, cancellationToken);
        }

        public static Task<APIResponse> UpdateBooking(object id, object booking)
        {
            endpoint += "/" + id;

            cancellationToken = new CancellationToken();
            return BaseAPIService.Put<APIResponse>(endpoint, booking, cancellationToken);
        }

        public static Task<APIResponse> GetAllBooking(Pagination pagination = null)
        {
            if (pagination != null)
                endpoint = EndpointHelper.Pagination(endpoint, pagination);

            cancellationToken = new CancellationToken();
            return BaseAPIService.Get<APIResponse>(endpoint, cancellationToken);
        }

        public static Task<APIResponse> GetBookingDetail(object id)
        {
            endpoint += "/" + id;

            cancellationToken = new CancellationToken();
            return BaseAPIService.Get<APIResponse>(endpoint, cancellationToken);
        }

        public static Task<APIResponse> DeleteBooking(object id)
        {
            endpoint += "/" + id;

            cancellationToken = new CancellationToken();
            return BaseAPIService.Delete<APIResponse>(endpoint, cancellationToken);
        }*/
    }
}
