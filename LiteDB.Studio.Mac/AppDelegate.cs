using AppKit;
using Foundation;
using LiteDB.Studio.Core;
using MvvmCross.Platforms.Mac.Core;

namespace LiteDB.Studio.Mac
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender)
        {
            return true;
        }
    }
}