// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in Xcode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace LiteDB.Studio.Mac.Views.Main
{
	[Register ("StudioViewController")]
	partial class StudioViewController
	{
		[Outlet]
		AppKit.NSOutlineView databaseCollectionsView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (databaseCollectionsView != null) {
				databaseCollectionsView.Dispose ();
				databaseCollectionsView = null;
			}

		}
	}
}
