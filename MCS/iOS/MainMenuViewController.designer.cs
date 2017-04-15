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

namespace MobileClinicServices.iOS
{
    [Register ("MainMenuViewController")]
    partial class MainMenuViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton chatButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton logoutButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton profileButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (chatButton != null) {
                chatButton.Dispose ();
                chatButton = null;
            }

            if (logoutButton != null) {
                logoutButton.Dispose ();
                logoutButton = null;
            }

            if (profileButton != null) {
                profileButton.Dispose ();
                profileButton = null;
            }
        }
    }
}