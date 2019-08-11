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
	[Register (nameof(StudioViewController))]
	partial class StudioViewController
	{
		[Outlet]
		AppKit.NSButton TestButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (TestButton != null) {
				TestButton.Dispose ();
				TestButton = null;
			}

		}
	}
}
