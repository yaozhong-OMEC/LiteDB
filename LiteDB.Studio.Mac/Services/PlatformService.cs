using System.Globalization;
using System.Threading.Tasks;
using AppKit;
using LiteDB.Studio.Core.Attributes;
using LiteDB.Studio.Core.Services.Interfaces;

namespace LiteDB.Studio.Mac.Services
{
    [LazySingletonService]
    public class PlatformService : IPlatformService
    {
        public string BrowseFile()
        {
            var openDialog = new NSOpenPanel
            {
                Title = "Choose the database file",
                ShowsResizeIndicator = true,
                ShowsHiddenFiles = false,
                CanChooseDirectories = false,
                CanCreateDirectories = true,
                AllowsMultipleSelection = false,
                ReleasedWhenClosed = true
            };

            string path = null;

            if (openDialog.RunModal().ToString(CultureInfo.InvariantCulture) == NSModalResponse.OK.ToString("D"))
            {
               path = openDialog.Url?.Path;
            }
            
            openDialog.Close();
            return path;
        }
    }
}