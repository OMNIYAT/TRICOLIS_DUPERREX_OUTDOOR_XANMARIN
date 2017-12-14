using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Guide.Helpers
{
    /// <summary>
    /// Get File path
    /// </summary>
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
