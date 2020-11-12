using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using HRTourismApp.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(IDeleteFromFile))]
namespace HRTourismApp.iOS.Services
{
    public class DeleFromFile : IDeleteFromFile
    {
        public void DeleteFile(string source)
        {
            System.IO.File.Delete(source);
        }

        public string HelloMello(string aaa)
        {
            return aaa + "Bu ne salak bisey yaaa ISO";
        }
    }
}