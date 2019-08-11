using System;
using AppKit;
using Foundation;
using LiteDB.Studio.Mac.Views.Controls;
using MvvmCross.Platforms.Mac.Views;

namespace LiteDB.Studio.Mac.Views.Main
{
    [MvxFromStoryboard(StoryboardName = "Studio")]
    public partial class StudioToolbarWindowController : MvxWindowController
    {
        public StudioToolbarWindowController(IntPtr handle) : base(handle)
        {
        }

        public StudioToolbarWindowController(NSWindow window) : base(window)
        {
        }

        public StudioToolbarWindowController(NSCoder coder) : base(coder)
        {
        }

        public StudioToolbarWindowController(string viewName, NSBundle bundle) : base(viewName, bundle)
        {
        }

        public StudioToolbarWindowController(string viewName) : base(viewName)
        {
        }

        public StudioToolbarWindowController()
        {
        }

        public NSExtendedToolbarItem ConnectButton => this.connectButton;
        public NSExtendedToolbarItem DisconnnectButton => this.disconnectButton;
    }
}