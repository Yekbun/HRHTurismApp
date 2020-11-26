using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace HRTourismApp.Helpers
{
    public static class NetworkHelper
    {
        public static bool IsNetworkConnected()
        {
            bool isNetworkConnected = false;

            try
            {
                var profiles = Connectivity.ConnectionProfiles;
                if (profiles.Contains(ConnectionProfile.Cellular) || profiles.Contains(ConnectionProfile.WiFi))
                {
                    NetworkAccess currentNetworkAccess = Connectivity.NetworkAccess;
                    if (currentNetworkAccess == NetworkAccess.Internet)
                        isNetworkConnected = true;
                }
            }
            catch (Exception exception)
            {
                LogHelper.WriteLog(exception);
            }

            return isNetworkConnected;
        }

        public static async Task<HttpClient> CustomHttpClient()
        {
            if (!IsNetworkConnected())
                throw new MobileException("Please check your connection setting");

            HttpClientHandler defaultClientHandler = new HttpClientHandler();
            defaultClientHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            defaultClientHandler.AllowAutoRedirect = false;

            HttpClient httpClient = new HttpClient(defaultClientHandler);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.Timeout = TimeSpan.FromSeconds(Constants.CURRENT_TIMEOUT);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            string currentAccessToken = await TokenHelper.GetAccessToken();
            if (!string.IsNullOrEmpty(currentAccessToken))
                httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + currentAccessToken);

            return httpClient;
        }

        public static HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                MemoryStream memoryStream = new MemoryStream();

                SerializeJsonToStream(content, memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                httpContent = new StreamContent(memoryStream);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }

        public static T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            StreamReader streamReader = null;

            try
            {
                streamReader = new StreamReader(stream);

                JsonTextReader jsonTextReader = new JsonTextReader(streamReader);
                JsonSerializer jsonSerializer = new JsonSerializer();
                T result = jsonSerializer.Deserialize<T>(jsonTextReader);
                return result;
            }
            finally
            {
                if (streamReader != null)
                    stream.Dispose();
            }
        } 

        //TODO:silinecek
        public static int DeserializeJsonFromStream(Stream stream)
        {            
            StreamReader streamReader = null;

            try
            {
                streamReader = new StreamReader(stream);

                JsonTextReader jsonTextReader = new JsonTextReader(streamReader);
                JsonSerializer jsonSerializer = new JsonSerializer();
                var result = jsonSerializer.Deserialize(jsonTextReader);
                return 1;
            }
            finally
            {
                if (streamReader != null)
                    stream.Dispose();
            }
        }

        public static void SerializeJsonToStream(object value, Stream stream)
        {
            StreamWriter streamWriter = null;

            try
            {
                streamWriter = new StreamWriter(stream, new UTF8Encoding(false), 1024, true);

                JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter);
                jsonTextWriter.Formatting = Formatting.None;

                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(jsonTextWriter, value);
                jsonTextWriter.Flush();
            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Dispose();
            }
        }
    }
}
