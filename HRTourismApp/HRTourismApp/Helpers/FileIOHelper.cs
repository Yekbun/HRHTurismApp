using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HRTourismApp.Helpers
{
    public class FileIOHelper
    {
        public async static Task<string> ReadData(string fileName)
        {
            try
            {

                var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);

                if (backingFile == null || !File.Exists(backingFile))
                {
                    return null;
                }
                string FileData = string.Empty;
                using (var reader = new StreamReader(backingFile, true))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        FileData = line;
                    }
                }

                return FileData;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public async static Task SaveData(string Data, string fileName)
        {
            try
            {
                var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
                using (var writer = File.CreateText(backingFile))
                {
                    await writer.WriteLineAsync(Data);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static void DeleteFile(string fileName)
        {
            try
            {
                var filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
                System.IO.File.Delete(filePath);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static bool FileExists(string fileName)
        {            
            try
            {
                var filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
                return System.IO.File.Exists(filePath);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
        }
    }
}

