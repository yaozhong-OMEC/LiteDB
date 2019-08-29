using System;
using AppKit;
using Foundation;
using LiteDB.Studio.Core.Models.CollectionView;
using LiteDB.Studio.Mac.Models;

namespace LiteDB.Studio.Mac.Views.Controls.CollectionOutlineView
{
    // Delegates recieve events associated with user action and determine how an item should be visualized
    internal class OutlineViewDelegate : NSOutlineViewDelegate
    {
        const string identifer = "myCellIdentifier";

        public override NSView GetView(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item)
        {
            // This pattern allows you to reuse existing views when they are no-longer in use.
            // If the returned view is null, you instance up a new view
            // If a non-null view is being returned, you modify it enough to reflect the new data
            var view = (NSTextField) outlineView.MakeView(identifer, this) ?? new NSTextField
            {
                Identifier = identifer,
                Bordered = false,
                Selectable = false,
                Editable = false,
                BackgroundColor = NSColor.Clear
            };

            view.StringValue = ((Node) item).Name;
            return view;
        }

        // An example of responding to user input 
        public override bool ShouldSelectItem(NSOutlineView outlineView, NSObject item)
        {
            Console.WriteLine("ShouldSelectItem: {0}", ((Node) item).Name);
            return item is Node node && (node.Type == CollectionItemType.UserCollection || node.Type == CollectionItemType.SystemCollection);
        }
    }
}