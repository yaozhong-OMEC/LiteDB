using System.Linq;
using AppKit;
using Foundation;
using LiteDB.Studio.Core;
using MvvmCross;
using MvvmCross.Platforms.Mac.Core;
using MvvmCross.ViewModels;

namespace LiteDB.Studio.Mac
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
        /*public AppDelegate() : base()
        {
            /*caret#1#
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
            base.DidFinishLaunching(notification);
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
            base.WillTerminate(notification);
        }*/
         
    }
}