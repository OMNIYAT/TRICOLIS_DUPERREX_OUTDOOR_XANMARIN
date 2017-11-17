using System.IO;
using Xamarin.Forms;
using OutDoor_Guide.UWP;
using Windows.Storage;
using OutDoor_Guide.Helpers;

[assembly: Dependency(typeof(FileHelper))]

namespace OutDoor_Guide.UWP
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }   
}
