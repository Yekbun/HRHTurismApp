using System;
using System.Collections.Generic;
using System.Text;

namespace HRTourismApp.Services
{
    public interface ILocalFileProvider
    {
        byte[] GetFileBytes(string filePath);
    }
}
