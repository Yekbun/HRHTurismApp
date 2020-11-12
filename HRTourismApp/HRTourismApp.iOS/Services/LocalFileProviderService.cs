
using HRTourismApp.iOS.Services;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(LocalFileProviderService))]
namespace HRTourismApp.iOS.Services
{
    public class LocalFileProviderService : HRTourismApp.Services.ILocalFileProvider
    {
        public byte[] GetFileBytes(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }
    }
}