using System;
using System.IO;
using Xamarin.Forms;
using OutDoor_Guide.iOS;
using OutDoor_Guide.Helpers;

[assembly: Dependency(typeof(FileHelper))]
namespace OutDoor_Guide.iOS
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}