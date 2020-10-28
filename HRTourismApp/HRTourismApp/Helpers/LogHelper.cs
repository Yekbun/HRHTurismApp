using System;
using System.Net.Http;
using System.Threading;

namespace HRTourismApp.Helpers
{
    public class LogHelper
    {
        public static async void WriteLog(Exception exception, CancellationToken cancellationToken = default)
        {
            string endpoint = Constant.BASE_API_URL + "/error/log-error";

            try
            {
                var httpClient = await NetworkHelper.CustomHttpClient().ConfigureAwait(false);
                var httpContent = NetworkHelper.CreateHttpContent(exception);

                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint);
                httpRequestMessage.Content = httpContent;

                await httpClient.SendAsync(httpRequestMessage, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException operationCanceledException)
            {
                Console.WriteLine(operationCanceledException.Message);
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine(httpRequestException.Message);
            }
        }
    }
}
