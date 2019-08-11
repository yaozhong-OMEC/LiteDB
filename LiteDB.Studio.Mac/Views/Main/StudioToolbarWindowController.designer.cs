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
	[Register ("StudioToolbarWindowController")]
	partial class StudioToolbarWindowController
	{
		[Outlet]
		LiteDB.Studio.Mac.Views.Controls.NSExtendedToolbarItem connectButton { get; set; }

		[Outlet]
		LiteDB.Studio.Mac.Views.Controls.NSExtendedToolbarItem disconnectButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (connectButton != null) {
				connectButton.Dispose ();
				connectButton = null;
			}

			if (disconnectButton != null) {
				disconnectButton.Dispose ();
				disconnectButton = null;
			}

		}
	}
}
