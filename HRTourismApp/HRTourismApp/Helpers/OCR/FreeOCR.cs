using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace HRTourismApp.Helpers.OCR
{
    public class FreeOCR
    {
        public async System.Threading.Tasks.Task<string> SendImageAsync(byte[] imageData)
        {
            string retVal = "";

            if (imageData == null)
                return retVal = "Data bos";

            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(1, 1, 1);

                MultipartFormDataContent form = new MultipartFormDataContent();
                form.Add(new StringContent("14a725812e88957"), "apikey"); //Added api key in form data
                form.Add(new StringContent("eng"), "language");

                form.Add(new StringContent("2"), "ocrengine");
                form.Add(new StringContent("true"), "scale");
                form.Add(new StringContent("true"), "istable");


                //    byte[] imageData = File.ReadAllBytes(ImagePath);
                form.Add(new ByteArrayContent(imageData, 0, imageData.Length), "image", "image.jpg");


                HttpResponseMessage response = await httpClient.PostAsync("https://api.ocr.space/Parse/Image", form);

                string strContent = await response.Content.ReadAsStringAsync();
                Rootobject ocrResult = JsonConvert.DeserializeObject<Rootobject>(strContent);


                if (ocrResult.OCRExitCode == 1)
                {
                    for (int i = 0; i < ocrResult.ParsedResults.Count(); i++)
                    {
                        retVal = retVal + ocrResult.ParsedResults[i].ParsedText;
                    }
                }
                else
                {
                    retVal = "ERROR: " + strContent;
                }
            }
            catch (Exception exception)
            {
                retVal = exception.Message;
            }

            return retVal;

        }
    }
}