using System.IO;
using HRTourismApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(HRTourismApp.Droid.Services.DeleFromFile))]
namespace HRTourismApp.Droid.Services
{
    public class DeleFromFile : IDeleteFromFile
    {
        public void DeleteFile(string source)
        {
            System.IO.File.Delete(source);
        }

        public string HelloMello(string aaa)
        {
            return aaa + "Bu ne salak bisey yaaa Android";
        }
    }
}