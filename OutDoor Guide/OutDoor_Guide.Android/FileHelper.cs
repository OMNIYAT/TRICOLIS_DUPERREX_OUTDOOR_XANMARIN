using System;
using System.IO;
using Xamarin.Forms;
using OutDoor_Guide.Droid;
using OutDoor_Guide.Helpers;

[assembly: Dependency(typeof(FileHelper))]
namespace OutDoor_Guide.Droid
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}