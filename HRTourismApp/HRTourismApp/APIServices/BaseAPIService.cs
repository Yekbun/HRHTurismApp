using HRTourismApp.Helpers;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HRTourismApp.APIServices
{
    public static class BaseAPIService
    {
        private static HttpClient httpClient;
        private static HttpContent httpContent;

        public static async Task<T> Post<T>(string endpoint, object content, CancellationToken cancellationToken) where T : class
        {
            T response = null;

            try
            {
                httpClient = await NetworkHelper.CustomHttpClient().ConfigureAwait(false);
                httpContent = NetworkHelper.CreateHttpContent(content);

                HttpResponseMessage httpResponse = await httpClient.PostAsync(endpoint, httpContent, cancellationToken).ConfigureAwait(false);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Stream stream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    response = NetworkHelper.DeserializeJsonFromStream<T>(stream);
                }
                
            }
            catch (OperationCanceledException operationCanceledException)
            {
                throw(operationCanceledException);
            }
            catch (HttpRequestException httpRequestException)
            {
                throw (httpRequestException);
            }
            catch (MobileException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                LogHelper.WriteLog(exception, cancellationToken);
            }

            return response;
        }

        public static async Task<bool> Post(string endpoint, object content, CancellationToken cancellationToken) 
        {
            bool result = false;

            try
            {
                httpClient = await NetworkHelper.CustomHttpClient().ConfigureAwait(false);
                httpContent = NetworkHelper.CreateHttpContent(content);

                HttpResponseMessage httpResponse = await httpClient.PostAsync(endpoint, httpContent, cancellationToken).ConfigureAwait(false);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Stream stream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    result = true;
                }

            }
            catch (OperationCanceledException operationCanceledException)
            {
                throw (operationCanceledException);
            }
            catch (HttpRequestException httpRequestException)
            {
                throw (httpRequestException);
            }
            catch (MobileException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                LogHelper.WriteLog(exception, cancellationToken);
            }

            return result;
        }

        public static async Task<T> Put<T>(string endpoint, object content, CancellationToken cancellationToken) where T : class
        {
            T response = null;

            try
            {
                httpClient = await NetworkHelper.CustomHttpClient().ConfigureAwait(false);
                httpContent = NetworkHelper.CreateHttpContent(content);

                HttpResponseMessage httpResponse = await httpClient.PutAsync(endpoint, httpContent, cancellationToken).ConfigureAwait(false);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Stream stream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    response = NetworkHelper.DeserializeJsonFromStream<T>(stream);
                }
            }
            catch (OperationCanceledException operationCanceledException)
            {
                throw (operationCanceledException);
            }
            catch (HttpRequestException httpRequestException)
            {
                throw (httpRequestException);
            }
            catch (MobileException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                LogHelper.WriteLog(exception, cancellationToken);
            }

            return response;
        }

        public static async Task<T> Get<T>(string endpoint, CancellationToken cancellationToken) where T : class
        {
            T response = null;

            try
            {
                httpClient = await NetworkHelper.CustomHttpClient().ConfigureAwait(false);

                HttpResponseMessage httpResponse = await httpClient.GetAsync(endpoint, HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false);
                Stream stream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                response = NetworkHelper.DeserializeJsonFromStream<T>(stream);
            }
            catch (OperationCanceledException operationCanceledException)
            {
                throw (operationCanceledException);
            }
            catch (HttpRequestException httpRequestException)
            {
                throw (httpRequestException);
            }
            catch (MobileException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                LogHelper.WriteLog(exception, cancellationToken);
            }

            return response;
        }

        public static async Task<T> Delete<T>(string endpoint, CancellationToken cancellationToken) where T : class
        {
            T response = null;

            try
            {
                httpClient = await NetworkHelper.CustomHttpClient().ConfigureAwait(false);

                HttpResponseMessage httpResponse = await httpClient.DeleteAsync(endpoint, cancellationToken).ConfigureAwait(false);
                Stream stream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                response = NetworkHelper.DeserializeJsonFromStream<T>(stream);
            }
            catch (OperationCanceledException operationCanceledException)
            {
                throw (operationCanceledException);
            }
            catch (HttpRequestException httpRequestException)
            {
                throw (httpRequestException);
            }
            catch (MobileException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                LogHelper.WriteLog(exception, cancellationToken);
            }

            return response;
        }
    }
}
