// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace HockeyTransfers.iOS
{
	[Register ("TransferViewCell")]
	partial class TransferViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel FromLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel PlayerLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ToLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (FromLabel != null) {
				FromLabel.Dispose ();
				FromLabel = null;
			}
			if (PlayerLabel != null) {
				PlayerLabel.Dispose ();
				PlayerLabel = null;
			}
			if (ToLabel != null) {
				ToLabel.Dispose ();
				ToLabel = null;
			}
		}
	}
}
