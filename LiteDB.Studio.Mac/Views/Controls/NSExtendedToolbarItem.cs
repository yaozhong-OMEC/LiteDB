using System;
using AppKit;
using Foundation;

namespace LiteDB.Studio.Mac.Views.Controls
{
    [Register(nameof(NSExtendedToolbarItem))]
    public class NSExtendedToolbarItem : NSToolbarItem
    {
        public NSExtendedToolbarItem()
        {
        }

        protected NSExtendedToolbarItem(NSObjectFlag t) : base(t)
        {
        }

        protected internal NSExtendedToolbarItem(IntPtr handle) : base(handle)
        {
        }

        public NSExtendedToolbarItem(string itemIdentifier) : base(itemIdentifier)
        {
        }

        public override bool ValidateMenuItem(NSMenuItem menuItem)
        {
            return Enabled;
        }
    }
}