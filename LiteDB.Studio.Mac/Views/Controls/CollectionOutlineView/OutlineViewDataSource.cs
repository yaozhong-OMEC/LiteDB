using System;
using AppKit;
using Foundation;
using LiteDB.Studio.Mac.Models;

namespace LiteDB.Studio.Mac.Views.Controls.CollectionOutlineView
{
    internal class OutlineViewDataSource : NSOutlineViewDataSource
    {
        private readonly Node _parentNode;

        public OutlineViewDataSource(Node parentNode)
        {
            _parentNode = parentNode;
        }

        public override nint GetChildrenCount(NSOutlineView outlineView, NSObject item)
        {
            // If item is null, we are referring to the root element in the tree
            item = item ?? _parentNode;
            return ((Node) item).ChildCount;
        }

        public override NSObject GetChild(NSOutlineView outlineView, nint childIndex, NSObject item)
        {
            // If item is null, we are referring to the root element in the tree
            item = item ?? _parentNode;
            return ((Node) item).GetChild((int) childIndex);
        }

        public override bool ItemExpandable(NSOutlineView outlineView, NSObject item)
        {
            // If item is null, we are referring to the root element in the tree
            item = item ?? _parentNode;
            return !((Node) item).IsLeaf;
        }
    }
}