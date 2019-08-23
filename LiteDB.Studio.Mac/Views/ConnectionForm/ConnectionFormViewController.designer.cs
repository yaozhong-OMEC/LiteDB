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
		AppKit.NSButton browseFileButton { get; set; }

		[Outlet]
		AppKit.NSButton cancelButton { get; set; }

		[Outlet]
		AppKit.NSButton confirmButton { get; set; }

		[Outlet]
		AppKit.NSButton connectionModeEmbeddedRadioButton { get; set; }

		[Outlet]
		AppKit.NSTextField filePathTextField { get; set; }

		[Outlet]
		AppKit.NSButton openInReadonlyCheckbox { get; set; }

		[Outlet]
		AppKit.NSSecureTextField passwordTextField { get; set; }

		[Outlet]
		AppKit.NSTextField timeoutTextField { get; set; }

		[Outlet]
		AppKit.NSButton upgradeCheckbox { get; set; }

		[Outlet]
		AppKit.NSButton utcTimeCheckbox { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (browseFileButton != null) {
				browseFileButton.Dispose ();
				browseFileButton = null;
			}

			if (passwordTextField != null) {
				passwordTextField.Dispose ();
				passwordTextField = null;
			}

			if (upgradeCheckbox != null) {
				upgradeCheckbox.Dispose ();
				upgradeCheckbox = null;
			}

			if (utcTimeCheckbox != null) {
				utcTimeCheckbox.Dispose ();
				utcTimeCheckbox = null;
			}

			if (cancelButton != null) {
				cancelButton.Dispose ();
				cancelButton = null;
			}

			if (openInReadonlyCheckbox != null) {
				openInReadonlyCheckbox.Dispose ();
				openInReadonlyCheckbox = null;
			}

			if (timeoutTextField != null) {
				timeoutTextField.Dispose ();
				timeoutTextField = null;
			}

			if (confirmButton != null) {
				confirmButton.Dispose ();
				confirmButton = null;
			}

			if (connectionModeEmbeddedRadioButton != null) {
				connectionModeEmbeddedRadioButton.Dispose ();
				connectionModeEmbeddedRadioButton = null;
			}

			if (filePathTextField != null) {
				filePathTextField.Dispose ();
				filePathTextField = null;
			}

		}
	}
}
