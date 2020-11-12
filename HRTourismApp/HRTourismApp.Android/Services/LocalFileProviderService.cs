using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(HRTourismApp.Droid.Services.LocalFileProviderService))]
namespace HRTourismApp.Droid.Services
{
    public class LocalFileProviderService : HRTourismApp.Services.ILocalFileProvider
    {
        public byte[] GetFileBytes(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }
    }
}