// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in Xcode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace LiteDB.Studio.Mac.Views.ConnectionForm
{
	[Register ("ConnectionFormViewController")]
	partial class ConnectionFormViewController
	{
		[Outlet]
		AppKit.NSButton cancelButton { get; set; }

		[Outlet]
		AppKit.NSButton confirmButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (cancelButton != null) {
				cancelButton.Dispose ();
				cancelButton = null;
			}

			if (confirmButton != null) {
				confirmButton.Dispose ();
				confirmButton = null;
			}

		}
	}
}
